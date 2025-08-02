using UnityEngine;
using UnityEngine.UI;

public class WindowController : MonoBehaviour
{
    // ������Ҫ���ƵĴ���
    public GameObject targetWindow;

    // ��ʼ��ʱ���ش��ڣ���ѡ��
    private void Start()
    {
        if (targetWindow != null)
        {
            targetWindow.SetActive(false);
        }
    }

    // ��ʾ����
    public void ShowWindow()
    {
        if (targetWindow != null)
        {
            targetWindow.SetActive(true);
        }
    }

    // ���ش���
    public void HideWindow()
    {
        if (targetWindow != null)
        {
            targetWindow.SetActive(false);
        }
    }

    // �л�������ʾ״̬����ʾ�����أ����ر���ʾ��
    public void ToggleWindow()
    {
        if (targetWindow != null)
        {
            targetWindow.SetActive(!targetWindow.activeSelf);
        }
    }
}
