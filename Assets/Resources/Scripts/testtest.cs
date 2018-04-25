using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtest : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        print("my highest parent : "  + transform.root.name);
	}
}
