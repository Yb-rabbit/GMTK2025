using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camShark : MonoBehaviour
{
    public  bool zhendong;
    float cd = 0.02f;
    bool yici = true;
    public float tim = 0.02f;
    Vector3 originalCameraPosition;
    public float Speed;
    bool Jilu = true;
    // Start is called before the first frame update
    void Start()
    {
        originalCameraPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         if (zhendong)
         {
                    if(Jilu)
                    {
                        Jilu = false;
                        originalCameraPosition = transform.position;
                     }
            originalCameraPosition = new Vector3(transform.position.x,originalCameraPosition.y,transform.position.z);
            if (yici && cd > 0)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + Speed* Time.deltaTime, transform.position.z);
                        cd -= Time.deltaTime;
                    }
                    else
                    {
                        yici = false;
                        cd += Time.deltaTime;
                        if (cd > tim)
                        {
                            cd = tim;
                            yici = true;
                            zhendong = false;
                    transform.position = originalCameraPosition;
                    Jilu = true;
                }
                        else
                        {

                            transform.position = new Vector3(transform.position.x, transform.position.y - Speed/ 5 * Time.deltaTime, transform.position.z);
                        }
                    }
         }
    }
    public void StartZhen()
    {
        zhendong = true;
        transform.position = originalCameraPosition;
    }

}
