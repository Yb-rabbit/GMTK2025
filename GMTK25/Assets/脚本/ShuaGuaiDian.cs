using AmplifyShaderEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuaGuaiDian : MonoBehaviour
{
    public GameObject enemy;
    public float time;
    float timer;
    public bool father;
    ShuaGuaiDian[] allScripts;
    // Start is called before the first frame update
    void Start()
    {
        timer = time;
        // 获取所有子物体上的A脚本
        if (father)
        {
            allScripts = GetComponentsInChildren<ShuaGuaiDian>(true);

            if (allScripts.Length == 0) return;

           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (father&&youxikongzhi.CanStart)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = time;
                // 随机选择一个
                ShuaGuaiDian randomScript = allScripts[Random.Range(0, allScripts.Length)];

                // 调用函数
                randomScript.Invoke("GiveEnemy", 0f);
            }
        }
    }
    public void GiveEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
