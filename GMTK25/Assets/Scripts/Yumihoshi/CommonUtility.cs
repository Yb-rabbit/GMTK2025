// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:01
// @version: 1.0
// @description: 共用工具类
// *****************************************************************************

using UnityEngine.SceneManagement;

namespace Yumihoshi
{
    public static class CommonUtility
    {
        /// <summary>
        /// 检测指定场景是否已加载
        /// </summary>
        /// <param name="sceneName">场景名</param>
        /// <returns></returns>
        public static bool IsSceneLoaded(string sceneName)
        {
            Scene scene = SceneManager.GetSceneByName(sceneName);
            return scene.IsValid() && scene.isLoaded;
        }

        /// <summary>
        /// 异步加载管理器场景，会自动检测是否已加载
        /// </summary>
        /// <param name="mono"></param>
        public static void LoadManagerScene()
        {
            if (IsManagerSceneLoaded()) return;
            SceneManager.LoadScene("ManagerScene", LoadSceneMode.Additive);
        }

        /// <summary>
        /// 检测是否加载了管理器场景
        /// </summary>
        /// <returns></returns>
        public static bool IsManagerSceneLoaded()
        {
            return IsSceneLoaded("ManagerScene");
        }
    }
}
