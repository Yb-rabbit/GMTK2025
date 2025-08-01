using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 场景加载管理器，负责场景切换和退出游戏功能
/// </summary>
public class SceneLoader : MonoBehaviour
{
    [Header("加载界面设置")]
    [Tooltip("加载场景时显示的面板")]
    public GameObject loadingPanel;
    [Tooltip("加载进度条")]
    public Slider loadingSlider;
    [Tooltip("加载进度文本")]
    public Text progressText;

    private static SceneLoader _instance;

    // 单例模式，确保场景中只有一个SceneLoader实例
    public static SceneLoader Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SceneLoader>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("SceneLoader");
                    _instance = obj.AddComponent<SceneLoader>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // 确保切换场景时不销毁此对象
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // 初始化加载面板状态
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(false);
        }
    }

    /// <summary>
    /// 通过场景名称加载场景
    /// </summary>
    /// <param name="sceneName">要加载的场景名称</param>
    public void LoadScene(string sceneName)
    {
        // 检查场景是否在Build Settings中
        if (!IsSceneInBuildSettings(sceneName))
        {
            Debug.LogError($"场景 {sceneName} 不在Build Settings中，请添加后再试！");
            return;
        }

        // 显示加载面板
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(true);
        }

        // 异步加载场景
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    /// <summary>
    /// 通过场景索引加载场景
    /// </summary>
    /// <param name="sceneIndex">要加载的场景索引</param>
    public void LoadScene(int sceneIndex)
    {
        // 检查场景索引是否有效
        if (sceneIndex < 0 || sceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError($"场景索引 {sceneIndex} 无效！");
            return;
        }

        // 显示加载面板
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(true);
        }

        // 异步加载场景
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    /// <summary>
    /// 异步加载场景并更新进度
    /// </summary>
    private System.Collections.IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // 进度值在0.9时会停止，需要特殊处理
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            // 更新进度条和文本
            if (loadingSlider != null)
                loadingSlider.value = progress;

            if (progressText != null)
                progressText.text = $"{(int)(progress * 100)}%";

            // 当进度达到100%时允许场景激活
            if (progress >= 1.0f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        // 隐藏加载面板
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(false);
        }
    }

    /// <summary>
    /// 异步加载场景并更新进度（通过索引）
    /// </summary>
    private System.Collections.IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if (loadingSlider != null)
                loadingSlider.value = progress;

            if (progressText != null)
                progressText.text = $"{(int)(progress * 100)}%";

            if (progress >= 1.0f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        if (loadingPanel != null)
        {
            loadingPanel.SetActive(false);
        }
    }

    /// <summary>
    /// 退出游戏
    /// </summary>
    public void QuitGame()
    {
        // 在编辑器中退出播放模式
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 在实际运行时退出应用
        Application.Quit();
#endif
    }

    /// <summary>
    /// 检查场景是否在Build Settings中
    /// </summary>
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
