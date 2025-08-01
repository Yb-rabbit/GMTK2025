// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/07/30 11:59
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using UnityEngine;
using Yumihoshi.Utility;

namespace Yumihoshi
{
    public class LoadManager : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log(nameof(ResKit.Init));
#if !UNITY_EDITOR
            ResKit.Init();
#endif
            CommonUtility.LoadManagerScene();
        }
    }
}
