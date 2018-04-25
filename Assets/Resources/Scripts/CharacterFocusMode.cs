using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFocusMode : MonoBehaviour {

    Animator anim;
    float _RotSpeed;

	void Awake () {
        anim = GetComponent<Animator>();
    }
	
	void FixedUpdate () {

        _RotSpeed = transform.parent.GetComponent<PlayerMove>().RotSpeed;

        if (anim.GetCurrentAnimatorStateInfo(1).IsName("BowAttack") || anim.GetCurrentAnimatorStateInfo(1).IsName("BowPull"))
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0f, 26f, 0f), _RotSpeed * Time.time);
        else
            transform.localRotation = Quaternion.Euler(Vector3.zero);

    }
}
