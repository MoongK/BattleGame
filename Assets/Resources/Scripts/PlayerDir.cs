using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDir : MonoBehaviour {

    float rotSpeed;
    public static bool forwardToShot;
    GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rotSpeed = player.GetComponent<PlayerRotate>().rotSpeed;
    }

    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            forwardToShot = false;
            transform.rotation = player.transform.rotation;
        }
        else
        {
            forwardToShot = true;
            float AxisX = Input.GetAxisRaw("Mouse X") * Time.deltaTime;
            transform.Rotate(0f, AxisX * rotSpeed, 0f);
        }

        transform.position = player.transform.position;

        Debug.DrawRay(transform.position + Vector3.up, transform.forward, Color.red);
    }
}
