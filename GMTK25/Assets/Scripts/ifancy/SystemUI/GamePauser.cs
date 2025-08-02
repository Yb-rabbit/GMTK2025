using UnityEngine;

public class GamePauser : MonoBehaviour
{
    // 记录游戏当前是否暂停
    private bool isPaused = false;

    // 暂停游戏
    public void PauseGame()
    {
        // 设置时间缩放为0，使游戏逻辑暂停
        Time.timeScale = 0f;
        isPaused = true;
        // 可选：显示暂停菜单
        Debug.Log("游戏已暂停");
    }

    // 取消暂停游戏
    public void ResumeGame()
    {
        // 恢复时间缩放为1，使游戏逻辑继续
        Time.timeScale = 1f;
        isPaused = false;
        // 可选：隐藏暂停菜单
        Debug.Log("游戏已恢复");
    }

    // 切换暂停状态（暂停变恢复，恢复变暂停）
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
}
