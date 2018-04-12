using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] inventoryArray;


    public void AddItemToList(int indexKey)
    {
        GameManager.gm.inventoryOnHand[indexKey] = GameManager.gm.inventoryInGame[indexKey];
        GameManager.gm.GetComponent<InventoryManager>().AddItemToList(0);
    }
}
