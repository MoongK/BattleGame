using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour {

    public float rotSpeed;
    Animator anim;

    void Awake()
    {
        rotSpeed = 150f;
        anim = GameObject.Find("Body(Player)").GetComponent<Animator>();
    }

    void Update()
    {
        float AxisX = Input.GetAxisRaw("Mouse X") * Time.deltaTime;
        float h = PlayerDir.h;
        float v = PlayerDir.v;

        if(GetComponent<PlayerHp>().currentHp > 0) {
            if (!Input.GetKey(KeyCode.LeftAlt))
            {
                if ((h != 0f || v != 0f) || (anim.GetCurrentAnimatorStateInfo(1).IsTag("AttackMachine")))
                {
                    transform.rotation = GameObject.Find("PlayerDir").transform.rotation;
                }
                else
                    transform.rotation = transform.rotation;
            }
        }
    }
}
