// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 13:31
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Sirenix.OdinInspector;

namespace Yumihoshi.SO.Item.Weapon
{
    [Serializable]
    public class WeaponData : BaseItemData
    {
        [LabelText("伤害")] public float Damage;

        [LabelText("攻速")] public float AttackSpeed;
        [LabelText("攻击范围")] public float AttackRange;
        [LabelText("出刀时防御值")] public float DefenseValue;

        public override ItemCategory ItemType => ItemCategory.Weapon;
    }
}
