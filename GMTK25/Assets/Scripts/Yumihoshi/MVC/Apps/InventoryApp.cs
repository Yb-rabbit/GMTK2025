// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 15:59
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using Yumihoshi.MVC.Models.Inventory;
using Yumihoshi.Utility;

namespace Yumihoshi.MVC.Apps
{
    public class InventoryApp : Architecture<InventoryApp>
    {
        protected override void Init()
        {
            RegisterUtility(new Storage());
            RegisterModel(new InventoryModel());
        }
    }
}
