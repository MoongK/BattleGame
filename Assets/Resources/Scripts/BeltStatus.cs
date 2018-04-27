using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltStatus : MonoBehaviour {

    Vector3 originPos;
    Quaternion originRot;
    public Object arrow;

    GameObject Shooter, Grab, Quiver;
    Animator anim;
    public static int maxArrow;
    public static int havingAr, needAr;
    int handlingAr; // Is exit On Grab or Shooter ?

    // Belt, Hand Arrow Status //
    public static Vector3 child_zeroPos, child_firstPos, child_secondPos, child_thirdPos, child_fourthPos;
    public static Quaternion child_zeroRot, child_firstRot, child_secondRot, child_thirdRot, child_fourthRot;

    public static bool reloading;
    bool throwingToShooter;


    private void Awake()
    {
        maxArrow = 5;
        havingAr = 0; needAr = 5; handlingAr = 0;

        reloading = false;
        throwingToShooter = false;

        originPos = transform.localPosition;
        originRot = transform.localRotation;

        Shooter = GameObject.Find("Shooter");
        Grab = GameObject.Find("ArrowGrab");
        Quiver = GameObject.Find("Quiver");

        anim = GameObject.Find("Body(Player)").GetComponent<Animator>();
    }

    private void Start()
    {
        for (int i = 0; i < maxArrow; i++)
        {
            if (Quiver.transform.childCount != 0)
            {
                Quiver.GetComponent<SetQuiver>().TakedByGrab();
                Quiver.GetComponent<SetQuiver>().GoToBelt();
            }
        }

        child_zeroPos = ArrowPosRot.zeroPos;
        child_zeroRot = ArrowPosRot.zeroRot;

        child_firstPos = ArrowPosRot.firstPos;
        child_firstRot = ArrowPosRot.firstRot;

        child_secondPos = ArrowPosRot.secondPos;
        child_secondRot = ArrowPosRot.secondRot;

        child_thirdPos = ArrowPosRot.thirdPos;
        child_thirdRot = ArrowPosRot.thirdRot;

        child_fourthPos = ArrowPosRot.fourthPos;
        child_fourthRot = ArrowPosRot.fourthRot;
    }

    void Update () {
        transform.localPosition = originPos;
        transform.localRotation = originRot;


        if (Shooter.transform.childCount == 1 || Grab.transform.childCount == 1)
            handlingAr = 1;
        else if (Shooter.transform.childCount == 0 && Grab.transform.childCount == 0)
            handlingAr = 0;

        //havingAr = transform.childCount + handlingAr; // handAr == belt + grab
        havingAr = transform.childCount + Grab.transform.childCount + Shooter.transform.childCount;
        needAr = maxArrow - havingAr;

        if (handlingAr == 0)
        {
            if(transform.childCount != 0)
            {
                if (!throwingToShooter)
                {
                    throwingToShooter = true;
                    Invoke("ToGrab", 0.25f);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Quiver.transform.childCount != 0)
            {
                if (!reloading)
                {
                    Invoke("TakeArrows", 0f);
                }
            }
        }

        anim.SetBool("isReloading", reloading);
	}

    void ToGrab()
    {
        transform.GetChild(transform.childCount - 1).transform.SetParent(Grab.transform);
        throwingToShooter = false;
    }

    void TakeArrows() // Get from Quiver
    {
        if (transform.childCount < maxArrow - handlingAr)
            StartCoroutine(Reloading());
        else
            return;
    }

    IEnumerator Reloading()
    {
        reloading = true;

        yield return new WaitForSeconds(0.3f);

        for(int i = 0; i < needAr; i++)
        {
            Quiver.GetComponent<SetQuiver>().TakedByGrab();
        }

        yield return new WaitForSeconds(1.3f);


        for (int i = 0; i < needAr; i++)
        {
            if (Quiver.transform.childCount != 0)
                Quiver.GetComponent<SetQuiver>().GoToBelt();
        }

        reloading = false;
    }
}
