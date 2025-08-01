using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiQuDaoJu : MonoBehaviour
{
    bool CanHuDong;//为真时，可以互动
    public  int id;//待拾取物品的id
    BagShow []b;
    bool empty;//为真时，有空位，可以放下物品
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        b=new BagShow[4];
        b[0]=GameObject.Find("11").GetComponent<BagShow>();
        b[1]= GameObject.Find("22").GetComponent<BagShow>();
        b[2] = GameObject.Find("33").GetComponent<BagShow>();
        b[3]= GameObject.Find("44").GetComponent<BagShow>();
        canvas=GameObject.Find("换道具UI").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CanHuDong)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                empty = false;
                foreach (var bag in b)
                {
                    if(bag.i==0)//有空位，直接放下
                    {
                        empty=true;
                        bag.i = id;
                        gameObject.SetActive(false);
                        break;
                    }
                }
                if(!empty)
                {
                    canvas.enabled = true;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="cat")
            CanHuDong = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "cat")
            CanHuDong = false;
    }
}
