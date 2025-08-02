// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:04
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using QFramework;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using Yumihoshi.Entities;
using Yumihoshi.MVC.Commands.Inventory;
using Yumihoshi.SO.Item;
using Yumihoshi.SO.Item.Weapon;
using Yumihoshi.UI;

namespace Yumihoshi.Managers
{
    public class InputManager : HoshiVerseFramework.Base.Singleton<InputManager>
    {
        [LabelText("按E球体碰撞盒半径")] [SerializeField]
        private float sphereCastRadius = 1.5f;

        private Treasure _nearestTreasure;

        private GameObject _player;
        private ItemPickPanelUi _treasureItemInfoPanel;
        private int _treasureLayer;

        private void Start()
        {
            _treasureLayer = LayerMask.GetMask("Treasure");
            _treasureItemInfoPanel =
                GameObject.FindWithTag("TreasureItemInfoPanel")
                    .GetComponent<ItemPickPanelUi>();
            _treasureItemInfoPanel.gameObject.SetActive(false);
        }
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                OnOpenCloseTreasure();
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                OnPickTreasure();
            }
        }
        public void Pick()
        {
            Close();
            switch (_nearestTreasure.GetItemData().ItemType)
            {
                case ItemCategory.None:
                    break;
                case ItemCategory.Weapon:
                    InventoryManager.Instance.SendCommand(
                        new ChangeWeaponCmd(
                            _nearestTreasure.GetItemData() as WeaponData));
                    break;
                case ItemCategory.PassiveEquip:
                    break;
                case ItemCategory.Consumable:
                    InventoryManager.Instance.SendCommand(
                        new AddItemCmd(_nearestTreasure.GetItemData()));
                    break;
                case ItemCategory.Special:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Destroy(_nearestTreasure.gameObject);
        }

        private void OnPickTreasure()
        {
            //if (!value.isPressed) return;
           // Debug.Log("Pick Treasure");
            Pick();
        }

        private void OnOpenCloseTreasure()
        {
           // if (!value.isPressed) return;
            Debug.Log("Open/Close Treasure");
            // 若信息面板存在，隐藏并关闭宝箱
            if (_treasureItemInfoPanel.gameObject.activeInHierarchy)
                Close();
            // 若信息面板不存在，打开宝箱
            else
                Open();
        }

        private void Open()
        {
            _player = GameObject.FindWithTag("Player");
            if (!_player)
            {
                Debug.LogWarning("玩家未找到");
                return;
            }

            Vector3 playerPosition = _player.transform.position;
            Collider[] colliders = Physics.OverlapSphere(playerPosition,
                sphereCastRadius, _treasureLayer);
            Collider nearestCollider = null;
            float minDistance = Mathf.Infinity;

            // 遍历所有碰撞体，找到最近的宝箱
            foreach (Collider col in colliders)
            {
                float distance = Vector3.Distance(playerPosition,
                    col.transform.position);
                if (distance < minDistance)
                {
                    nearestCollider = col;
                    minDistance = distance;
                }
            }

            if (!nearestCollider)
            {
                Debug.Log("没有找到最近的宝箱");
                return;
            }

            _nearestTreasure = nearestCollider.GetComponent<Treasure>();
            _nearestTreasure.OpenTreasure();
            SetItemUI();
            _treasureItemInfoPanel.gameObject.SetActive(true);
        }

        private void SetItemUI()
        {
            BaseItemData itemData = _nearestTreasure.GetItemData();
            _treasureItemInfoPanel.SetItemImg(itemData.itemBigIcon);
            _treasureItemInfoPanel.SetItemName(itemData.itemName);
            _treasureItemInfoPanel.SetItemDesc(itemData.itemDesc);
        }

        private void Close()
        {
            _treasureItemInfoPanel.gameObject.SetActive(false);
            _nearestTreasure.CloseTreasure();
        }
    }
}
