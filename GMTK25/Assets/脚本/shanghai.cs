using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shanghai : MonoBehaviour
{
    public float shang;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        eneHP HP=other.GetComponent<eneHP>();
        if(HP!=null )
        {
            HP.hurt(shang/2);
        }
    }
}
