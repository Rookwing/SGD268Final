using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquip : MonoBehaviour
{
    public Item item;
    Rigidbody rb;
    MeshFilter mesh;
    new MeshRenderer renderer;
    bool lethal = true;

    public float lethalspeed = .1f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshFilter>();
        renderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Unit>() && lethal)
        {
            other.gameObject.GetComponent<Unit>().health -= item.damage - other.gameObject.GetComponent<Unit>().armor;
            other.GetComponent<Rigidbody>().AddForceAtPosition(((other.transform.position - GameManager.gm.player.transform.position).normalized * item.damage), other.ClosestPoint(transform.position), ForceMode.Impulse);
            print("hit " + other.gameObject.name + " || ");
        }
    }

    public void TransformItem(Item i)
    {
        mesh.mesh = i.model.GetComponent<MeshFilter>().mesh;
        renderer.material = i.model.GetComponent<MeshRenderer>().material;
    }
}
