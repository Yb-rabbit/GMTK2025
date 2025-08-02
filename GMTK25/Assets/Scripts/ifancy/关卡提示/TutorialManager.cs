using UnityEngine;

public class TutorialStarter : MonoBehaviour
{
    // 教程窗口UI
    public GameObject tutorialWindow;

    private void Start()
    {
        // 确保教程窗口引用已赋值
        if (tutorialWindow != null)
        {
            // 场景启动时显示教程窗口
            tutorialWindow.SetActive(true);

            // 暂停游戏
            Time.timeScale = 0f;
            Debug.Log("游戏已暂停，显示教程");
        }
        else
        {
            Debug.LogError("请在Inspector中指定教程窗口");
        }
    }

    // 继续游戏并隐藏教程窗口
    public void ContinueGame()
    {
        if (tutorialWindow != null)
        {
            // 隐藏教程窗口
            tutorialWindow.SetActive(false);

            // 恢复游戏运行
            Time.timeScale = 1f;
            Debug.Log("继续游戏");
        }
    }
}
