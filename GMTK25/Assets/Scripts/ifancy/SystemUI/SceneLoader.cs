using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 通过场景名称加载场景
    public void LoadSceneByName(string sceneName)
    {
        // 检查场景是否在Build Settings中
        if (IsSceneInBuildSettings(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"场景 {sceneName} 不在Build Settings中，请添加后再试！");
        }
    }

    // 通过场景索引加载场景
    public void LoadSceneByIndex(int sceneIndex)
    {
        // 检查场景索引是否有效
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogError($"场景索引 {sceneIndex} 无效！");
        }
    }

    // 检查场景是否在Build Settings中
    private bool IsSceneInBuildSettings(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            if (path.Contains(sceneName))
            {
                return true;
            }
        }
        return false;
    }
}
