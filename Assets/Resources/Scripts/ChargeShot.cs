using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeShot : MonoBehaviour {

    Image myIm, crosshairIm;
    float Pow, maxPow;
    Color crossOrigin;

    Animator playerAnim;

	void Awake () {
        myIm = GetComponent<Image>();
        crosshairIm = transform.parent.parent.GetComponent<Image>();
        crossOrigin = crosshairIm.color;

        playerAnim = GameObject.Find("Body(Player)").GetComponent<Animator>();
    }
	
	void Update () {

        Pow = ShootingState.ArrowPower;
        maxPow = ShootingState.maxPower;


        if (playerAnim.GetCurrentAnimatorStateInfo(1).IsName("BowPull") || playerAnim.GetCurrentAnimatorStateInfo(1).IsName("BowAttack"))
            myIm.fillAmount = Pow / maxPow;
        else
            myIm.fillAmount = 0f;

        if (myIm.fillAmount == 1f)
            crosshairIm.color = Color.red;
        else
            crosshairIm.color = crossOrigin;
    }
}
