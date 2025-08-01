using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI场景控制器，用于绑定UI按钮事件到场景加载功能
/// </summary>
public class UISceneController : MonoBehaviour
{
    [Header("场景名称设置")]
    [Tooltip("主游戏场景名称")]
    public string gameSceneName = "GameScene";
    [Tooltip("主菜单场景名称")]
    public string menuSceneName = "MenuScene";

    [Header("按钮引用")]
    [Tooltip("开始游戏按钮")]
    public Button startButton;
    [Tooltip("返回菜单按钮")]
    public Button backToMenuButton;
    [Tooltip("退出游戏按钮")]
    public Button quitButton;

    private void Awake()
    {
        // 绑定按钮事件
        if (startButton != null)
            startButton.onClick.AddListener(OnStartGameClicked);

        if (backToMenuButton != null)
            backToMenuButton.onClick.AddListener(OnBackToMenuClicked);

        if (quitButton != null)
            quitButton.onClick.AddListener(OnQuitClicked);
    }

    /// <summary>
    /// 开始游戏按钮点击事件
    /// </summary>
    private void OnStartGameClicked()
    {
        if (!string.IsNullOrEmpty(gameSceneName))
        {
            SceneLoader.Instance.LoadScene(gameSceneName);
        }
        else
        {
            Debug.LogError("请设置游戏场景名称！");
        }
    }

    /// <summary>
    /// 返回菜单按钮点击事件
    /// </summary>
    private void OnBackToMenuClicked()
    {
        if (!string.IsNullOrEmpty(menuSceneName))
        {
            SceneLoader.Instance.LoadScene(menuSceneName);
        }
        else
        {
            Debug.LogError("请设置菜单场景名称！");
        }
    }

    /// <summary>
    /// 退出游戏按钮点击事件
    /// </summary>
    private void OnQuitClicked()
    {
        SceneLoader.Instance.QuitGame();
    }
}
