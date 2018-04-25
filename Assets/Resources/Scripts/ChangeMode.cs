using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour {

    public bool focusing;
    public GameObject Target, TargetingPos;
    public float focusDist;

    public Vector3 focusingPos;

    Animator myAnim;
    Ray ray;

	void Awake () {
        focusing = false;
        myAnim = transform.GetChild(0).GetComponent<Animator>();
        focusDist = 20f;
    }
	
	void FixedUpdate () {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int EnemyCheck = 1 << LayerMask.NameToLayer("Enemy");

        if (Physics.Raycast(ray, out hit, focusDist, EnemyCheck))
        {
            Target = hit.collider.transform.root.gameObject;
            //TargetingPos = Target.transform.GetChild(0).GetChild(0).Find("Spine").Find("Spine1").gameObject;
            TargetingPos = Target.transform.GetChild(0).Find("Spine").Find("Spine1").gameObject;
            focusingPos = Target.transform.position; // targeting position
            print("(ChangeMode) : Target name : " + Target.name);
        }
        else
        {
            Target = null; TargetingPos = null;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Target != null)
                focusing = !focusing;
            else
                return;
        }

        if (focusing)
            FocusingMode();
        else
            NormalMode();

        Debug.DrawRay(ray.origin, ray.direction * focusDist, Color.blue);
	}


    void FocusingMode()
    {
        myAnim.runtimeAnimatorController = Resources.Load("Anim/FocusAnim") as RuntimeAnimatorController;
        GetComponent<FocusMode>().enabled = true;

        GetComponent<PlayerMove>().enabled = false;
        GetComponent<PlayerRotate>().enabled = false;
        transform.GetChild(0).GetComponent<CharacterRot>().enabled = false;
        transform.GetChild(0).GetComponent<CharacterFocusMode>().enabled = true;


        myAnim.SetFloat("dirX", Input.GetAxis("Horizontal"));
        myAnim.SetFloat("dirY", Input.GetAxis("Vertical"));
        myAnim.SetBool("FocusOn", focusing);

        if ((ray.origin - transform.position).magnitude > focusDist || Target == null)
            focusing = false;

    }

    void NormalMode()
    {
        myAnim.runtimeAnimatorController = Resources.Load("Anim/MovingAnim") as RuntimeAnimatorController;
        GetComponent<FocusMode>().enabled = false;

        GetComponent<PlayerMove>().enabled = true;
        GetComponent<PlayerRotate>().enabled = true;
        transform.GetChild(0).GetComponent<CharacterRot>().enabled = true;
        transform.GetChild(0).GetComponent<CharacterFocusMode>().enabled = false;
    }
}
