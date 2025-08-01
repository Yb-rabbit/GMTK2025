using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AOBlit : MonoBehaviour
{
    public Material AOMaterial;

    private void Awake()
    {
        GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (AOMaterial != null)
        {
            Graphics.Blit(source, destination, AOMaterial);
        }
    }
}
