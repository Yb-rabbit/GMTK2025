using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiQuDaoJu : MonoBehaviour
{
    bool CanHuDong;//Ϊ��ʱ�����Ի���
    public  int id;//��ʰȡ��Ʒ��id
    BagShow []b;
    bool empty;//Ϊ��ʱ���п�λ�����Է�����Ʒ
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        b=new BagShow[4];
        b[0]=GameObject.Find("11").GetComponent<BagShow>();
        b[1]= GameObject.Find("22").GetComponent<BagShow>();
        b[2] = GameObject.Find("33").GetComponent<BagShow>();
        b[3]= GameObject.Find("44").GetComponent<BagShow>();
        canvas=GameObject.Find("������UI").GetComponent<Canvas>();
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
                    if(bag.i==0)//�п�λ��ֱ�ӷ���
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
