// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 00:21
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Yumihoshi.SO.Level
{
    [CreateAssetMenu(fileName = "NewLevelTreasureConfig", menuName = "关卡/新建关卡物品库配置", order = 0)]
    public class LevelTreasureConfig : ScriptableObject
    {
        [LabelText("关卡物品库配置（id）")]
        public List<string> Config;
    }
}
