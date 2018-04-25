using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaPos : MonoBehaviour {

    Transform myPar;

	void Awake () {
        myPar = transform.parent;
	}
	
	void Update () {
        transform.localPosition = new Vector3(0f, myPar.localScale.y / 2f, 0f);
	}
}
