using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Yumihoshi.Managers;

public class die : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.OnReloadGameEvent.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void died()
    {
        Debug.Log("123");
        GameManager.Instance.OnReloadGameEvent.Invoke();
        Scene currentScene = SceneManager.GetActiveScene();
        ActionKit.ScreenTransition.FadeInOut().OnInFinish(() =>
        {
            SceneManager.LoadScene(currentScene.name);
        }).Start(this);
        // ���¼��ص�ǰ����
        //SceneManager.LoadScene(currentScene.name);
    }
}
