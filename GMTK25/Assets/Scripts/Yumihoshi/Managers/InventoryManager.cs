// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 13:28
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using Yumihoshi.MVC.Apps;
using Yumihoshi.MVC.Models.Inventory;
using Yumihoshi.SO.Inventory;
using Yumihoshi.SO.Item;

namespace Yumihoshi.Managers
{
    public class
        InventoryManager : HoshiVerseFramework.Base.Singleton<InventoryManager>,
        IController
    {
        private ResLoader _resLoader = ResLoader.Allocate();
        public InventoryConfig InventoryConfigSo { get; private set; }

        private InventoryModel _model;

        protected override void Awake()
        {
            base.Awake();
            InventoryConfigSo =
                _resLoader.LoadSync<InventoryConfig>("inventoryconfig");
            _model = this.GetModel<InventoryModel>();
        }
        
        private void Start()
        {
            GameManager.Instance.OnReloadGameEvent.AddListener(Reset);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (_resLoader == null) return;
            _resLoader.Recycle2Cache();
            _resLoader = null;
        }

        public void Reset()
        {
            // _model.Weapon.Value.currentStackCount = 0;
            // _model.Weapon.Value = null;
            _model.ItemInHand.Value.currentStackCount = 0;
            _model.ItemInHand.Value = null;
            for (int i = 0; i < _model.SpareItems.Count; i++)
            {
                _model.SpareItems[i].currentStackCount = 0;
                _model.SpareItems[i] = null;
            }
        }

        public IArchitecture GetArchitecture()
        {
            return InventoryApp.Interface;
        }
    }
}
