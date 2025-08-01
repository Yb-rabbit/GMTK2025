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
        // TODO: 手持物数据
        public override ItemCategory ItemType => ItemCategory.Weapon;
        [LabelText("伤害")] public float Damage;
        [LabelText("攻速")] public float AttackSpeed;
    }
}
