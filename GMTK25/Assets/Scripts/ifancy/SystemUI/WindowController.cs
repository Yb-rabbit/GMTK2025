using UnityEngine;
using UnityEngine.UI;

public class WindowController : MonoBehaviour
{
    // 引用需要控制的窗口
    public GameObject targetWindow;

    // 初始化时隐藏窗口（可选）
    private void Start()
    {
        if (targetWindow != null)
        {
            targetWindow.SetActive(false);
        }
    }

    // 显示窗口
    public void ShowWindow()
    {
        if (targetWindow != null)
        {
            targetWindow.SetActive(true);
        }
    }

    // 隐藏窗口
    public void HideWindow()
    {
        if (targetWindow != null)
        {
            targetWindow.SetActive(false);
        }
    }

    // 切换窗口显示状态（显示变隐藏，隐藏变显示）
    public void ToggleWindow()
    {
        if (targetWindow != null)
        {
            targetWindow.SetActive(!targetWindow.activeSelf);
        }
    }
}
