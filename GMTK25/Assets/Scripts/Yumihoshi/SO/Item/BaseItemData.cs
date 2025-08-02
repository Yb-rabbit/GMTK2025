// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:43
// @version: 1.0
// @description:
// *****************************************************************************

using Sirenix.OdinInspector;
using UnityEngine;

namespace Yumihoshi.SO.Item
{
    public class BaseItemData
    {
        [LabelText("当前堆叠数量")] public int currentStackCount; // 当前堆叠数量
        [LabelText("物品描述")] [TextArea] public string itemDesc; // 物品描述

        [LabelText("物品UI图标")] public Sprite itemIcon; // 物品图标
        [LabelText("物品ID")] public string itemId; // 物品ID
        [LabelText("物品名称")] public string itemName; // 物品名称
        [LabelText("最大堆叠数量")] public int maxStackCount = 1; // 最大堆叠数量

        [LabelText("物品类型")]
        public virtual ItemCategory ItemType { get; } // 物品类型

        /// <summary>
        /// 增加堆叠数量
        /// </summary>
        /// <param name="amount"></param>
        public bool AddStack(int amount = 1)
        {
            currentStackCount += amount;
            if (currentStackCount > maxStackCount)
            {
                Debug.LogWarning($"物品{itemName}超过最大堆叠数量，自动修正");
                currentStackCount = maxStackCount;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 减少堆叠数量
        /// </summary>
        /// <param name="amount"></param>
        public bool DecreaseStack(int amount = 1)
        {
            currentStackCount -= amount;
            if (currentStackCount <= 0)
            {
                Debug.LogWarning($"物品{itemName}堆叠数量小于0，自动修正");
                currentStackCount = 0;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 清除堆叠数量
        /// </summary>
        public void ClearStack()
        {
            currentStackCount = 0;
        }
    }
}
