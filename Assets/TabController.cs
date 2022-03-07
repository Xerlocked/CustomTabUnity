using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TabController : MonoBehaviour
{
    public List<MyTabButton> listTabButtons;
    public List<GameObject> listBodyViews;
    public GameObject tabIndicator;
    private MyTabButton selectedButton;

    private int lastPos = 0;
    

    public void Subscribe(MyTabButton button)
    {
        if (listTabButtons == null)
        {
            listTabButtons = new List<MyTabButton>();
        }
        listTabButtons.Add(button);
    }

    public void OnClick(MyTabButton button)
    {
        if (selectedButton == button)
            return;
            
        selectedButton = button;
        var idx = button.transform.GetSiblingIndex();
        MoveIndicator(idx);

        for (int i = 0; i < listBodyViews.Count; i++)
        {
            listBodyViews[i].SetActive(i == idx);
        }
    }

    private void MoveIndicator(int idx)
    {
        var pos = idx switch
        {
            var x when (2 - x) == 0 => 2,
            var x when (2 - x) == 1 => 1,
            var x when (2 - x) == 2 => 0,
            _ => 0
        };

        int movePosX = (pos - lastPos) * 630;
        Vector3 indicatorPos = tabIndicator.transform.localPosition;
        tabIndicator.transform.DOLocalMove(new Vector3(indicatorPos.x + movePosX, indicatorPos.y), 0.1f);
        lastPos = idx;
    }
}
