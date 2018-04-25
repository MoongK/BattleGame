using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingArrow : MonoBehaviour {

    GameObject player;
    GameObject Target;
    public GameObject myTargetArrow;

	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        myTargetArrow.SetActive(false);
	}
	
	void Update () {
        Target = player.GetComponent<ChangeMode>().Target;
        bool focus = player.GetComponent<ChangeMode>().focusing;

        if (!focus || Target == null)
            NoneTargeting();
        else
            Targeting();

        myTargetArrow.transform.rotation = Camera.main.transform.rotation; // arrow rotation
        transform.localScale = Vector3.one * 0.5f;
    }

    void NoneTargeting()
    {
        myTargetArrow.transform.SetParent(transform);
        myTargetArrow.transform.localPosition = Vector3.zero;
        myTargetArrow.SetActive(false);
    }

    void Targeting()
    {
        myTargetArrow.transform.SetParent(Target.transform.Find("TaPos"));
        myTargetArrow.SetActive(true);
        myTargetArrow.transform.localPosition = myTargetArrow.transform.parent.position + (Vector3.up) * 1.1f;
    }
}
