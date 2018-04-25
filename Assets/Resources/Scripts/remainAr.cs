using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class remainAr : MonoBehaviour {

    Text arText;

	void Start () {
        arText = GetComponent<Text>();
	}
	
	void Update () {
        arText.text = BeltStatus.havingAr.ToString() + " / " + GameObject.Find("Quiver").transform.childCount.ToString();	
	}
}
