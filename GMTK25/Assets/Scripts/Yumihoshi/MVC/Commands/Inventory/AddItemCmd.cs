// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 17:30
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using UnityEngine;
using Yumihoshi.MVC.Events.Inventory;
using Yumihoshi.MVC.Models.Inventory;
using Yumihoshi.SO.Item;

namespace Yumihoshi.MVC.Commands.Inventory
{
    public class AddItemCmd : AbstractCommand
    {
        private InventoryModel _model;
        private readonly BaseItemData _itemData;

        public AddItemCmd(BaseItemData data)
        {
            _itemData = data;
        }

        protected override void OnExecute()
        {
            _model = this.GetModel<InventoryModel>();
            // 若手持道具栏为空，添加到该栏
            if (_model.ItemInHand.Value == null)
            {
                this.SendEvent(new ItemInHandChangedEvent
                {
                    newItem = _itemData,
                    oldItem = _model.ItemInHand.Value
                });
                _model.ItemInHand.Value = _itemData;
            }
            // 若手持道具栏不为空，添加到备用道具栏
            else
            {
                var existSpare = false;
                var spareIndex = 0;

                for (var i = 0; i < _model.SpareItems.Count; i++)
                {
                    // 若id相同堆叠
                    if (_model.SpareItems[i] != null && _itemData.itemId ==
                        _model.SpareItems[i].itemId)
                    {
                        _model.SpareItems[i]
                            .AddStack(_itemData.currentStackCount);
                        this.SendEvent(new SpareItemChangedEvent
                        {
                            newSpareItems = _model.SpareItems
                        });
                        return;
                    }

                    if (!existSpare && _model.SpareItems[i] == null)
                    {
                        existSpare = true;
                        spareIndex = i;
                    }
                }

                if (!existSpare)
                {
                    Debug.LogWarning("没有空位置，无法拾取道具");
                    return;
                }

                _model.SpareItems[spareIndex] = _itemData;
                this.SendEvent(new SpareItemChangedEvent
                {
                    newSpareItems = _model.SpareItems
                });
            }
        }
    }
}
