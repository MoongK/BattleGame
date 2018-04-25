using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeChecker : MonoBehaviour {

    BoxCollider myBox;

	void Awake () {
        myBox = GetComponent<BoxCollider>();
        myBox.size = transform.GetChild(0).transform.lossyScale + Vector3.one * 0.1f;
    }
}
