using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager ui;

    [Header("Ability Icons")]
    public Image ability1Icon;
    public Image ability2Icon;
    public Image Ability3Icon;
    public Image Ability4Icon;
    public Image Ability5Icon;

    void Awake()
    {
        if (!ui) ui = this;
        else Destroy(this.gameObject);
    }


}
