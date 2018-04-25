using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemytest : MonoBehaviour {

    public GameObject center;
    float dir;

    private void Start()
    {
        StartCoroutine(EnemyMove());
    }

    void Update () {
        transform.LookAt(center.transform);

        transform.position += transform.TransformDirection(dir, 0f, 0f) * Time.deltaTime;
    }

    IEnumerator EnemyMove()
    {
        while (true)
        {
            dir = Random.Range(-10f, 10f);
            yield return new WaitForSeconds(3f);
        }
    }
}
