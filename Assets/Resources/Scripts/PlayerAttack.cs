using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    Animator anim;
    GameObject shooter, Grab, belt;

    private void Awake()
    {
        shooter = GameObject.Find("Shooter");
        Grab = GameObject.Find("ArrowGrab");
        belt = GameObject.Find("BowBelt");
    }
    void Update () {

        anim = transform.GetChild(0).GetComponent<Animator>();

        if (!BeltStatus.reloading)
        {
            if (Input.GetMouseButton(0))
            {
                anim.SetBool("Attacking", true);
                anim.SetBool("BowPull", false);
                
            }
            else
            {
                if (Input.GetMouseButton(1))
                {
                    anim.SetBool("BowPull", true);
                }
                else if (Input.GetMouseButtonUp(1))
                {
                    anim.SetBool("BowPull", false);
                }

                anim.SetBool("Attacking", false);
            }
        }
        if(shooter.transform.childCount == 0 && Grab.transform.childCount == 0 && belt.transform.childCount == 0)
        {
            anim.SetBool("Attacking", false);
            anim.SetBool("BowPull", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(2).IsName("reload"))
        {
            anim.SetBool("Attacking", false);
            anim.SetBool("BowPull", false);
        }
	}
}
