// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 17:08
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using QFramework;
using UnityEngine;
using Yumihoshi.Managers;
using Yumihoshi.MVC.Events;
using Yumihoshi.MVC.Events.Item;
using Yumihoshi.MVC.Models.Item;
using Yumihoshi.SO.Item;
using Yumihoshi.SO.Item.Consumable;
using Yumihoshi.SO.Item.PassiveEquip;
using Yumihoshi.SO.Item.Special;
using Yumihoshi.SO.Item.Weapon;

namespace Yumihoshi.MVC.Commands.Item
{
    public class DecreaseItemStackCmd : AbstractCommand
    {
        private readonly int _amount;
        private readonly ItemCategory _category;
        private readonly string _name;

        public DecreaseItemStackCmd(ItemCategory category, string name,
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
                    DecreaseWeapon();
                    break;
                case ItemCategory.PassiveEquip:
                    DecreasePassiveEquip();
                    break;
                case ItemCategory.Consumable:
                    DecreaseConsumable();
                    break;
                case ItemCategory.Special:
                    DecreaseSpecial();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Decrease<TData, TModel>(TData data, TModel model)
            where TData : BaseItemData where TModel : BaseItemModel<TData>
        {
            // 如果已存在，减少堆叠数量
            // TODO: 0检测，并添加移除物品和刚添加物品事件
            if (model.Data[_name].DecreaseStack(_amount))
            {
                this.SendEvent(new ItemStackChanged
                {
                    newStack = model.Data[_name].currentStackCount,
                    category = model.Data[_name].ItemType,
                    name = model.Data[_name].itemName
                });
            }
            else
            {
                this.SendEvent(new RemoveItemEvent
                {
                    category = model.Data[_name].ItemType,
                    name = model.Data[_name].itemName
                });
                model.Data.Remove(_name);
            }

            Debug.Log(
                $"物品{_name}删除成功，当前堆叠数量: {model.Data[_name].currentStackCount}");
        }

        private void DecreaseWeapon()
        {
            var model = this.GetModel<WeaponModel>();
            // 如果不存在，跳过
            if (!model.Data.ContainsKey(_name)) return;
            foreach (WeaponData data in (ItemManager.Instance
                         .ItemSoDict[ItemCategory.Weapon] as WeaponSo)
                     .WeaponDataList)
            {
                // 找到配置中有对应的物品
                if (data.itemName != _name) continue;
                Decrease(data, model);
                return;
            }
        }

        private void DecreaseConsumable()
        {
            var model = this.GetModel<ConsumableModel>();
            // 如果不存在，跳过
            if (!model.Data.ContainsKey(_name)) return;
            foreach (ConsumableData data in (ItemManager.Instance
                         .ItemSoDict[ItemCategory.Consumable] as ConsumableSo)
                     .ConsumableDataList)
            {
                // 找到配置中有对应的物品
                if (data.itemName != _name) continue;
                Decrease(data, model);
                return;
            }
        }

        private void DecreasePassiveEquip()
        {
            var model = this.GetModel<PassiveEquipModel>();
            foreach (PassiveEquipData data in (ItemManager.Instance
                             .ItemSoDict[ItemCategory.PassiveEquip] as
                         PassiveEquipSo).PassiveEquipDataList)
            {
                // 找到配置中有对应的物品
                if (data.itemName != _name) continue;
                Decrease(data, model);
                return;
            }
        }

        private void DecreaseSpecial()
        {
            var model = this.GetModel<SpecialModel>();
            foreach (SpecialData data in (ItemManager.Instance
                         .ItemSoDict[ItemCategory.Special] as SpecialSo)
                     .SpecialDataList)
            {
                // 找到配置中有对应的物品
                if (data.itemName != _name) continue;
                Decrease(data, model);
                return;
            }
        }
    }
}
