// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:42
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using UnityEngine;
using Yumihoshi.MVC.Apps;

namespace Yumihoshi.MVC.ViewControllers.Item
{
    public class BaseItemController : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return ItemApp.Interface;
        }
    }
}
