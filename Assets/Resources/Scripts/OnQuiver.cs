using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnQuiver : MonoBehaviour {
	
	void Update () {
		if(transform.parent != null && transform.parent.name == "Quiver")
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<CapsuleCollider>().isTrigger = false;
            GetComponent<CapsuleCollider>().enabled = false;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            gameObject.SetActive(false);

        }
	}
}
