// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/04/05 21:04
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using HoshiVerseFramework.Components.Factory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HoshiVerseFramework.Configs
{
    [Serializable]
    public class VFXPoolConfig
    {
        [Header("特效对象池配置")] [LabelText("特效预制体")]
        public GameObject prefab;

        [LabelText("特效类型枚举")] public VFXType vfxType;

        [LabelText("默认对象池大小")] public int defaultCapacity = 20;

        [LabelText("最大对象池大小")] public int maxCapacity = 100;

        [LabelText("是否启用检查")] public bool collectionChecks = true;
    }
}
