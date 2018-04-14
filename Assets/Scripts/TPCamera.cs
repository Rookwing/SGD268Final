using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCamera : MonoBehaviour
{
    private Vector3 offset;
    private float cameraRot;

    void Start()
    {
        offset = transform.position - GameManager.gm.player.transform.position;
    }
    void Update()
    {
        //follow the player, at the offset we set it at in the scene
        transform.position = GameManager.gm.player.transform.position + offset;
        //keep the value between 0 and 360 in case we need it for reference?
        cameraRot = Mathf.Repeat(cameraRot, 360);
        //rotation
        transform.RotateAround(GameManager.gm.player.transform.position, Vector3.up, cameraRot);
        //look above the players head
        transform.LookAt(GameManager.gm.player.transform.position + (Vector3.up * 2));
	}
    public void CameraRotation(float value)
    {
        cameraRot += value;
    }
}
