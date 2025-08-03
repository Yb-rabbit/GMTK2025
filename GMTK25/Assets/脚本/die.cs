using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Yumihoshi.Managers;

public class die : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void died()
    {
        GameManager.Instance.OnReloadGameEvent.Invoke();
        Scene currentScene = SceneManager.GetActiveScene();

        // ���¼��ص�ǰ����
        SceneManager.LoadScene(currentScene.name);
    }
}
