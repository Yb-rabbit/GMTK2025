using UnityEngine;

public class GamePauser : MonoBehaviour
{
    // ��¼��Ϸ��ǰ�Ƿ���ͣ
    private bool isPaused = false;

    // ��ͣ��Ϸ
    public void PauseGame()
    {
        // ����ʱ������Ϊ0��ʹ��Ϸ�߼���ͣ
        Time.timeScale = 0f;
        isPaused = true;
        // ��ѡ����ʾ��ͣ�˵�
        Debug.Log("��Ϸ����ͣ");
    }

    // ȡ����ͣ��Ϸ
    public void ResumeGame()
    {
        // �ָ�ʱ������Ϊ1��ʹ��Ϸ�߼�����
        Time.timeScale = 1f;
        isPaused = false;
        // ��ѡ��������ͣ�˵�
        Debug.Log("��Ϸ�ѻָ�");
    }

    // �л���ͣ״̬����ͣ��ָ����ָ�����ͣ��
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
