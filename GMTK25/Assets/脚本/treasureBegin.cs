using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasureBegin : MonoBehaviour
{
    public GameObject[] treasures;
    public bool OnlyTakeOne=true;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OnlyTakeOne)
        {
            foreach (var treasure in treasures)
            {
                if (treasure == null)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            i = 0;
            foreach (var treasure in treasures)
            {
                if (treasure == null)
                {
                    i++;
                    
                }
                if(i == treasures.Length)
                    Destroy(gameObject);
            }
        }
    }
}
