// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 15:03
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using QFramework;
using Yumihoshi.MVC.Models.Item;

namespace Yumihoshi.MVC.ViewControllers.Item
{
    public class WeaponController : BaseItemController
    {
        private WeaponModel _model;

        private void Start()
        {
            _model = this.GetModel<WeaponModel>();
        }
    }
}
