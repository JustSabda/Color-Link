using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviChangeColor : MonoBehaviour
{
    public Platform _platform;

    public float speed;
    public Material startMaterial;
    public Material endMaterial;
    float startTime;

    Renderer rend;

    public bool repeatble;

    bool go = false;
    bool activeBefore = false;
    private void Start()
    {
        startTime = Time.time;
        rend = GetComponent<Renderer>();

        rend.material = startMaterial;
    }

    private void Update()
    {
        
        if(_platform != null)
        {
            if (_platform.flagConneted == true)
            {
                go = true;
                activeBefore = true;
            }
            else
            {
                go = false;
            }

        }

        if (go)
        {
            if (!repeatble)
            {
                float lerp = (Time.time - startTime) * speed;
                rend.material.Lerp(startMaterial, endMaterial, lerp);
            }
            else
            {
                float lerp = (Mathf.Sin(Time.time - startTime) * speed);
                rend.material.Lerp(startMaterial, endMaterial, lerp);
            }

        }
        else if(activeBefore)
        {
            if (!repeatble)
            {
                float lerp = (Time.time - startTime) * speed;
                rend.material.Lerp(endMaterial, startMaterial, lerp);
            }
        }
    }

}
