// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 16:58
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using QFramework;
using UnityEngine;
using Yumihoshi.Managers;
using Yumihoshi.MVC.Events.Item;
using Yumihoshi.MVC.Models.Item;
using Yumihoshi.SO.Item;
using Yumihoshi.SO.Item.Consumable;
using Yumihoshi.SO.Item.PassiveEquip;
using Yumihoshi.SO.Item.Special;
using Yumihoshi.SO.Item.Weapon;

namespace Yumihoshi.MVC.Commands.Item
{
    public class AddItemStackCmd : AbstractCommand
    {
        private readonly int _amount;
        private readonly ItemCategory _category;
        private readonly string _name;

        public AddItemStackCmd(ItemCategory category, string name,
            int amount = 1)
        {
            _category = category;
            _name = name;
            _amount = amount;
        }

        protected override void OnExecute()
        {
            switch (_category)
            {
                case ItemCategory.None:
                    break;
                case ItemCategory.Weapon:
                    AddWeapon();
                    break;
                case ItemCategory.PassiveEquip:
                    AddPassiveEquip();
                    break;
                case ItemCategory.Consumable:
                    AddConsumable();
                    break;
                case ItemCategory.Special:
                    AddSpecial();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Add<TData, TModel>(TData data, TModel model)
            where TData : BaseItemData where TModel : BaseItemModel<TData>
        {
            // 如果不存在，添加
            if (model.Data.TryAdd(_name, data))
            {
                model.Data[_name].ClearStack();
                model.Data[_name].AddStack(_amount);
                this.SendEvent(new AddItemEvent
                {
                    category = model.Data[_name].ItemType,
                    name = model.Data[_name].itemName,
                    stack = model.Data[_name].currentStackCount
                });
                Debug.Log(
                    $"物品{_name}添加成功，当前堆叠数量: {model.Data[_name].currentStackCount}");
                return;
            }

            // 如果已存在，增加堆叠数量
            if (model.Data[_name].AddStack(_amount))
            {
                this.SendEvent(new ItemStackChanged
                {
                    newStack = model.Data[_name].currentStackCount,
                    category = model.Data[_name].ItemType,
                    name = model.Data[_name].itemName
                });
                Debug.Log(
                    $"物品{_name}添加成功，当前堆叠数量: {model.Data[_name].currentStackCount}");
            }
        }

        private void AddWeapon()
        {
            var model = this.GetModel<WeaponModel>();
            foreach (WeaponData data in (ItemManager.Instance
                         .ItemSoDict[ItemCategory.Weapon] as WeaponSo)
                     .WeaponDataList)
            {
                // 找到配置中有对应的物品
                if (data.itemName != _name) continue;
                Add(data, model);
                return;
            }
        }

        private void AddConsumable()
        {
            var model = this.GetModel<ConsumableModel>();
            foreach (ConsumableData data in (ItemManager.Instance
                         .ItemSoDict[ItemCategory.Consumable] as ConsumableSo)
                     .ConsumableDataList)
            {
                // 找到配置中有对应的物品
                if (data.itemName != _name) continue;
                Add(data, model);
                return;
            }
        }

        private void AddPassiveEquip()
        {
            var model = this.GetModel<PassiveEquipModel>();
            foreach (PassiveEquipData data in (ItemManager.Instance
                             .ItemSoDict[ItemCategory.PassiveEquip] as
                         PassiveEquipSo).PassiveEquipDataList)
            {
                // 找到配置中有对应的物品
                if (data.itemName != _name) continue;
                Add(data, model);
                return;
            }
        }

        private void AddSpecial()
        {
            var model = this.GetModel<SpecialModel>();
            foreach (SpecialData data in (ItemManager.Instance
                         .ItemSoDict[ItemCategory.Special] as SpecialSo)
                     .SpecialDataList)
            {
                // 找到配置中有对应的物品
                if (data.itemName != _name) continue;
                Add(data, model);
                return;
            }
        }
    }
}
