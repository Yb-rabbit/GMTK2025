// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 13:28
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using QFramework;
using Sirenix.OdinInspector;
using UnityEngine;
using Yumihoshi.SO.Item;
using Yumihoshi.SO.Item.Weapon;

namespace Yumihoshi.Managers
{
    public class
        InventoryManager : HoshiVerseFramework.Base.Singleton<InventoryManager>
    {
        [LabelText("默认备用物品栏位")] [SerializeField]
        private int defaultSpareItemSize = 2;

        [LabelText("备用物品栏位最大值")] [SerializeField]
        private int maxSpareItemSize = 9;

        public BindableProperty<WeaponData> Weapon { get; private set; } =
            new();

        public BindableProperty<BaseItemData> ItemInHand { get; private set; } =
            new();

        public List<BaseItemData> SpareItems { get; } = new();

        public BindableProperty<int> CurActiveSpareItemSize
        {
            get;
            private set;
        }

        protected override void Awake()
        {
            base.Awake();
            CurActiveSpareItemSize =
                new BindableProperty<int>(defaultSpareItemSize);
        }

        public void SetCurActiveSpareItemSize(int size)
        {
            if (size < defaultSpareItemSize || size > maxSpareItemSize) return;
            CurActiveSpareItemSize.Value = size;
        }
    }
}
