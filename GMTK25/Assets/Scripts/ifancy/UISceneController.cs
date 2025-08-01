using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI���������������ڰ�UI��ť�¼����������ع���
/// </summary>
public class UISceneController : MonoBehaviour
{
    [Header("������������")]
    [Tooltip("����Ϸ��������")]
    public string gameSceneName = "GameScene";
    [Tooltip("���˵���������")]
    public string menuSceneName = "MenuScene";

    [Header("��ť����")]
    [Tooltip("��ʼ��Ϸ��ť")]
    public Button startButton;
    [Tooltip("���ز˵���ť")]
    public Button backToMenuButton;
    [Tooltip("�˳���Ϸ��ť")]
    public Button quitButton;

    private void Awake()
    {
        // �󶨰�ť�¼�
        if (startButton != null)
            startButton.onClick.AddListener(OnStartGameClicked);

        if (backToMenuButton != null)
            backToMenuButton.onClick.AddListener(OnBackToMenuClicked);

        if (quitButton != null)
            quitButton.onClick.AddListener(OnQuitClicked);
    }

    /// <summary>
    /// ��ʼ��Ϸ��ť����¼�
    /// </summary>
    private void OnStartGameClicked()
    {
        if (!string.IsNullOrEmpty(gameSceneName))
        {
            SceneLoader.Instance.LoadScene(gameSceneName);
        }
        else
        {
            Debug.LogError("��������Ϸ�������ƣ�");
        }
    }

    /// <summary>
    /// ���ز˵���ť����¼�
    /// </summary>
    private void OnBackToMenuClicked()
    {
        if (!string.IsNullOrEmpty(menuSceneName))
        {
            SceneLoader.Instance.LoadScene(menuSceneName);
        }
        else
        {
            Debug.LogError("�����ò˵��������ƣ�");
        }
    }

    /// <summary>
    /// �˳���Ϸ��ť����¼�
    /// </summary>
    private void OnQuitClicked()
    {
        SceneLoader.Instance.QuitGame();
    }
}
