// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 17:33
// @version: 1.0
// @description:
// *****************************************************************************

namespace Yumihoshi.MVC.Events.Item
{
    public struct AddItemEvent
    {
        public string name;
        public ItemCategory category;
        public int stack;
    }
}
