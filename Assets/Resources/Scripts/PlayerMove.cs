using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public Rigidbody myrg;

    public float MoveSpeed, maxSpeed, originSpeed;
    public float RotSpeed;

    public Vector3 MovingDir;

    bool isRun;
    public bool isJump;
    public bool isGround;

    Animator anim;

	void Awake () {

        myrg = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();

        MoveSpeed = 2f;
        RotSpeed = 20f;
        originSpeed = MoveSpeed;
        maxSpeed = 2f * MoveSpeed;

        isRun = false;
        isJump = false;
        isGround = false;
	}
	
	void FixedUpdate () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        MovingDir = new Vector3(h, 0f, v).normalized;

        if (anim.GetCurrentAnimatorStateInfo(1).IsName("BowAttack") || anim.GetCurrentAnimatorStateInfo(1).IsName("BowPull"))
            MoveSpeed = originSpeed;
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) && (h != 0f || v != 0f))  // running~
                MoveSpeed = Mathf.Clamp(2f * MoveSpeed, 0f, maxSpeed);
            else
                MoveSpeed = originSpeed;
        }
        

        if (MoveSpeed > originSpeed)
            isRun = true;
        else
            isRun = false;                                          // ~running

        if(h != 0f || v != 0f)
            anim.SetBool("Walking", true);
        else
            anim.SetBool("Walking", false);

        MovingDir = transform.TransformDirection(MovingDir);

        if (isGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                myrg.AddForce(Vector3.up * 150f);
                {
                    isJump = true;
                    isGround = false;
                }
            }
        }

        anim.SetBool("isRun", isRun);
        anim.SetBool("isJump", isJump);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("StandJump"))
            return;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("LightJump"))
        {
            MoveSpeed /= 2f;
        }
  
        myrg.position += MovingDir * MoveSpeed * Time.deltaTime;
    }

}
