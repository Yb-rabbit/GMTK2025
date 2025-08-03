
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
        // ��ȡ�����������ϵ�A�ű�
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
                // ���ѡ��һ��
                ShuaGuaiDian randomScript = allScripts[Random.Range(0, allScripts.Length)];

                // ���ú���
                randomScript.Invoke("GiveEnemy", 0f);
            }
        }
    }
    public void GiveEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
