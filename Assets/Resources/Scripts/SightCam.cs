using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightCam : MonoBehaviour {

    GameObject player;
    public float Camdist;
    float rotSpeed;
    Quaternion originRot;
    GameObject target;

    bool isOrigin;
    float AngleY;

	void Awake () {
        player = GameObject.FindWithTag("Player");
        Camdist = 4f;
        rotSpeed = player.GetComponent<PlayerRotate>().rotSpeed;

        originRot = transform.localRotation;
        isOrigin = true;
        AngleY = 0f;

    }


    private void LateUpdate()
    {
        target = GameObject.Find("EnemyTargetPosition");

        if(player.GetComponent<ChangeMode>().focusing)
        {
            Camdist = 1.5f;
            transform.LookAt(target.transform.position);
            transform.localPosition = Vector3.Lerp(transform.localPosition, (Vector3.back + Vector3.up + Vector3.right) * Camdist, 10f * Time.deltaTime);
            isOrigin = false;
        }
        else
        {
            OriginCheck();

            float axisY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime;

            transform.Rotate(-axisY * rotSpeed, 0f, 0f);

            AngleY += axisY * 100f;
            AngleY = Mathf.Clamp(AngleY, -45f, 85f);
            transform.localRotation = Quaternion.Euler(-AngleY, 0f, 0f);

            Camdist -= Input.GetAxis("Mouse ScrollWheel");
            Camdist = Mathf.Clamp(Camdist, 3f, 10f);
            transform.localPosition = Vector3.Lerp(transform.localPosition, (Vector3.back + Vector3.up) * Camdist, 10f * Time.deltaTime);

        }
    }

    void OriginCheck()
    {
        if (!isOrigin)
        {
            transform.localRotation = originRot;
            isOrigin = true;
            Camdist = 4f;
        }
        else
            return;
    }
}
