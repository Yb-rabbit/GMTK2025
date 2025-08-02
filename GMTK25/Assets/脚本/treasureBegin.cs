using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasureBegin : MonoBehaviour
{
    public GameObject[] treasures;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var treasure in treasures) 
        {
            if (treasure == null)
            {
                Destroy(gameObject);
            }
        }
    }
}
