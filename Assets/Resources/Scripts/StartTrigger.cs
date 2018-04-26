using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.Find("Boss") != null)
        {
            if (other.transform.CompareTag("Player"))
                GameObject.Find("Boss").GetComponent<Animator>().SetBool("isStarted", true);
        }
    }
}
