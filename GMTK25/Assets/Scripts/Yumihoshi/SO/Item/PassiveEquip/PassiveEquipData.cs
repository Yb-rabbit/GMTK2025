// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 13:41
// @version: 1.0
// @description:
// *****************************************************************************

using System;

namespace Yumihoshi.SO.Item.PassiveEquip
{
    [Serializable]
    public class PassiveEquipData : BaseItemData
    {
        // TODO: 装配类数据
        public override ItemCategory ItemType => ItemCategory.PassiveEquip;
    }
}
