using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagChosed : MonoBehaviour
{
    Image image;
    public BagShow[] bags;
    Text text;
    bool only = true;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(only)
        {
            only=false;
            if (image != null)
            {
                image.sprite = bags[0].spp;
            }
            if (text != null)
            {
                text.text = bags[0].word;
            }
        }
        foreach (var bag in bags)
        {
            if(bag.Onder)
            {
                if(image != null)
                {
                    image.sprite = bag.spp;
                }
                if(text != null)
                {
                    text.text = bag.word;
                }
            }
        }
    }
}
