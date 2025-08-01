using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// �������ع����������𳡾��л����˳���Ϸ����
/// </summary>
public class SceneLoader : MonoBehaviour
{
    [Header("���ؽ�������")]
    [Tooltip("���س���ʱ��ʾ�����")]
    public GameObject loadingPanel;
    [Tooltip("���ؽ�����")]
    public Slider loadingSlider;
    [Tooltip("���ؽ����ı�")]
    public Text progressText;

    private static SceneLoader _instance;

    // ����ģʽ��ȷ��������ֻ��һ��SceneLoaderʵ��
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
        // ȷ���л�����ʱ�����ٴ˶���
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // ��ʼ���������״̬
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(false);
        }
    }

    /// <summary>
    /// ͨ���������Ƽ��س���
    /// </summary>
    /// <param name="sceneName">Ҫ���صĳ�������</param>
    public void LoadScene(string sceneName)
    {
        // ��鳡���Ƿ���Build Settings��
        if (!IsSceneInBuildSettings(sceneName))
        {
            Debug.LogError($"���� {sceneName} ����Build Settings�У�����Ӻ����ԣ�");
            return;
        }

        // ��ʾ�������
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(true);
        }

        // �첽���س���
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    /// <summary>
    /// ͨ�������������س���
    /// </summary>
    /// <param name="sceneIndex">Ҫ���صĳ�������</param>
    public void LoadScene(int sceneIndex)
    {
        // ��鳡�������Ƿ���Ч
        if (sceneIndex < 0 || sceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError($"�������� {sceneIndex} ��Ч��");
            return;
        }

        // ��ʾ�������
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(true);
        }

        // �첽���س���
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    /// <summary>
    /// �첽���س��������½���
    /// </summary>
    private System.Collections.IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // ����ֵ��0.9ʱ��ֹͣ����Ҫ���⴦��
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            // ���½��������ı�
            if (loadingSlider != null)
                loadingSlider.value = progress;

            if (progressText != null)
                progressText.text = $"{(int)(progress * 100)}%";

            // �����ȴﵽ100%ʱ����������
            if (progress >= 1.0f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        // ���ؼ������
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(false);
        }
    }

    /// <summary>
    /// �첽���س��������½��ȣ�ͨ��������
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
    /// �˳���Ϸ
    /// </summary>
    public void QuitGame()
    {
        // �ڱ༭�����˳�����ģʽ
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ��ʵ������ʱ�˳�Ӧ��
        Application.Quit();
#endif
    }

    /// <summary>
    /// ��鳡���Ƿ���Build Settings��
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
