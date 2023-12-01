using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectDetailsPanel : MonoBehaviour,IUserInteface
{
    [SerializeField] private Transform gridParent;
    [SerializeField] private Item_prodetAreaDetails detailsItem;

    [Space]
    [SerializeField] private Button backBtn;
    [SerializeField] private Image mapView;
    public void AssignProperties()
    {
        int index = Singleton.Instance.gameManager.GetCurrentProjectIndex();
        var data = Singleton.Instance.dataManager.itemDetailList[index];

        mapView.sprite = data.mapImage;

        foreach (Transform t in gridParent.transform)
        {
            Destroy(t.gameObject);
        }

        foreach (var itemDetails in data.areaDetails)
        {
            
            var _tempItem = Instantiate(detailsItem, gridParent);
            _tempItem.areaName.text = itemDetails.areaName;
            _tempItem.index = data.areaDetails.IndexOf(itemDetails);
            _tempItem.name = itemDetails.areaName+" "+_tempItem.index;
            
            _tempItem.click_btn.onClick.AddListener(() =>
            {
                Singleton.Instance.gameManager.SetCurrentProjectAreaIndex(_tempItem.index);
                // AssignProperties();
                Singleton.Instance.gameManager.LoadVRSphare();
                Singleton.Instance.UIManager.ClosePanel(this.gameObject);
                Debug.Log(_tempItem.index);
            });

           
        }

        backBtn.onClick.AddListener(() => 
        {
            Singleton.Instance.UIManager.LoadPanelByName(Constant.panel_explore_selected);
            Singleton.Instance.UIManager.ClosePanel(this.gameObject);
        });
    }

   
}
