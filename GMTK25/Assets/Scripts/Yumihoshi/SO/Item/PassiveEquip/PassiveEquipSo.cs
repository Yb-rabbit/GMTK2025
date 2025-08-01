// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 13:42
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Yumihoshi.SO.Item.PassiveEquip
{
    [CreateAssetMenu(fileName = "NewPassiveEquipDataList",
        menuName = "物品/新建装配类配置列表", order = 1)]
    public class PassiveEquipSo : ScriptableObject
    {
        [LabelText("装配类配置列表")]
        public List<PassiveEquipData> PassiveEquipDataList;
    }
}
