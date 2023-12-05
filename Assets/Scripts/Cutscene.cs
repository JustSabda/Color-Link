using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public GameObject theCutscenes;
    public GameObject[] imgCutscene;

    int imgNumber = 0;
    void Start()
    {
        ImgToArray();
        for (int i = 0; i < imgCutscene.Length; i++)
        {
            imgCutscene[i].SetActive(false);
        }
      
    }

    public void openImage()
    {
        if (imgNumber != imgCutscene.Length)
        {
            imgCutscene[imgNumber].SetActive(true);
            imgNumber++;
        }
        else
        {
            SceneLoad.Instance.NextLevel();
        }
    }

    void ImgToArray()
    {
        int childCount = theCutscenes.transform.childCount;
        imgCutscene = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
        {
            imgCutscene[i] = theCutscenes.transform.GetChild(i).gameObject;
        }
    }
}
