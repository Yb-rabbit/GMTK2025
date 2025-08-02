using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemyMove : MonoBehaviour
{
    string Playername = "cat";
    GameObject cat;
    //Rigidbody rb;
    public float movespeed = 2;
    public float stopDis;
    // Start is called before the first frame update
    void Start()
    {
        cat=GameObject.Find(Playername);
      //  rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation=cat.transform.rotation;
        if (cat != null)
        {
            float distance = Vector3.Distance(transform.position, cat.transform.position);

            // 如果距离大于停止距离，则继续移动
            if (distance > stopDis)
            {
                // 计算移动方向
                Vector3 direction = (cat.transform.position - transform.position).normalized;

                // 移动物体
                transform.position += direction * movespeed * Time.deltaTime;
            }
        }
    }
}
