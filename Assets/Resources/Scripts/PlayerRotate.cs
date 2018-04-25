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

        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            transform.Rotate(0f, AxisX * rotSpeed, 0f);
        }
    }
}
