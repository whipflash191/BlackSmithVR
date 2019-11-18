using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopPanelController : MonoBehaviour
{
    public ShopItem item;
    public Image itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI cost;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePanel();
    }

    public void UpdatePanel()
    {
        if (item == null)
        {
            itemImage.color = Color.clear;
            itemName.SetText("");
            itemDescription.SetText("");
            cost.SetText("");
        }
        else
        {
            itemImage.sprite = item.itemIcon;
            itemImage.color = Color.white;
            itemName.SetText(item.itemName);
            itemDescription.SetText(item.itemDescription);
            cost.SetText("Cost: " + item.cost);
        }
    }

    public void PlayerPurchase()
    {

    }
}
