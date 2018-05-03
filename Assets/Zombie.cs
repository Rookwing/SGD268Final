using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Zombie : MonoBehaviour
{
    AICharacterControl AIControl;
    Animator animator;
    Unit unit;
    bool aggro = false;
    bool alive = true;

    private void Start()
    {
        AIControl = GetComponent<AICharacterControl>();
        animator = GetComponent<Animator>();
        unit = GetComponent<Unit>();
    }

    private void Update()
    {
        if (unit.health <= 0 && alive)
        {
            Death();
        }
        if (alive)
        {
            if (aggro)
            {
                if (Vector3.Distance(GameManager.gm.player.transform.position, transform.position) < 1.5f)
                {
                    Attack();
                }
                if (Vector3.Distance(GameManager.gm.player.transform.position, transform.position) > 15.0f)
                {
                    AIControl.SetTarget(null);

                }

            }
            else
            {

                if (Vector3.Distance(GameManager.gm.player.transform.position, transform.position) < 3.0f)
                {
                    aggro = true;
                    AIControl.SetTarget(GameManager.gm.player.transform);
                }
                else if (Vector3.Distance(GameManager.gm.player.transform.position, transform.position) < 15.0f)
                {

                    if (Vector3.Angle(transform.forward, GameManager.gm.player.transform.position - transform.position) < .7f)
                    {
                        AIControl.SetTarget(GameManager.gm.player.transform);

                    }
                }
            }
        }
    }

    void Attack()
    {
        transform.forward = AIControl.target.position - transform.position;
        animator.SetTrigger("attack");
    }

    void Death()
    {
        alive = false;
        animator.SetBool("isDead", true);
        AIControl.SetTarget(null);
        Invoke("DestroyCorpse", 15.0f);
    }

    void PauseAnimation()
    {
        animator.speed = 0;
    }
    void DestroyCorpse()
    {
        Destroy(this.gameObject);
    }
}
