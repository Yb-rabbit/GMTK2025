// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/04/08 19:04
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using UnityEngine;

namespace HoshiVerseFramework.Configs
{
    [CreateAssetMenu(fileName = "VFXPoolConfig",
        menuName = "特效TA/对象池/新建配置列表",
        order = 0)]
    public class VFXPoolConfigList : ScriptableObject
    {
        public List<VFXPoolConfig> configList = new();
    }
}
