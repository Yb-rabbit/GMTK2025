// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 13:45
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Yumihoshi.SO.Item.Consumable
{
    [Serializable]
    public class ConsumableData : BaseItemData
    {
        [Header("即刻恢复")] [LabelText("总共恢复血量")] public float TotalHealAmount;

        [Header("缓慢恢复（若启用则即刻恢复无效）")] [LabelText("是否缓慢恢复")]
        public bool IsSlowHeal;

        [LabelText("恢复速度（每秒）")] public float HealPerSecond;

        [LabelText("缓慢恢复时间（秒）")] public float SlowHealDuration;

        public override ItemCategory ItemType => ItemCategory.Consumable;
    }
}
