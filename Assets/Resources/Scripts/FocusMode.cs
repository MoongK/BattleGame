using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusMode : MonoBehaviour {

    GameObject Target;

    float x, z, moveSpeed;
	
	void Update () {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        moveSpeed = GetComponent<PlayerMove>().originSpeed;
        Target = GetComponent<ChangeMode>().Target;

        FocuseModeMove();
        FocuseModeRotate();
    }

    void FocuseModeMove()
    {
        Vector3 moveDir = new Vector3(x, 0f, z);

        moveDir = transform.TransformDirection(moveDir).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
    
    void FocuseModeRotate()
    {
        if (Target != null)
        {
            Vector3 TargetFilterPos = GetComponent<ChangeMode>().focusingPos;
            TargetFilterPos = new Vector3(TargetFilterPos.x, transform.position.y, TargetFilterPos.z);

            transform.LookAt(TargetFilterPos);
        }
    }
}
