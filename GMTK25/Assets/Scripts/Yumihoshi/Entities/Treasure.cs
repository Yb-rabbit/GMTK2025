﻿// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 23:50
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using UnityEngine;
using Yumihoshi.Managers;
using Yumihoshi.MVC.Apps;
using Yumihoshi.MVC.Commands.Item;
using Yumihoshi.SO.Item;

namespace Yumihoshi.Entities
{
    public class Treasure : MonoBehaviour, IController
    {
        private static readonly int OpenID = Animator.StringToHash("Open");
        private Animator _animator;
        private BaseItemData _itemData;
        private string _itemId;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _itemId = LevelManager.Instance.GetRandomCurLevelItemId();
            _itemData = ItemManager.Instance.FindItemById(_itemId);
        }

        public IArchitecture GetArchitecture()
        {
            return ItemApp.Interface;
        }

        /// <summary>
        /// 打开宝箱
        /// </summary>
        public void OpenTreasure()
        {
            _animator.SetBool(OpenID, true);
        }

        /// <summary>
        /// 关闭宝箱
        /// </summary>
        public void CloseTreasure()
        {
            _animator.SetBool(OpenID, false);
        }

        public BaseItemData GetItemData()
        {
            return _itemData;
        }

        /// <summary>
        /// 拾取宝箱物品
        /// </summary>
        /// <returns></returns>
        /// <param name="closeTreasure">拾取后是否关闭宝箱</param>
        public BaseItemData PickUpTreasure(bool closeTreasure = true)
        {
            if (closeTreasure)
                CloseTreasure();
            this.SendCommand(new AddItemStackCmd(_itemData.ItemType,
                _itemData.itemName));
            return _itemData;
        }
    }
}
