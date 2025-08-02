using UnityEngine;

public class GameQuitter : MonoBehaviour
{
    // 退出游戏方法
    public void QuitGame()
    {
        // 在编辑器中运行时，退出播放模式
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 在实际构建的游戏中，退出应用程序
        Application.Quit();
#endif
        Debug.Log("游戏已退出");
    }
}
