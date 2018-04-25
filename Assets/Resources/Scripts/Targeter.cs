using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour {


	void Awake () {
        transform.localPosition = new Vector3(0f, transform.parent.Find("Body").lossyScale.y / 2f + 0.3f, 0f);
	}
	

}
