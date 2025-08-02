// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 14:47
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yumihoshi.Managers;

namespace Yumihoshi.UI
{
    public class ItemPickPanelUi : MonoBehaviour
    {
        [Header("组件")]
        [LabelText("物品图片")] [SerializeField] private Image itemImg;

        [LabelText("物品名文本")] [SerializeField] private TextMeshProUGUI itemTmp;
        [LabelText("物品描述文本")] [SerializeField] private TextMeshProUGUI itemDescTmp;
        [LabelText("拾取按钮")] [SerializeField] private Button pickBtn;

        private void Start()
        {
            pickBtn.onClick.AddListener(InputManager.Instance.Pick);
        }

        /// <summary>
        /// 设置物品图片
        /// </summary>
        /// <param name="sprite"></param>
        public void SetItemImg(Sprite sprite)
        {
            itemImg.sprite = sprite;
        }
        
        /// <summary>
        /// 设置物品名称
        /// </summary>
        /// <param name="itemName"></param>
        public void SetItemName(string itemName)
        {
            itemTmp.text = itemName;
        }
        
        /// <summary>
        /// 设置物品描述
        /// </summary>
        /// <param name="itemDesc"></param>
        public void SetItemDesc(string itemDesc)
        {
            itemDescTmp.text = itemDesc;
        }
    }
}
