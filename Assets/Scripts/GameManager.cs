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
    public GameObject inventoryMenu;

    List<GameObject> inventoryInGame;
    List<GameObject> inventoryOnHand;
    List<GameObject> inventorySlots;
    List<GameObject> inventorySprites;

    [HideInInspector] public bool abilityActive;
    [HideInInspector] public bool[] canUse = new bool[4];

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            MenuOpen();
        }
    }

    void MenuOpen()
    {
        inventoryMenu.SetActive(!inventoryMenu.activeInHierarchy);

        if (inventoryMenu.activeInHierarchy)
        {
            Pause();
        }
        else
        {
            Play();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    void Play()
    {
        Time.timeScale = 1;
    }
}
