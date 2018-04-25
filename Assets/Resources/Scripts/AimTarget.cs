using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTarget : MonoBehaviour {

    ChangeMode cm;
	void Awake () {
        cm = GameObject.FindGameObjectWithTag("Player").GetComponent<ChangeMode>();
	}
	
	void Update () {

        float dist = cm.focusDist;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        int layermask = 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Starter");
        layermask = ~layermask;

        if (Physics.Raycast(ray, out hit, dist, layermask))
            transform.position = hit.point;
        else
            transform.localPosition = (Vector3.forward * dist * 2f) + (Vector3.up * 0.95f);
	}
}
