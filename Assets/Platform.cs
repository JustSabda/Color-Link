using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{


    public bool isGenerator;
    public bool isConnected;
    public int color;

    

    public Checker[] checker;

    private int x1,x2,x3,x4;

    public bool flagConneted;
    public bool isFlag;
   

    // Start is called before the first frame update
    void Start()
    {
        flagConneted = false;
    }

    // Update is called once per frame
    void Update()
    {
        x1 = checker[0].x;
        x2 = checker[1].x;
        x3 = checker[2].x;
        x4 = checker[3].x;

        if (isGenerator)
        {
            isConnected = true;
            
        }
        else
        {
            if ((x1 + x2 + x3 + x4) > 0)
            {
                isConnected = true;
                
            }
            else
            {
                isConnected = false;
            }

        }
        if(isFlag && isConnected)
        {
            flagConneted = true;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        /*
        if (other.gameObject.CompareTag("Platform"))
        {
            if (other.GetComponent<Platform>().connected == true && color == other.GetComponent<Platform>().color)
            {
                connected = true;
                x = true;
            }
            else
            {
                x = false;
            }
            
        }

        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isGenerator)
        {
            if (other.GetComponent<GridMovement>().hadFlag == true)
            {
                color = other.GetComponent<GridMovement>().colorFlag;
            }
        }
    }
}
