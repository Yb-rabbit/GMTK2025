// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 16:00
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using QFramework;
using Yumihoshi.Managers;
using Yumihoshi.SO.Item;
using Yumihoshi.SO.Item.Weapon;

namespace Yumihoshi.MVC.Models.Inventory
{
    public class InventoryModel : AbstractModel
    {
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

        protected override void OnInit()
        {
            CurActiveSpareItemSize =
                new BindableProperty<int>(InventoryManager.Instance
                    .InventoryConfigSo.defaultSpareItemSize);
            for (var i = 0; i < CurActiveSpareItemSize.Value; i++)
                SpareItems.Add(null);
        }
    }
}
