using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroPanel : MonoBehaviour, IUserInteface
{

    public Button explore_btn;

    public void AssignProperties()
    {
        AssignValues();
    }

    public void AssignValues()
    {
        explore_btn.onClick.RemoveAllListeners();

        explore_btn.onClick.AddListener(Explore_button);
    }
    

    private void Explore_button()
    {
        Singleton.Instance.UIManager.LoadPanelByName(Constant.panel_explore);
        Singleton.Instance.UIManager.ClosePanel(this.gameObject);
    }
}
