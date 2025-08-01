// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:40
// @version: 1.0
// @description: 运行时物品模型
// *****************************************************************************

using System.Collections.Generic;
using QFramework;
using Yumihoshi.SO.Item;

namespace Yumihoshi.MVC.Models.Item
{
    public class BaseItemModel<TData> : AbstractModel where TData : BaseItemData
    {
        public Dictionary<string, TData> Data { get; } = new();

        protected override void OnInit()
        {
        }
    }
}
