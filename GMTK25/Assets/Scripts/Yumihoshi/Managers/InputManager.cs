// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:04
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Yumihoshi.Managers
{
    public class InputManager : Singleton<InputManager>
    {
        private void OnOpenCloseTreasure(InputValue value)
        {
            if (!value.isPressed) return;
            Debug.Log("Open/Close Treasure");
        }
    }
}
