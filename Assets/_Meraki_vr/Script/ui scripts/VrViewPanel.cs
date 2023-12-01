using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrViewPanel : MonoBehaviour , IUserInteface
{
    [SerializeField] private Button back_btn;
    public void AssignProperties()
    {
        back_btn.onClick.AddListener(() =>
        {
            Singleton.Instance.UIManager.LoadPanelByName(Constant.panel_projet_details_page);
            Singleton.Instance.UIManager.ClosePanel(this.gameObject);
        });
    }

   
}
