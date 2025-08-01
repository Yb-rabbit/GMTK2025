// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:43
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Yumihoshi.SO.Item
{
    [Serializable]
    public class BaseItemData
    {
        [LabelText("物品名称")] public string ItemName; // 物品名称
        [LabelText("物品类型")] public ItemCategory ItemType; // 物品类型
        [LabelText("物品描述")] [TextArea] public string ItemDesc; // 物品描述
    }
}
