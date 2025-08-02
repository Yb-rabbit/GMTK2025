using QFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // ͨ���������Ƽ��س���
    public void LoadSceneByName(string sceneName)
    {
        // ��鳡���Ƿ���Build Settings��
        if (IsSceneInBuildSettings(sceneName))
        {
            Time.timeScale = 1f;
            ActionKit.ScreenTransition.FadeInOut()
                .OnInFinish(() => SceneManager.LoadScene(sceneName))
                .Start(this);
        }
        else
        {
            Debug.LogError($"���� {sceneName} ����Build Settings�У�����Ӻ����ԣ�");
        }
    }

    // ͨ�������������س���
    public void LoadSceneByIndex(int sceneIndex)
    {
        // ��鳡�������Ƿ���Ч
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogError($"�������� {sceneIndex} ��Ч��");
        }
    }

    // ��鳡���Ƿ���Build Settings��
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
