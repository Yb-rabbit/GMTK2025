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

namespace Yumihoshi.Entities
{
    public class Treasure : MonoBehaviour
    {
        public string ItemId
        {
            get => _itemId;
            set => _itemId = value;
        }
        
        private static readonly int OpenID = Animator.StringToHash("Open");
        private Animator _animator;
        [Header("宝箱内物品配置")]
        [LabelText("物品id")] [SerializeField] private string _itemId;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            StartCoroutine(TT());
        }

        private IEnumerator TT()
        {
            yield return new WaitForSeconds(3f);
            OpenTreasure();
            yield return new WaitForSeconds(3f);
            CloseTreasure();
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
