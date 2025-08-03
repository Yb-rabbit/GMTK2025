// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/03 13:35
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using Yumihoshi.MVC.Events.Inventory;
using Yumihoshi.MVC.Models.Inventory;

namespace Yumihoshi.MVC.Commands.Inventory
{
    public class UseItemInHandCmd : AbstractCommand
    {
        private InventoryModel _model;

        protected override void OnExecute()
        {
            _model = this.GetModel<InventoryModel>();
            if (_model.ItemInHand.Value == null) return;
            _model.ItemInHand.Value.DecreaseStack();
            if (_model.ItemInHand.Value.currentStackCount == 0)
            {
                _model.ItemInHand.Value = null;
                this.SendEvent(new ItemInHandChangedEvent
                {
                    newItem = null
                });
                return;
            }

            this.SendEvent(new ItemInHandChangedEvent
            {
                newItem = _model.ItemInHand.Value
            });
        }
    }
}
