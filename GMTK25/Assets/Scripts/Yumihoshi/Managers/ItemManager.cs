// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:05
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using QFramework;
using UnityEngine;
using Yumihoshi.MVC.Apps;
using Yumihoshi.MVC.Commands.Item;
using Yumihoshi.MVC.ViewControllers.Item;
using Yumihoshi.SO.Item.Consumable;
using Yumihoshi.SO.Item.PassiveEquip;
using Yumihoshi.SO.Item.Special;
using Yumihoshi.SO.Item.Weapon;

namespace Yumihoshi.Managers
{
    public class ItemManager : HoshiVerseFramework.Base.Singleton<ItemManager>,
        IController
    {
        private ConsumableController _consumableController;

        private PassiveEquipController _passiveEquipController;

        // SO
        private ResLoader _resLoader = ResLoader.Allocate();
        private SpecialController _specialController;

        // Controller
        private WeaponController _weaponController;

        public Dictionary<ItemCategory, ScriptableObject> ItemSoDict { get; } =
            new();


        protected override void Awake()
        {
            base.Awake();
            InitSo();
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
    }
}
