using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour {

    public int maxHp, currentHp;


    private void Awake()
    {
        maxHp = 104;
        currentHp = maxHp;
    }

    private void Update()
    {
        if(currentHp <= 0)
        {
            currentHp = 0;
        }
        print("currentHp : " + currentHp);
    }


    public void TakeDamage(int damage)
    {
        Animator anim = transform.Find("Body(Player)").GetComponent<Animator>();
        anim.SetInteger("Damage", damage);
        anim.SetTrigger("TakeDamage");

        currentHp -= damage;

        if(damage >= 40)
        {
            print("so pain atk");
            
        }
        else if(damage >= 25)
        {
            print("pretty pain atk");
        }
        else
        {
            print("week atk");
        }

        GameObject.Find("UserHp").GetComponent<HeartMgr>().Damaged(damage);
    }

}
