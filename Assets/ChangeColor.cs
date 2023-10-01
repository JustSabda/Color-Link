using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    public Material[] material;
    public int x;
    Renderer rend;

    private Platform platform;

    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<Platform>();
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

    // Update is called once per frame
    void Update()
    {

        if (x < 0 || x > material.Length)
        {
            x = 0;
            return;
            
        }

        rend.sharedMaterial = material[x];
        x = platform.color;




    }
}
