// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:05
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using Yumihoshi.SO.Item.Consumable;
using Yumihoshi.SO.Item.PassiveEquip;
using Yumihoshi.SO.Item.Special;
using Yumihoshi.SO.Item.Weapon;

namespace Yumihoshi.Managers
{
    public class ItemManager : HoshiVerseFramework.Base.Singleton<ItemManager>
    {
        public WeaponSo WeaponDataSo { get; private set; }
        public PassiveEquipSo PassiveEquipDataSo { get; private set; }
        public ConsumableSo ConsumableDataSo { get; private set; }
        public SpecialSo SpecialDataSo { get; private set; }

        private ResLoader _resLoader = ResLoader.Allocate();

        protected override void Awake()
        {
            base.Awake();
            // TODO: 初始化资源kit（打包时记得调真机模式并重新打一次AB包，此TODO仅为提醒）
#if !UNITY_EDITOR
            ResKit.Init();
#endif

            // 初始化物品SO
            WeaponDataSo = _resLoader.LoadSync<WeaponSo>("weapondatalist");
            PassiveEquipDataSo =
                _resLoader.LoadSync<PassiveEquipSo>("passiveequipdatalist");
            ConsumableDataSo =
                _resLoader.LoadSync<ConsumableSo>("consumabledatalist");
            SpecialDataSo = _resLoader.LoadSync<SpecialSo>("specialdatalist");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            // 清理资源加载器
            if (_resLoader == null) return;
            _resLoader.Recycle2Cache();
            _resLoader = null;
        }
    }
}
