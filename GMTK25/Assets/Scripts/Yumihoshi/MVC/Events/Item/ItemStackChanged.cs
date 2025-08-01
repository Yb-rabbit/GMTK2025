// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 16:36
// @version: 1.0
// @description:
// *****************************************************************************

namespace Yumihoshi.MVC.Events.Item
{
    public struct ItemStackChanged
    {
        public string name;
        public ItemCategory category;
        public int newStack;
    }
}
