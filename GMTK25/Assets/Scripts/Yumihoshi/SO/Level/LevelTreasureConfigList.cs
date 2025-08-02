// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 00:29
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using UnityEngine;

namespace Yumihoshi.SO.Level
{
    [CreateAssetMenu(fileName = "NewLevelTreasureConfigList", menuName = "关卡/新建关卡物品库列表配置", order = 1)]
    public class LevelTreasureConfigList : ScriptableObject
    {
        public List<LevelTreasureConfig> ConfigList;
    }
}
