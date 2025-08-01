// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:39
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using Yumihoshi.MVC.Models.Item;
using Yumihoshi.Utility;

namespace Yumihoshi.MVC.Apps
{
    public class ItemApp : Architecture<ItemApp>
    {
        protected override void Init()
        {
            RegisterUtility(new Storage());
            RegisterModel(new ConsumableModel());
            RegisterModel(new PassiveEquipModel());
            RegisterModel(new SpecialModel());
            RegisterModel(new WeaponModel());
        }
    }
}
