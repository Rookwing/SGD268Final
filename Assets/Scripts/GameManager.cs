using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    void Awake()
    {
        if (!gm) gm = this;
        else Destroy(this.gameObject);
    }

    [Header("Player Controls")]
    public GameObject player;
    public InventoryManager im;
    public TPCamera mainCam;

    [HideInInspector] public bool abilityActive;
    [HideInInspector] public bool[] canUse = new bool[4];

    private void Start()
    {
        mainCam = Camera.main.GetComponent<TPCamera>();    
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            im.MenuOpen();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Play()
    {
        Time.timeScale = 1;
    }
}
