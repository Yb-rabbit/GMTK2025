// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 23:50
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using System.Collections;
using QFramework;
using Sirenix.OdinInspector;
using UnityEngine;
using Yumihoshi.Managers;
using Yumihoshi.MVC.Apps;
using Yumihoshi.MVC.Models.Item;
using Yumihoshi.SO.Item;

namespace Yumihoshi.Entities
{
    public class Treasure : MonoBehaviour
    {
        /// <summary>
        /// 物品数据基类，需as转换
        /// </summary>
        public BaseItemData ItemData { get; private set; }

        private static readonly int OpenID = Animator.StringToHash("Open");
        private Animator _animator;
        private string _itemId;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _itemId = LevelManager.Instance.GetRandomCurLevelItemId();
            ItemData = ItemManager.Instance.FindItemById(_itemId);
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

        /// <summary>
        /// 拾取宝箱物品
        /// </summary>
        /// <returns></returns>
        /// <param name="closeTreasure">拾取后是否关闭宝箱</param>
        public BaseItemData PickUpTreasure(bool closeTreasure = true)
        {
            if (closeTreasure)
                CloseTreasure();
            return ItemData;
        }
    }
}
