using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    bool attacking;
    [SerializeField] GameObject axeObject;
    private bool lockedOn = false;
    private bool draggingCamera = false;
    public GameObject lockTarget;
    private Vector2 mouseDelta;

    public GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;

    void Start()
    {
        anim = GetComponent<Animator>();
        //axeObject.SetActive(false);
    }

    void Update()
    {
        if (!GameManager.gm.abilityActive)
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

            #region Left clicking
            if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            {
                bool hit = false;
                m_PointerEventData = new PointerEventData(m_EventSystem);
                m_PointerEventData.position = Input.mousePosition;
                List<RaycastResult> results = new List<RaycastResult>();
                m_Raycaster.Raycast(m_PointerEventData, results);
                foreach (RaycastResult result in results)
                {
                    if (result.gameObject.activeInHierarchy)
                    {
                        hit = true;
                        Debug.Log("Hit " + result.gameObject.name);
                    }
                }

                if (!hit)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    draggingCamera = true;
                }
            }
            if (CrossPlatformInputManager.GetButtonUp("Fire1"))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                draggingCamera = false;
            }
            #endregion

            #region Right Clicking
            if (CrossPlatformInputManager.GetButtonDown("Fire2"))
            {
                Cursor.lockState=CursorLockMode.Locked;
                Cursor.visible = false;
                lockedOn = true;
                anim.SetBool("Targeting", true);
                if (true) //for target later
                {
                    GameManager.gm.mainCam.fallback.transform.parent = null;
                    Quaternion temp = Quaternion.Euler(Vector3.Scale(GameManager.gm.mainCam.transform.rotation.eulerAngles, Vector3.up.normalized));
                    transform.rotation = temp;
                    GameManager.gm.mainCam.fallback.transform.parent = transform;
                }
                //TODO: GetTarget()
            }

            if (CrossPlatformInputManager.GetButtonUp("Fire2"))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                anim.SetBool("Targeting", false);
                lockedOn = false;
                //TODO: Remove Target once GetTarget() is added.
            }
            #endregion

            if (lockedOn)
            {
                float mouseX = CrossPlatformInputManager.GetAxis("Mouse X");
                float mouseY = CrossPlatformInputManager.GetAxis("Mouse Y");
                transform.Rotate(0,GameManager.gm.mainCam.CameraRotation(mouseX, mouseY, true), 0);
                //TODO: Make player look at target, and move camera accordingly. If there is no target, make the player turn to face the camera direction.
            }

            else if(draggingCamera)
            {
                float mouseX = CrossPlatformInputManager.GetAxis("Mouse X");
                float mouseY = CrossPlatformInputManager.GetAxis("Mouse Y");
                GameManager.gm.mainCam.CameraRotation(mouseX, mouseY, false);
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
