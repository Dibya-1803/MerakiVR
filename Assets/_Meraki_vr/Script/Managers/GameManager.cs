using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   

    private int CurrentProjectIndex { get => PlayerPrefs.GetInt("projectIndex",0); set => PlayerPrefs.SetInt("projectIndex",value); }
    private int CurrentProjectAreaIndex { get => PlayerPrefs.GetInt("projectAreaIndex",0); set => PlayerPrefs.SetInt("projectAreaIndex",value); }

    public GameObject vr_objects;
    public MeshRenderer vr_mesh;

    private void Start()
    {
        Singleton.Instance.UIManager.LoadPanelByName(Constant.panel_intro);
        vr_objects.SetActive(false);
    }

    internal int GetCurrentProjectIndex()
    {
        return CurrentProjectIndex;
    }
    internal void SetCurrentProjectIndex(int index)
    {
         CurrentProjectIndex=index;
    } 
    internal int GetCurrentProjectAreaIndex()
    {
        return CurrentProjectAreaIndex;
    }
    internal void SetCurrentProjectAreaIndex(int index)
    {
         CurrentProjectAreaIndex=index;
    }

    internal void LoadVRSphare()
    {
        Singleton.Instance.UIManager.LoadPanelByName(Constant.panel_vr_page);
        vr_objects.SetActive(true);
        vr_mesh.material = Singleton.Instance.dataManager.itemDetailList[GetCurrentProjectIndex()].areaDetails[GetCurrentProjectAreaIndex()].vr_Mat;
    }
}
