using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class island : MonoBehaviour
{
    public GameObject UP, Down, islan;
    int i;//Ϊ0ʱ������1���£�2����
    public float movespeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (i)
        {
            case 1:
                // �����ƶ�����

                Vector3 direction = (Down.transform.position - islan.transform.position).normalized;

                // �ƶ�����
                islan.transform.position += direction * movespeed * Time.deltaTime;
                break;
            case 2:
                float distance = Vector3.Distance(islan.transform.position, UP.transform.position);
                if (distance > 1f)
                // �����ƶ�����
                {
                    Vector3 direction1 = (UP.transform.position - islan.transform.position).normalized;

                    // �ƶ�����
                    islan.transform.position += direction1 * movespeed * Time.deltaTime;
                }
                break;
        }

    }
   public void TurnUp()
    {
        i = 2;
    }
    public void TurnDown()
    {
        i = 1;
    }
}
