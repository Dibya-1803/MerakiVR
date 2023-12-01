using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploreSelectedPanel : MonoBehaviour, IUserInteface
{
    [Header("Selected Project Details")]
    public Image highlightImage;
    public Image selectedImage;
    public TMPro.TMP_Text address_text;
    public TMPro.TMP_Text description_text;
    [Space]
    public Button watch_btn_01;
    public Button watch_btn_02;

    [Space]
    public Transform gridParent;
    public ExplorePanelItem item_prefab;

    public void AssignProperties()
    {

        var index = Singleton.Instance.gameManager.GetCurrentProjectIndex();
        var data = Singleton.Instance.dataManager.itemDetailList[index];

        highlightImage.sprite = data.projectCatImage;
        selectedImage.sprite = data.projectImage;
        address_text.text = data.projectAddress;
        description_text.text = data.projectDetails;

        foreach (Transform t in gridParent.transform)
        {
            Destroy(t.gameObject);
        }

        int i = 0;
        foreach (ExploreItemDetails itemDetails in Singleton.Instance.dataManager.itemDetailList)
        {
            int _indx = Singleton.Instance.dataManager.itemDetailList.IndexOf(itemDetails);
            if (_indx == index)
            { continue; }
            var _tempItem = Instantiate(item_prefab, gridParent);
            _tempItem.index = _indx;
            _tempItem.image.sprite = itemDetails.projectImage;
            _tempItem.name = itemDetails.projectName;
            _tempItem.click_btn.onClick.AddListener(() =>
            {
                Singleton.Instance.gameManager.SetCurrentProjectIndex(_tempItem.index);
                AssignProperties();
                Debug.Log(_tempItem.index);
            });

            i++;
        }

        watch_btn_01.onClick.RemoveAllListeners();
        watch_btn_02.onClick.RemoveAllListeners();

        watch_btn_01.onClick.AddListener(OnWatchBtnClicked);
        watch_btn_02.onClick.AddListener(OnWatchBtnClicked);
    }

    private void OnWatchBtnClicked()
    {
        Singleton.Instance.UIManager.LoadPanelByName(Constant.panel_projet_details_page);
        Singleton.Instance.UIManager.ClosePanel(this.gameObject);
    }
}
