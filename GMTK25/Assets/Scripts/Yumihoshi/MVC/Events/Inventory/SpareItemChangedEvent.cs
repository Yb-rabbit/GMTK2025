// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 18:00
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using Yumihoshi.SO.Item;

namespace Yumihoshi.MVC.Events.Inventory
{
    public struct SpareItemChangedEvent
    {
        public List<BaseItemData> newSpareItems;
    }
}
