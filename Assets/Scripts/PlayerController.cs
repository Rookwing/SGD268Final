using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    bool attacking;
    [SerializeField] GameObject axeObject;
    private bool lockedOn = false;
    public GameObject lockTarget;

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
                ActivateAbility(UIManager.ui.ability1Icon, 0.5f);
                Attack();
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

            if(Input.GetMouseButtonDown(1))
            {
                lockedOn = true;
                anim.SetBool("Targeting", true);
                //TODO: GetTarget()

            }

            if (Input.GetMouseButtonUp(1))
            {
                anim.SetBool("Targeting", false);
                lockedOn = false;
                //TODO: Remove Target once GetTarget() is added.
            }

            if (lockedOn)
            {
                float mouseX = Input.GetAxis("Mouse X");
                GameManager.gm.mainCam.CameraRotation(mouseX);
                transform.Rotate(Vector3.up * mouseX);
                //TODO: Make player look at target, and move camera accordingly. If there is no target, make the player turn to face the camera direction.
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

    void Attack()
    {
        attacking = true;
        anim.SetBool("bAttack", attacking);
    }

    void StopAttacking()
    {
        attacking = false;
        anim.SetBool("bAttack", attacking);
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
