using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class youxikongzhi : MonoBehaviour
{
    public static bool CanStart;
    public island[] island;
    public GameObject []StartPoint;
    int i = 0;
    public Collider player, center,center1;
    float time;
    public float timer = 45;
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
        
        if(CanStart)
        {
            time -= Time.deltaTime;
            if(timer-time>1f)
            {
                Physics.IgnoreCollision(player, center1, true);//玩家可以移动
            }
            if(time<0)
            {
                time = timer;
                CanStart = false;
                Physics.IgnoreCollision(player, center, true);
                island[i].TurnUp();
            }
        }
        else
        {
            if (StartPoint[i] == null)
            {
                CanStart = true;
                Physics.IgnoreCollision(player, center, false);//玩家不可呆在内圈
                Physics.IgnoreCollision(player, center1, false);
                island[i].TurnDown();
                i++;
            }
        }
    }
}
