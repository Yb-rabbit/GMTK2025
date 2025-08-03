using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class youxikongzhi : MonoBehaviour
{
    public static bool CanStart;
   // public island[] island;
    public GameObject[] island;
    island isa;
    public GameObject startIsland;
    //public GameObject []StartPoint;
    int i = 0;
    public Collider player, center,center1;
    float time;
    public float timer = 45;
    public float jishi;
    public Canvas canvas;
    public Image tiao;
    public GameObject islandPoint;//产岛点
    // Start is called before the first frame update
    void Start()
    {
        CanStart = false;
        time = timer;
        isa=startIsland.GetComponent<island>();
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
            i = Random.Range(0, 3);
            if (island[i] != null)
            {
                if (time < 50/7)
                {
                    GameObject newobj= Instantiate(island[i], islandPoint.transform.position, Quaternion.identity);
                    isa=newobj.GetComponent<island>();
                }
            }
            if(time<0)
            {
               
                if (island[i]==null)
                {
                    SceneManager.LoadScene(0);
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
                Destroy(isa.StartPoint.gameObject);
            if (isa.StartPoint == null)
            {
                CanStart = true;
                canvas.enabled = false;
                Physics.IgnoreCollision(player, center, false);//玩家不可呆在内圈
                Physics.IgnoreCollision(player, center1, false);
                if(isa!=null)
                    isa.TurnDown();
                i++;
            }
        }
    }
}
