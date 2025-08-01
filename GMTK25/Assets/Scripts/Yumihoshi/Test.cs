// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 15:39
// @version: 1.0
// @description:
// *****************************************************************************

using UnityEngine;
using Yumihoshi.Managers;
using Yumihoshi.SO.Item.Consumable;

namespace Yumihoshi
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log(
                (ItemManager.Instance.ItemSoDict[ItemCategory.Consumable] as
                    ConsumableSo).ConsumableDataList[0].itemName);
        }
    }
}
