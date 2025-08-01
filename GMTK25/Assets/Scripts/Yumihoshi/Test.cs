// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 15:39
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using UnityEngine;
using Yumihoshi.Managers;

namespace Yumihoshi
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log(ItemManager.Instance.WeaponDataSo.WeaponDataList[0].itemName);
        }
    }
}
