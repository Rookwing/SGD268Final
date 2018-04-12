using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    bool bToggle;
    public GameObject axeObject;

    void Start()
    {
        anim = GetComponent<Animator>();
        //axeObject.SetActive(false);
    }

    void Update()
    {
        if(!GameManager.gm.abilityActive)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ActivateAbility(UIManager.ui.ability1Icon, 2);
                bToggle = !bToggle;
                ActivateAbility(bToggle);
                //GameManager.gm.abilityActive = bToggle;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && !GameManager.gm.canUse[0])
            {
                ActivateAbility(UIManager.ui.ability2Icon, 4);
                anim.SetTrigger("tRange");
                GameManager.gm.abilityActive = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && !GameManager.gm.canUse[1])
            {
                ActivateAbility(UIManager.ui.Ability3Icon, 4);
                anim.SetTrigger("tMagic");
                GameManager.gm.abilityActive = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && !GameManager.gm.canUse[2])
            {
                ActivateAbility(UIManager.ui.Ability4Icon, 4);
                anim.SetTrigger("tPotion");
                GameManager.gm.abilityActive = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha5) && !GameManager.gm.canUse[3])
            {
                ActivateAbility(UIManager.ui.Ability5Icon, 4);
                anim.SetTrigger("tPotion");
                GameManager.gm.abilityActive = true;
            }
        }        
    }

    void ActivateAbility(Image image, float cooldown)
    {
        AbilityIconHandler ac;
        ac = image.GetComponent<AbilityIconHandler>();
        if (!ac.active)
            ac.Dim(true, cooldown);
    }

    void ActivateAbility(bool param)
    {
        anim.SetBool("bAttack", param);
    }

    public void CanUseAbilites()
    {
        GameManager.gm.abilityActive = false;
    }

    public void ToggleAxe()
    {
        axeObject.SetActive(!axeObject.activeInHierarchy);
    }
}
