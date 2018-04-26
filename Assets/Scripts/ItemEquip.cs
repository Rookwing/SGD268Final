using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquip : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddForceAtPosition(transform.forward*100, collision.contacts[0].point, ForceMode.Impulse);
        print("hit " + collision.gameObject.name);
    }
}
