using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviChangeColor : MonoBehaviour
{
    public Platform _platform;

    public Material startMaterial;
    public Material endMaterial;

    Renderer rend;
    Material[] materials;
    bool go = false;


    bool sfxStopConnect = false;
    bool sfxStopDisconnect = false;
    private void Start()
    {
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

            if (!sfxStopConnect)
            {
                AudioManager.Instance.PlaySFX("ConnectSFX");
                sfxStopConnect = true;
            }
            sfxStopDisconnect = false;
        }
        else
        {
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = startMaterial;
            }
            rend.sharedMaterials = materials;


            if (!sfxStopDisconnect)
            {
                AudioManager.Instance.PlaySFX("DiconnectSFX");
                sfxStopDisconnect = true;
            }
            sfxStopConnect = false;
        }
    }

}
