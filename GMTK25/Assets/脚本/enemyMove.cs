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
    public SpriteRenderer sp1, sp2;
    eneHP hp;
    eneAtt att;
    // Start is called before the first frame update
    void Start()
    {
        cat=GameObject.Find(Playername);
        hp = GetComponent<eneHP>();  
        att=GetComponent<eneAtt>();
      //  rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp.hp > 0)
        {
            transform.rotation = cat.transform.rotation;
            if (cat != null)
            {
                float distance = Vector3.Distance(transform.position, cat.transform.position);
                if (transform.position.x < cat.transform.position.x)
                {
                    sp1.enabled = true;
                    sp2.enabled = false;
                }
                else if (transform.position.x > cat.transform.position.x)
                {
                    sp1.enabled = false;
                    sp2.enabled = true;
                }
                // 如果距离大于停止距离，则继续移动
                if (distance > stopDis)
                {
                    // 计算移动方向
                    Vector3 direction = (cat.transform.position - transform.position).normalized;

                    // 移动物体
                    transform.position += direction * movespeed * Time.deltaTime;
                }
                else
                {
                   // att.attDiaoYong();
                }
            }
        }
    }
}
