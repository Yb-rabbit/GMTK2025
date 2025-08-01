// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:55
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Yumihoshi.SO.Item.Weapon
{
    [CreateAssetMenu(fileName = "NewWeaponDataList", menuName = "物品/新建手持物配置列表",
        order = 0)]
    public class WeaponSo : ScriptableObject
    {
        [LabelText("手持物配置列表")] public List<WeaponData> WeaponDataList;
    }
}
