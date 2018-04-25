using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour {

    public float currentHp, maxHp;

    GameObject player;
    Animator anim;

	void Start () {
        maxHp = 500f;
        currentHp = maxHp;

        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        if (!anim.GetBool("isStarted"))
            currentHp = maxHp;


        anim.SetFloat("BossHp", currentHp);
    }

    public void TakeDamage(float _power)
    {
        currentHp -= _power;
        currentHp = Mathf.Clamp(currentHp, 0f, maxHp);

        if(currentHp <= 0f)     // death
        {
            currentHp = 0f;
            player.GetComponent<ChangeMode>().focusing = false;
            Destroy(gameObject, 10f);
        }

    }


}
