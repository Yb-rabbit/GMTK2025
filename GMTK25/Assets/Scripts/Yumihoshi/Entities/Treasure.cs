// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 23:50
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using Yumihoshi.Managers;

namespace Yumihoshi.Entities
{
    public class Treasure : MonoBehaviour
    {
        public string ItemId { get; private set; }

        private static readonly int OpenID = Animator.StringToHash("Open");
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            ItemId = LevelManager.Instance.GetRandomCurLevelItemId();
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
    }
}
