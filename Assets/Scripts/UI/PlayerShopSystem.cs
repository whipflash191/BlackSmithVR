using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShopSystem : MonoBehaviour
{
    public static PlayerShopSystem instance;
    public GameObject shopSystemPanel;
    public TextMeshProUGUI cost;
    public List<ShopItem> availableItems = new List<ShopItem>();
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        updateShopSlots();
    }

    private void Update()
    {
        cost.text = "Bank: " + PlayerManager.instance.money.ToString();
    }

    public void updateShopSlots()
    {
        int index = 0;
        foreach (Transform child in shopSystemPanel.transform)
        {
            ShopSlotController instance = child.GetComponent<ShopSlotController>();
            if (index < availableItems.Count && instance != null)
            {
                instance.item = availableItems[index];
                instance.UpdateInfo();
            }
            else if (instance != null)
            {
                instance.item = null;
                instance.UpdateInfo();
            }
            index++;
        }
    }
}
