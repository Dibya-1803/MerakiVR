using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorePanel : MonoBehaviour, IUserInteface
{
    [SerializeField] private RectTransform gridParent;
    [SerializeField] private ExplorePanelItem gridItem;
   // [Space]
   
    public void AssignProperties()
    {
        foreach (Transform item in gridParent.transform)
        {
            Destroy(item);
        }
        int i = 0;
        foreach (ExploreItemDetails itemDetails in Singleton.Instance.dataManager.itemDetailList)
        {
            var _tempItem = Instantiate(gridItem, gridParent);
            _tempItem.image.sprite = itemDetails.projectImage;
            _tempItem.name = itemDetails.projectName;
            _tempItem.index = Singleton.Instance.dataManager.itemDetailList.IndexOf(itemDetails);
            _tempItem.click_btn.onClick.AddListener(()=>
            {
                Singleton.Instance.gameManager.SetCurrentProjectIndex(_tempItem.index);
                Singleton.Instance.UIManager.LoadPanelByName(Constant.panel_explore_selected);
                Singleton.Instance.UIManager.ClosePanel(this.gameObject);
                Debug.Log(_tempItem.index);
            });

            i++;
        }
    }
}

