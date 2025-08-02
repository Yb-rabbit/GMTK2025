// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 16:04
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using Yumihoshi.Managers;
using Yumihoshi.MVC.Models.Inventory;

namespace Yumihoshi.MVC.Commands.Inventory
{
    public class SetSpareSizeCmd : AbstractCommand
    {
        private readonly InventoryModel _model;
        private readonly int _size;

        public SetSpareSizeCmd(int size)
        {
            _size = size;
            _model = this.GetModel<InventoryModel>();
        }

        protected override void OnExecute()
        {
            if (_size < InventoryManager.Instance
                    .InventoryConfigSo.defaultSpareItemSize ||
                _size > InventoryManager.Instance
                    .InventoryConfigSo.maxSpareItemSize) return;

            _model.CurActiveSpareItemSize.Value = _size;

            if (_model.SpareItems.Count < _size)
                for (var i = 0; i < _size - _model.SpareItems.Count; i++)
                    _model.SpareItems.Add(null);
        }
    }
}
