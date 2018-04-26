using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : MonoBehaviour {

    bool isShooted; // for AddForce
    Vector3 forwardDir;
    GameObject player;

    public static float ArrowPower;
    public static float minPower, maxPower;
    int Enemylayer;

    float arrowDamage, minDam, maxDam, criDam;
    bool Attacked;
    Vector3 afterCrashedPos;

    void Awake () {

        player = GameObject.Find("Player");
        isShooted = false;

        ArrowPower = 0f;
        minPower = 30f;
        maxPower = 200f;

        Enemylayer = 10;

        arrowDamage = 10f;
        minDam = 10f;
        maxDam = 30f;
        criDam = 2f; // multiple with arrowDamage

        Attacked = false;
        afterCrashedPos = Vector3.zero;

    }
	
	void Update () {

        forwardDir = GameObject.Find("AimTarget").transform.position;
        ArrowPower = Mathf.Clamp(ArrowPower, 0f, maxPower);

        arrowDamage = Mathf.Clamp(arrowDamage, 0, maxDam);
        print("(ShootingState) - Damage : " + arrowDamage);

        if (transform.parent != null && isShooted)
            transform.localPosition = afterCrashedPos;
    }

    private void FixedUpdate()
    {
        ArrowDirection();
    }

    public void Shooting()
    {
        print("(ShootingState) : Shooting()");

        if (transform.parent.name == "ArrowGrab")
        {
            print("(ShootingState) : Shooting() - ChangeParent");
            ReadyToShooting();
        }
        if (transform.parent.CompareTag("Shooter"))
            transform.SetParent(null);

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<CapsuleCollider>().enabled = true;

        if (!isShooted)
        {
            transform.rotation = Quaternion.Euler(transform.forward);

            if (ArrowPower == 0f)
                ArrowPower = minPower;
            if (arrowDamage == 0)
                arrowDamage = minDam;

            if(!PlayerDir.forwardToShot)
                GetComponent<Rigidbody>().AddForce((forwardDir-transform.position).normalized * ArrowPower);
            else
                GetComponent<Rigidbody>().AddForce((player.transform.forward * ArrowPower) + (Vector3.up * 20f));


            isShooted = true;
        }

        ArrowPower = 0f;
    }

    public void ReadyToShooting()
    {
        print("(ShootingState) : ReadyToShooting()");
        transform.SetParent(GameObject.FindGameObjectWithTag("Shooter").transform);
        transform.localPosition = ArrowPosRot.ReadyPos;
        transform.localRotation = ArrowPosRot.ReadyRot;

        ArrowPower += 5f;
        arrowDamage += (maxDam - arrowDamage) * (ArrowPower / maxPower);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<CapsuleCollider>().enabled = false;

    }

    public void NoneShooting()
    {
        print("(ShootingState) : NoneShooting()");
        transform.SetParent(GameObject.Find("ArrowGrab").transform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);

        ArrowPower = minPower;
        arrowDamage = minDam;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<CapsuleCollider>().enabled = false;

    }

    void EnterOnObject(GameObject _ob)
    {
        print("(ShootingState) : EnterOnObject()");
        transform.SetParent(_ob.transform, true);

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<CapsuleCollider>().isTrigger = true;

    }

    private void OnCollisionEnter(Collision collision)  // crashed
    {
        if (!collision.collider.gameObject.CompareTag("Player"))
        {
            print("(ShootingState) : oh, it's " + collision.gameObject.name);
            EnterOnObject(collision.collider.gameObject);

            if (collision.collider.gameObject.layer == Enemylayer)
            {
                if (!Attacked)
                {
                    Attacked = true;    // prevent overlapping
                    if (collision.collider.name == "Head")
                    {
                        arrowDamage *= criDam;
                        StartCoroutine(CriticalPop());
                    }
                    collision.transform.root.GetComponent<EnemyHp>().TakeDamage(arrowDamage);
                    StartCoroutine(DamPop());
                }
                
            }
            afterCrashedPos = transform.localPosition;
        }
        print("(Arrow) : " + collision.gameObject.name);
        
    }

    IEnumerator CriticalPop()
    {
        transform.Find("CriticalPop").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        transform.Find("CriticalPop").gameObject.SetActive(false);
    }

    IEnumerator DamPop()
    {
        GameObject popLight = transform.Find("damagePop").gameObject;
        popLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        popLight.SetActive(false);
    }

    void ArrowDirection()
    {
        Rigidbody rg = GetComponent<Rigidbody>();

        if (transform.parent == null)
        {
            Debug.DrawRay(transform.position, (rg.velocity - transform.position), Color.yellow);

            transform.forward = Vector3.Lerp(transform.forward, rg.velocity.normalized, 1f);  // google solution
        }
        else
            transform.rotation = transform.rotation;
    }
}
