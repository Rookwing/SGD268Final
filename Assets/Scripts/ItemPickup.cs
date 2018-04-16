using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void Start()
    {
        GetComponent<MeshFilter>().mesh = item.model.GetComponent<MeshFilter>().sharedMesh;
        GetComponent<MeshRenderer>().material = item.model.GetComponent<MeshRenderer>().sharedMaterial;
    }
}
