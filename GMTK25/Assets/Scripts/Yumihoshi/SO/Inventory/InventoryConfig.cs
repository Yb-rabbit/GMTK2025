// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 16:01
// @version: 1.0
// @description:
// *****************************************************************************

using Sirenix.OdinInspector;
using UnityEngine;

namespace Yumihoshi.SO.Inventory
{
    [CreateAssetMenu(fileName = "NewInventoryConfig", menuName = "背包/新建背包配置",
        order = 0)]
    public class InventoryConfig : ScriptableObject
    {
        [LabelText("默认备用物品栏位大小")] public int defaultSpareItemSize = 2;

        [LabelText("备用物品栏位最大值")] public int maxSpareItemSize = 9;
    }
}
