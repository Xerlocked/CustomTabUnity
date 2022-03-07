using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTabButton : MonoBehaviour
{
    public TabController tabController;
    void Start()
    {
        tabController.Subscribe(this);
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        tabController.OnClick(this);
    }
}
