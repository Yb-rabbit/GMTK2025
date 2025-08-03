// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 12:54
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using QFramework;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yumihoshi.Managers;
using Yumihoshi.MVC.Events.Inventory;
using Yumihoshi.MVC.Models.Inventory;
using Yumihoshi.SO.Item;
using Yumihoshi.SO.Item.Weapon;

namespace Yumihoshi.UI
{
    public class InventoryUi : MonoBehaviour
    {
        [Header("Img组件")] [LabelText("手持物UI")] [SerializeField]
        private Image weaponImg;

        [LabelText("手持道具UI")] [SerializeField] private Image itemInHandImg;

        [LabelText("手持道具堆叠文本")] [SerializeField]
        private TextMeshProUGUI itemInHandStackTmp;

        [LabelText("备用道具")] [SerializeField] private List<Image> spareItemImgs;

        [LabelText("备用道具堆叠文本")] [SerializeField]
        private List<TextMeshProUGUI> spareItemStackTmps;

        private void Start()
        {
            // 注册事件
            var model = InventoryManager.Instance.GetModel<InventoryModel>();
            model
                .CurActiveSpareItemSize
                .RegisterWithInitValue(SetSpareItemSize)
                .UnRegisterWhenGameObjectDestroyed(gameObject);
            model.Weapon
                .Register(WeaponChanged)
                .UnRegisterWhenGameObjectDestroyed(gameObject);
            InventoryManager.Instance.RegisterEvent<ItemInHandChangedEvent>(
                    HandleItemInHandChanged)
                .UnRegisterWhenGameObjectDestroyed(gameObject);
            InventoryManager.Instance.RegisterEvent<SpareItemChangedEvent>(
                SpareItemChanged).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void SpareItemChanged(SpareItemChangedEvent e)
        {
            for (var i = 0; i < e.newSpareItems.Count; i++)
                if (e.newSpareItems[i] != null)
                {
                    SetSpareItemImg(i, e.newSpareItems[i].itemIcon);
                    if (e.newSpareItems[i].currentStackCount > 1)
                    {
                        spareItemStackTmps[i].text =
                            e.newSpareItems[i].currentStackCount.ToString();
                        spareItemStackTmps[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        spareItemStackTmps[i].gameObject.SetActive(false);
                    }
                }
                else
                {
                    spareItemStackTmps[i].gameObject.SetActive(false);
                }
        }

        private void WeaponChanged(WeaponData weaponData)
        {
            SetWeaponImg(weaponData.itemIcon);
        }

        private void HandleItemInHandChanged(ItemInHandChangedEvent e)
        {
            BaseItemData itemData = e.newItem;
            if (itemData == null)
            {
                itemInHandImg.gameObject.SetActive(false);
                itemInHandStackTmp.gameObject.SetActive(false);
                return;
            }

            SetItemInHandImg(itemData.itemIcon);
            if (itemData.currentStackCount > 1)
            {
                itemInHandStackTmp.text = itemData.currentStackCount.ToString();
                itemInHandStackTmp.gameObject.SetActive(true);
            }
            else
            {
                itemInHandStackTmp.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// 设置手持道具图片
        /// </summary>
        /// <param name="sprite"></param>
        public void SetWeaponImg(Sprite sprite)
        {
            weaponImg.sprite = sprite;
            weaponImg.gameObject.SetActive(true);
        }

        /// <summary>
        /// 设置手持物品图片
        /// </summary>
        /// <param name="sprite"></param>
        public void SetItemInHandImg(Sprite sprite)
        {
            itemInHandImg.sprite = sprite;
            itemInHandImg.gameObject.SetActive(true);
        }

        /// <summary>
        /// 设置备用道具图片
        /// </summary>
        /// <param name="index"></param>
        /// <param name="sprite"></param>
        public void SetSpareItemImg(int index, Sprite sprite)
        {
            if (index < 0 || index >= spareItemImgs.Count)
            {
                Debug.LogError($"索引{index}超出备用道具图片列表范围");
                return;
            }

            spareItemImgs[index].sprite = sprite;
            spareItemImgs[index].color = Color.white;
        }

        private void SetSpareItemSize(int count)
        {
            if (count > spareItemImgs.Count)
            {
                Debug.LogWarning("备用道具超过最大值");
                return;
            }

            for (var i = 0; i < count; i++)
            {
                spareItemImgs[i].gameObject.SetActive(true);
                if (!spareItemImgs[i].sprite)
                    spareItemImgs[i].color = Color.clear;
            }
        }
    }
}
