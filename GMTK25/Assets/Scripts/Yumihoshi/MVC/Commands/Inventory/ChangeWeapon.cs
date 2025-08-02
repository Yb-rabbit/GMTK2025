// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 16:21
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using Yumihoshi.MVC.Events.Inventory;
using Yumihoshi.MVC.Models.Inventory;
using Yumihoshi.SO.Item.Weapon;

namespace Yumihoshi.MVC.Commands.Inventory
{
    public class ChangeWeapon : AbstractCommand
    {
        private readonly WeaponData _weaponData;
        private InventoryModel _model;

        public ChangeWeapon(WeaponData weaponData)
        {
            _weaponData = weaponData;
        }

        protected override void OnExecute()
        {
            _model = this.GetModel<InventoryModel>();
            _model.Weapon.Value = _weaponData;
            this.SendEvent(new WeaponChangedEvent
            {
                newWeapon = _weaponData
            });
        }
    }
}
