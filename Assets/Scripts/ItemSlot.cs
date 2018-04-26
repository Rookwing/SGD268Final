using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {
    Item storedItem;
    [SerializeField]
    Image slotImage;

    public Item StoredItem
    {
        get { return storedItem; }
        set
        {
            storedItem = value;
            slotImage.sprite = storedItem.icon;
        }
    }
    // Use this for initialization
    private void OnMouseDown()
    {
        print("selected itemslot");
    }
    public void SelectItemSlot()
    {

    }
    public void UseItemSlot()
    {

    }
}
