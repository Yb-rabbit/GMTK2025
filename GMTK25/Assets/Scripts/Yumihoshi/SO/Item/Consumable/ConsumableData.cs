// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 13:45
// @version: 1.0
// @description:
// *****************************************************************************

using System;

namespace Yumihoshi.SO.Item.Consumable
{
    [Serializable]
    public class ConsumableData : BaseItemData
    {
        // TODO: 补给类数据
        public override ItemCategory ItemType => ItemCategory.Consumable;
    }
}
