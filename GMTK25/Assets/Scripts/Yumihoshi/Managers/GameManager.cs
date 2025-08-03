// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:02
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Base;
using UnityEngine.Events;

namespace Yumihoshi.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public UnityEvent OnReloadGameEvent { get; private set; } = new();
    }
}
