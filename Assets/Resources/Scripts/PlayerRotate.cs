using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour {

    public float rotSpeed;

    void Awake()
    {
        rotSpeed = 150f;
    }

    void Update()
    {
        float AxisX = Input.GetAxisRaw("Mouse X") * Time.deltaTime;
        float h = PlayerDir.h;
        float v = PlayerDir.v;

        if(GetComponent<PlayerHp>().currentHp > 0) {
            if (!Input.GetKey(KeyCode.LeftAlt))
            {
                if (h != 0f || v != 0f)
                {
                    transform.rotation = GameObject.Find("PlayerDir").transform.rotation;
                }
                else
                    transform.rotation = transform.rotation;
            }
        }
    }
}
