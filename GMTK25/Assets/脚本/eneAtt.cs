using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eneAtt : MonoBehaviour
{
    public float shanghai = 0;
    public bool CanAtt;//为真时可以攻击
    public float AttTime=2;
    float time;
    GameObject player;
    public Animator anim1, anim2;
    eneHP hp;
    // Start is called before the first frame update
    void Start()
    {
        hp=GetComponent< eneHP>();
        time = AttTime;
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        if(CanAtt)
        {
            time-=Time.deltaTime;
            if(time < 0)
            {
                hp hpp = player.gameObject.GetComponent<hp>();
                anim1.SetTrigger("attack");
                anim2.SetTrigger("attack");
                hpp.GetAtted(shanghai);
                time = AttTime;
                CanAtt = false;
            }
        }
    }
  /*  private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            CanAtt = true;

        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // player = other.gameObject;
            CanAtt = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (player != null)
        {
            if (other.gameObject.name == player.name)
            {

                CanAtt = false;

            }
        }
    }
    public void Attack()
    {
        if (hp.hp > 0)
        {
            hp hpp = player.gameObject.GetComponent<hp>();
            hpp.GetAtted(shanghai);
        }
    }
    /*public void attDiaoYong()
    {
        hp hpp = player.gameObject.GetComponent<hp>();
        anim1.SetTrigger("attack");
        anim2.SetTrigger("attack");
        hpp.GetAtted(shanghai);
        time = AttTime;
        CanAtt = false;
    }*/
}
