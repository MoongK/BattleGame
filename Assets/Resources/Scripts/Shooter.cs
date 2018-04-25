using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    Animator anim;
    GameObject Arrow;
    GameObject Grab;


    public static bool AlreadyShoot;


    private void Awake()
    {
        AlreadyShoot = false;
        Grab = GameObject.Find("ArrowGrab");

        anim = GameObject.Find("Body(Player)").GetComponent<Animator>();
    }

    private void Update()
    {
        if (Grab.transform.childCount != 0)
            Arrow = Grab.transform.GetChild(0).gameObject;
        else if (transform.childCount != 0)
            Arrow = transform.GetChild(0).gameObject;
        else
            Arrow = null;

        if (Arrow != null)
        {
            if (anim.GetCurrentAnimatorStateInfo(1).IsName("Idle"))
            {
                print("(Shooter) : NoneState call");
                Invoke("NoneState", 0f);
            }
            else
            {
                if (anim.GetCurrentAnimatorStateInfo(1).IsName("BowPull"))
                {
                    print("(Shooter) : ReadyState call");
                    Invoke("ReadyToShoot", 0f);
                }
                if (anim.GetCurrentAnimatorStateInfo(1).IsName("BowAttack"))
                {
                    print("(Shooter) : ShootingState call");
                    Invoke("ShootArrow", 0f);
                }
            }
        }
        else
            print("(Shooter) : Null Arrow");
    }

    void ShootArrow()
    {
        if (!AlreadyShoot)
        {
            print("(Shooter) : ShootArrowFunc - done");
            AlreadyShoot = true;

            Arrow.transform.SetParent(transform);
            Arrow.transform.localPosition = ArrowPosRot.ReadyPos;
            Arrow.transform.localRotation = ArrowPosRot.ReadyRot;       // temp,,,

            Invoke("ServeShoot", 0.2f);
        }
        else
            print("(Shooter) : ShootArrowFunc - doesn't done");
    }

    void ServeShoot()
    {
        Arrow.GetComponent<ShootingState>().Shooting();
        print("(Shooter) : ServeShootFunc - done");
    }

    void ReadyToShoot()
    {
        print("(Shooter) : ReadyToShootFunc done");

        if (Arrow.transform.parent == Grab.transform)
        {
            Arrow.transform.SetParent(transform);
        }
        else
        {
            Arrow.GetComponent<ShootingState>().ReadyToShooting();
        }
    }
    
    void NoneState()
    {
        print("(Shooter) : NoneStateFunc done");
        Arrow.GetComponent<ShootingState>().NoneShooting();
    }
}
