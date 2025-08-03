using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Scene currentScene = SceneManager.GetActiveScene();

        // 重新加载当前场景
        SceneManager.LoadScene(currentScene.name);
    }
}
