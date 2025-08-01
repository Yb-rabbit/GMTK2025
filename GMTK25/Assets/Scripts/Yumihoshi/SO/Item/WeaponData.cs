// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 13:31
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Sirenix.OdinInspector;

namespace Yumihoshi.SO.Item
{
    [Serializable]
    public class WeaponData : BaseItemData
    {
        [LabelText("伤害")] public float Damage;
        [LabelText("攻速")] public float AttackSpeed;
    }
}
