using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    internal List<ExploreItemDetails> itemDetailList;
}
[System.Serializable]
public struct ExploreItemDetails
{
    public string projectName;
    public Sprite projectImage;

    public string projectAddress;
    public string projectDetails;

    public Sprite projectCatImage;

    public Sprite mapImage;
    public List<ProjectAreaDetails> areaDetails;
}

[System.Serializable]
public struct ProjectAreaDetails
{
    public string areaName;
    public Material vr_Mat;


}