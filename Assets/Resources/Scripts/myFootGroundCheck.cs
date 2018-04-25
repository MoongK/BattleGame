using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myFootGroundCheck : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
            transform.parent.GetComponent<PlayerMove>().isGround = true;

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().isJump = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
            transform.parent.GetComponent<PlayerMove>().isGround = false;
    }
}
