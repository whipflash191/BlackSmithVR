using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSlotController : MonoBehaviour
{
    public GameObject shopPanel;
    public ShopItem item;
    public Image itemImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateInfo()
    {
        if (item == null)
        {
            itemImage.color = Color.clear;
        }
        else
        {
            itemImage.sprite = item.itemIcon;
            itemImage.color = Color.white;
        }
    }

    public void OpenPanel()
    {
        if (item != null)
        {
            shopPanel.SetActive(true);
            ShopPanelController instance = shopPanel.GetComponent<ShopPanelController>();
            instance.item = item;
            instance.UpdatePanel();
        }
    }

}
