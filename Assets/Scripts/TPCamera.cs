using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCamera : MonoBehaviour
{
    [Range(0.5f, 2.5f)]
    public float cameraSensitivity = 2.0f;
    public GameObject fallback; //Empty Gameobject parented to the player

    Transform player;
    private Vector3 offset;
    private Vector3 camPosition;
    private Vector3 fallbackPosition;
    private Vector3 aimPoint;
    private Vector3 aimDir;
    private Vector2 cameraRot;
    private float camDistance;
    RaycastHit hit;
    Ray ray;
    int layerMask;

    void Start()
    {
        player = GameManager.gm.player.transform;
        camDistance = Vector3.Distance(fallback.transform.position, player.position);
        offset = (fallback.transform.position - player.position).normalized * camDistance;
        transform.position = player.position + offset;
        cameraRot = Vector2.zero;

        layerMask = 1 << 8;
        layerMask = ~layerMask;
    }
    void Update()
    {
        if(Vector3.Distance(fallback.transform.position, player.position) > camDistance)
        {
            fallback.transform.Translate(transform.forward*Time.deltaTime);
        }
        cameraRot = Vector2.zero;
        fallbackPosition = fallback.transform.position;

        aimPoint = (player.position + (Vector3.up * 2));
        aimDir = fallbackPosition - aimPoint;

        Debug.DrawLine(aimPoint, fallbackPosition, Color.cyan, 1, true);

        if (Physics.Linecast(aimPoint, fallbackPosition, out hit, layerMask))
        {
            if (hit.collider.isTrigger == false)
            {
                camPosition = hit.point;
            }
            else
            {
                camPosition = fallbackPosition;
            }
        }
        else
        {
            camPosition = fallbackPosition;
        }

        //camPosition = GameManager.gm.player.transform.position + offset;

        transform.position = Vector3.Lerp(transform.position, camPosition, Mathf.Lerp(0,1,3));
        transform.LookAt(aimPoint);
    }
    public float CameraRotation(float xValue, float yValue, bool rotatingPlayer)
    {
        if (xValue != 0)
        {
            cameraRot.x = xValue * cameraSensitivity;
            if (!rotatingPlayer) 
            fallback.transform.RotateAround(player.position, player.up, cameraRot.x);

        }

        if (yValue != 0)
        {
            cameraRot.y = yValue * cameraSensitivity;

            Vector3 localX = transform.TransformDirection(Vector3.right);
            if (fallback.transform.localRotation.eulerAngles.x <= 60 || fallback.transform.localRotation.eulerAngles.x >= 0)
            {
                fallback.transform.RotateAround(player.position, localX, cameraRot.y);
            }
            else
            {
                fallback.transform.localRotation.eulerAngles.Set(Mathf.Clamp(fallback.transform.localRotation.eulerAngles.x, 0, 60), fallback.transform.localRotation.eulerAngles.y, fallback.transform.localRotation.eulerAngles.z);
            }
        }
        offset = fallbackPosition - player.position;

        return cameraRot.x;
    }
}
