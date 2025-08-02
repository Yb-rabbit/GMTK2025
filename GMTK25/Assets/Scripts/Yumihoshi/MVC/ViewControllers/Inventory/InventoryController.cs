// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 16:25
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using UnityEngine;
using Yumihoshi.MVC.Apps;

namespace Yumihoshi.MVC.ViewControllers.Inventory
{
    public class InventoryController : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return InventoryApp.Interface;
        }
    }
}
