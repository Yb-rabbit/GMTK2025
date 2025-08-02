// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:05
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using System.Linq;
using QFramework;
using UnityEngine;
using Yumihoshi.MVC.Apps;
using Yumihoshi.MVC.Commands.Item;
using Yumihoshi.MVC.Models.Item;
using Yumihoshi.MVC.ViewControllers.Item;
using Yumihoshi.SO.Item;
using Yumihoshi.SO.Item.Consumable;
using Yumihoshi.SO.Item.PassiveEquip;
using Yumihoshi.SO.Item.Special;
using Yumihoshi.SO.Item.Weapon;

namespace Yumihoshi.Managers
{
    public class ItemManager : HoshiVerseFramework.Base.Singleton<ItemManager>,
        IController
    {
        // SO
        private ResLoader _resLoader = ResLoader.Allocate();
        private SpecialController _specialController;

        // Controller
        private WeaponController _weaponController;
        private ConsumableController _consumableController;
        private PassiveEquipController _passiveEquipController;

        public Dictionary<ItemCategory, ScriptableObject> ItemSoDict { get; } =
            new();

        // Models
        private ConsumableModel _consumableModel;
        private PassiveEquipModel _passiveEquipModel;
        private SpecialModel _specialModel;
        private WeaponModel _weaponModel;


        protected override void Awake()
        {
            base.Awake();
            InitSo();
            InitModels();
            InitControllers();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            // 清理资源加载器
            if (_resLoader == null) return;
            _resLoader.Recycle2Cache();
            _resLoader = null;
        }

        public IArchitecture GetArchitecture()
        {
            return ItemApp.Interface;
        }

        /// <summary>
        /// 根据已有配置列表创建物品
        /// </summary>
        /// <param name="category"></param>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        public void CreateItem(ItemCategory category, string name,
            int amount = 1)
        {
            this.SendCommand(new AddItemStackCmd(category, name, amount));
        }

        /// <summary>
        /// 减少物品数量
        /// </summary>
        /// <param name="category"></param>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        public void DecreaseItem(ItemCategory category, string name,
            int amount = 1)
        {
            this.SendCommand(new DecreaseItemStackCmd(category, name, amount));
        }

        /// <summary>
        /// 根据物品ID查找物品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseItemData FindItemById(string id)
        {
            // 遍历字典
            foreach (ScriptableObject itemSo in ItemSoDict.Values)
            {
                switch (itemSo)
                {
                    // 如果是武器
                    case WeaponSo weaponSo:
                    {
                        foreach (WeaponData data in
                                 weaponSo.WeaponDataList.Where(data =>
                                     data.itemId == id))
                        {
                            return data;
                        }

                        break;
                    }
                    // 如果是被动装备
                    case PassiveEquipSo passiveEquipSo:
                    {
                        foreach (PassiveEquipData data in
                                  passiveEquipSo.PassiveEquipDataList.Where(data =>
                                     data.itemId == id))
                        {
                            return data;
                        }

                        break;
                    }
                    // 如果是消耗品
                    case ConsumableSo consumableSo:
                    {
                        foreach (ConsumableData data in
                                 consumableSo.ConsumableDataList.Where(data =>
                                     data.itemId == id))
                        {
                            return data;
                        }

                        break;
                    }
                    // 如果是特殊物品
                    case SpecialSo specialSo:
                    {
                        foreach (SpecialData data in
                                 specialSo.SpecialDataList.Where(data =>
                                     data.itemId == id))
                        {
                            return data;
                        }
                        break;
                    }
                }
            }

            Debug.LogWarning("未找到对应ID的物品: " + id);
            return null;
        }

        private void InitSo()
        {
            // TODO: 初始化资源kit（打包时记得调真机模式并重新打一次AB包，此TODO仅为提醒）
            ItemSoDict[ItemCategory.Weapon] =
                _resLoader.LoadSync<WeaponSo>("weapondatalist");
            ItemSoDict[ItemCategory.PassiveEquip] =
                _resLoader.LoadSync<PassiveEquipSo>("passiveequipdatalist");
            ItemSoDict[ItemCategory.Consumable] =
                _resLoader.LoadSync<ConsumableSo>("consumabledatalist");
            ItemSoDict[ItemCategory.Special] =
                _resLoader.LoadSync<SpecialSo>("specialdatalist");
        }

        private void InitControllers()
        {
            _weaponController = GetComponentInChildren<WeaponController>();
            _consumableController =
                GetComponentInChildren<ConsumableController>();
            _passiveEquipController =
                GetComponentInChildren<PassiveEquipController>();
            _specialController = GetComponentInChildren<SpecialController>();
        }

        private void InitModels()
        {
            // 获取模型
            _consumableModel = this.GetModel<ConsumableModel>();
            _passiveEquipModel = this.GetModel<PassiveEquipModel>();
            _specialModel = this.GetModel<SpecialModel>();
            _weaponModel = this.GetModel<WeaponModel>();
        }
    }
}
