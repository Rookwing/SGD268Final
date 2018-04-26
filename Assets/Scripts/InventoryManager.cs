using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryMenu;

    private ItemSlot[] inventoryArray;
    private ItemSlot[] equipmentArray;
    
    public enum EquipSlot
    {
        Helmet,
        Chest,
        Legs,
        Feet,
        Hands,
        Amulet,
        RRing,
        LRing,
        MItem,
        OItem//add new slots above OItem
    }

    private void Start()
    {
        inventoryArray = new ItemSlot[12];
        equipmentArray = new ItemSlot[(int)EquipSlot.OItem+1];//this is why OItem should be last.

        int i = 0;
        foreach(ItemSlot slot in GetComponentsInChildren<ItemSlot>())
        {
            if(i <= inventoryArray.Length)
            inventoryArray[i] = slot;
            i++;
        }
        //TODO: Populate Equipment Slots
    }

    public void MenuOpen()
    {
        inventoryMenu.SetActive(!inventoryMenu.activeInHierarchy);

        if (inventoryMenu.activeInHierarchy)
        {
            GameManager.gm.Pause();
        }
        else
        {
            GameManager.gm.Play();
        }
    }
    
}
