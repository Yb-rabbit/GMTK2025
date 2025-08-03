using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class youxikongzhi : MonoBehaviour
{
    public static bool CanStart;
    public island[] island;
    public GameObject []StartPoint;
    int i = 0;
    public Collider player, center,center1;
    float time;
    public float timer = 45;
    public float jishi;
    public Canvas canvas;
    public Image tiao;
    // Start is called before the first frame update
    void Start()
    {
        CanStart = false;
        time = timer;
        Physics.IgnoreCollision(player, center, true);
        Physics.IgnoreCollision(player, center1, true);
    }

    // Update is called once per frame
    void Update()
    {
        tiao.fillAmount = (float)(25-jishi) / 25;
        if (CanStart)
        {
            time -= Time.deltaTime;
            if(timer-time>1f)
            {
                Physics.IgnoreCollision(player, center1, true);//玩家可以移动
            }
            if (island[i] != null)
            {
                if (time < island[i].time)
                {
                    island[i].TurnUp();
                }
            }
            if(time<0)
            {
               
                if (island[i]==null)
                {
                    Debug.Log("通过");
                }
                else
                {
                    time = timer;
                    CanStart = false;
                    jishi = 0;
                    canvas.enabled = true;
                    Physics.IgnoreCollision(player, center, true);
                }
              
            }
        }
        else
        {
            jishi += Time.deltaTime;
            if(jishi>25)
                Destroy(StartPoint[i]);
            if (StartPoint[i] == null)
            {
                CanStart = true;
                canvas.enabled = false;
                Physics.IgnoreCollision(player, center, false);//玩家不可呆在内圈
                Physics.IgnoreCollision(player, center1, false);
                island[i].TurnDown();
                i++;
            }
        }
    }
}
