using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabControll : MonoBehaviour {

    public static Vector3 rl_child_zeroPos, rl_child_firstPos, rl_child_secondPos, rl_child_thirdPos, rl_child_fourthPos;
    public static Quaternion rl_child_zeroRot, rl_child_firstRot, rl_child_secondRot, rl_child_thirdRot, rl_child_fourthRot;

    GameObject Shooter;

    private void Start()
    {
        Shooter = GameObject.Find("Shooter");

        rl_child_zeroPos = ArrowPosRot.rl_zeroPos;
        rl_child_zeroRot = ArrowPosRot.rl_zeroRot;

        rl_child_firstPos = ArrowPosRot.rl_firstPos;
        rl_child_firstRot = ArrowPosRot.rl_firstRot;

        rl_child_secondPos = ArrowPosRot.rl_secondPos;
        rl_child_secondRot = ArrowPosRot.rl_secondRot;

        rl_child_thirdPos = ArrowPosRot.rl_thirdPos;
        rl_child_thirdRot = ArrowPosRot.rl_thirdRot;

        rl_child_fourthPos = ArrowPosRot.rl_fourthPos;
        rl_child_fourthRot = ArrowPosRot.rl_fourthRot;
    }

    void Update () {
        if(Shooter.transform.childCount != 0 && transform.childCount != 0)
        {
            for (int i = 0; i < Shooter.transform.childCount; i++)
                Shooter.transform.GetChild(i).SetParent(transform);
        }


        if (transform.childCount >= 2)
        {
            if (!BeltStatus.reloading)
            {
                transform.GetChild(transform.childCount - 1).SetParent(GameObject.Find("BowBelt").transform);
            }
        }
	}
}
