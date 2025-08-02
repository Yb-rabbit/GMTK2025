// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 16:22
// @version: 1.0
// @description:
// *****************************************************************************

using Yumihoshi.SO.Item.Weapon;

namespace Yumihoshi.MVC.Events.Inventory
{
    public struct WeaponChangedEvent
    {
        public WeaponData newWeapon;
    }
}
