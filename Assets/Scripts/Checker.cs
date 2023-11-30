using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    
    public int x;
    public int color;

    private void Update()
    {
        color = GetComponentInParent<Platform>().color;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            if(other.GetComponent<Platform>().isConnected == true && color == other.GetComponent<Platform>().color)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
        }
    }
}
