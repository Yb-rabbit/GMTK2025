using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diaoluo : MonoBehaviour
{
    GameObject player;
    create cre;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("cat");
        cre=player.GetComponent<create>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name=="cat")
            cre.canmove = false;
    }
}
