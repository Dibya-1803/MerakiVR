using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_manager : MonoBehaviour
{
    [SerializeField]private RectTransform panel_parent;


    internal void LoadPanelByName(string panel_name)
    {
        GameObject instance = Instantiate(Resources.Load(panel_name, typeof(GameObject)),panel_parent) as GameObject;
        instance.name = panel_name;

        IUserInteface panel = instance.GetComponent<IUserInteface>();
        panel.AssignProperties();

    }

    internal void ClosePanel(GameObject obj)
    {
        Destroy(obj);
    }
    internal void ClosePanel(string panel_name)
    {
        GameObject obj = GameObject.Find(panel_name);
        if (obj != null)
        {
            Destroy(obj);
        }
    }
}
