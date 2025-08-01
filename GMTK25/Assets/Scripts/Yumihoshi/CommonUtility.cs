// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 12:01
// @version: 1.0
// @description: 共用工具类
// *****************************************************************************

using System.Collections;
using UnityEngine;
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
        public static void LoadManagerScene(MonoBehaviour mono)
        {
            if (IsManagerSceneLoaded()) return;
            mono.StartCoroutine(LoadManagerSceneAsync());
        }

        /// <summary>
        /// 检测是否加载了管理器场景
        /// </summary>
        /// <returns></returns>
        private static bool IsManagerSceneLoaded()
        {
            return IsSceneLoaded("ManagerScene");
        }

        private static IEnumerator LoadManagerSceneAsync()
        {
            if (IsManagerSceneLoaded()) yield break;
            AsyncOperation asyncOp =
                SceneManager.LoadSceneAsync("ManagerScene",
                    LoadSceneMode.Additive);

            if (asyncOp == null)
            {
                Debug.LogError("管理器场景加载失败");
                yield break;
            }

            asyncOp.allowSceneActivation = true;
            var timer = 0f;
            while (!asyncOp.isDone)
            {
                timer += Time.deltaTime;
                if (timer >= 5f)
                    Debug.LogWarning("管理器场景加载超时，可能需要检查场景配置或资源");
                yield return null;
            }

            Debug.Log("管理器场景加载完成");
        }
    }
}
