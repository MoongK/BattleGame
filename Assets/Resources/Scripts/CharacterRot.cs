using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRot : MonoBehaviour {

    float _RotSpeed;
    Vector3 _MovingDir;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void LateUpdate () {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        _RotSpeed = transform.parent.GetComponent<PlayerMove>().RotSpeed;
        _MovingDir = transform.parent.GetComponent<PlayerMove>().MovingDir;


        if (h != 0f || v != 0f)
        {
            if (_MovingDir != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_MovingDir), _RotSpeed * Time.deltaTime);
        }

        if (anim.GetCurrentAnimatorStateInfo(1).IsName("BowAttack") || anim.GetCurrentAnimatorStateInfo(1).IsName("BowPull"))
        {
            if (!transform.parent.GetComponent<PlayerMove>().isJump || (h == 0f && v == 0f))
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0f, 26f, 0f), _RotSpeed / 50f * Time.time);
            else
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0f, 80f, 0f), _RotSpeed / 50f * Time.time);
        }


    }
}
