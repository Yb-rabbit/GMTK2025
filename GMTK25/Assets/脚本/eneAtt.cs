using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eneAtt : MonoBehaviour
{
    public float shanghai = 0;
    bool CanAtt;//为真时可以攻击
    public float AttTime=2;
    float time;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        time = AttTime;
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
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
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
 
}
