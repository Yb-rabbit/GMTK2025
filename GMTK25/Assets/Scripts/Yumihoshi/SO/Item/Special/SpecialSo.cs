// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 14:10
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Yumihoshi.SO.Item.Special
{
    [CreateAssetMenu(fileName = "NewSpecialDataList",
        menuName = "物品/新建特殊道具类配置列表", order = 3)]
    public class SpecialSo : ScriptableObject
    {
        [LabelText("特殊道具类配置列表")]
        public List<SpecialData> SpecialDataList;
    }
}
