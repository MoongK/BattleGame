using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPosRot : MonoBehaviour {

    public static Vector3 zeroPos, firstPos, secondPos, thirdPos, fourthPos;
    public static Quaternion zeroRot, firstRot, secondRot, thirdRot, fourthRot;

    public static Vector3 rl_zeroPos, rl_firstPos, rl_secondPos, rl_thirdPos, rl_fourthPos;
    public static Quaternion rl_zeroRot, rl_firstRot, rl_secondRot, rl_thirdRot, rl_fourthRot;

    public static Vector3 ReadyPos;
    public static Quaternion ReadyRot;

    private void Awake()
    {
        zeroPos = new Vector3(-0.002000287f, 0.05299958f, -0.00397244f);
        zeroRot = Quaternion.Euler(21.561f, 180f, 0f);

        firstPos = new Vector3(-0.00200029f, 0.0529994f, -0.003972455f);
        firstRot = Quaternion.Euler(12.868f, 177.521f, -5.704f);

        secondPos = new Vector3(-0.00200029f, 0.0529994f, -0.003972455f);
        secondRot = Quaternion.Euler(1.834f, 175.722f, -12.108f);

        thirdPos = new Vector3(-0.001999994f, 0.03699995f, -0.005000002f);
        thirdRot = Quaternion.Euler(-5.361f, 175.216f, -16.066f);

        fourthPos = new Vector3(-0.002f, 0.042f, -0.005f);
        fourthRot = Quaternion.Euler(-12.488f, 175.382f, -16.548f);


        ReadyPos = new Vector3(0.246f, -0.116f, 0.097f);
        ReadyRot = Quaternion.Euler(-8.748f, -106.363f, -106.363f);

        // reloading

        rl_zeroPos = Vector3.zero;
        rl_zeroRot = Quaternion.Euler(180f, -6.864014f, -0.002990723f);

        rl_firstPos = Vector3.zero;
        rl_firstRot = Quaternion.Euler(180, 0f, 0f);

        rl_secondPos = Vector3.zero;
        rl_secondRot = Quaternion.Euler(180f, 7.736984f, 0.003997803f);

        rl_thirdPos = Vector3.zero;
        rl_thirdRot = Quaternion.Euler(180f, 4.172989f, 0.001998901f);

        rl_fourthPos = Vector3.zero;
        rl_fourthRot = Quaternion.Euler(180f, -2.812988f, -0.0009765625f);

    }


}
