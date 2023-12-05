using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviChangeColor : MonoBehaviour
{
    public Platform _platform;

    public Material startMaterial;
    public Material endMaterial;
    float startTime;

    Renderer rend;
    Material[] materials;
    bool go = false;
    bool activeBefore = false;
    private void Start()
    {
        startTime = Time.time;
        rend = GetComponent<Renderer>();

        materials = GetComponent<Renderer>().sharedMaterials;
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = startMaterial;
        }

        rend.sharedMaterials = materials;
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

            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = endMaterial;
            }
            rend.sharedMaterials = materials;

        }
        else
        {
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = startMaterial;
            }
            rend.sharedMaterials = materials;
        }
    }

}
