// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 17:52
// @version: 1.0
// @description:
// *****************************************************************************

using Yumihoshi.SO.Item;

namespace Yumihoshi.MVC.Events.Inventory
{
    public struct ItemInHandChangedEvent
    {
        public BaseItemData newItem;
        public BaseItemData oldItem;
    }
}
