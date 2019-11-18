using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Job System/Shop Item")]
public class ShopItem : ScriptableObject
{
    public string itemName = null;
    public string itemDescription = null;
    public Sprite itemIcon = null;
    public GameObject itemToInstantiate;
    public float cost = 0;
}
