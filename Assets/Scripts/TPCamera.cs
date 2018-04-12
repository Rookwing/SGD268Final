using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCamera : MonoBehaviour
{
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - GameManager.gm.player.transform.position;
    }
    void Update()
    {
        transform.position = GameManager.gm.player.transform.position + offset;
	}
}
