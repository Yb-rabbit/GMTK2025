using UnityEngine;

public class GameQuitter : MonoBehaviour
{
    // �˳���Ϸ����
    public void QuitGame()
    {
        // �ڱ༭��������ʱ���˳�����ģʽ
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ��ʵ�ʹ�������Ϸ�У��˳�Ӧ�ó���
        Application.Quit();
#endif
        Debug.Log("��Ϸ���˳�");
    }
}
