using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetPosition : MonoBehaviour {

    GameObject Targeter;

	void Update () {
        Targeter = GameObject.Find("Player").GetComponent<ChangeMode>().TargetingPos;

        if(Targeter != null)
        {
            transform.position = Targeter.transform.position;
        }
	}
}
