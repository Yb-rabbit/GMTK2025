// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 13:28
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using Yumihoshi.MVC.Apps;
using Yumihoshi.SO.Inventory;

namespace Yumihoshi.Managers
{
    public class
        InventoryManager : HoshiVerseFramework.Base.Singleton<InventoryManager>,
        IController
    {
        private ResLoader _resLoader = ResLoader.Allocate();
        public InventoryConfig InventoryConfigSo { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            InventoryConfigSo =
                _resLoader.LoadSync<InventoryConfig>("inventoryconfig");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (_resLoader == null) return;
            _resLoader.Recycle2Cache();
            _resLoader = null;
        }

        public IArchitecture GetArchitecture()
        {
            return InventoryApp.Interface;
        }
    }
}
