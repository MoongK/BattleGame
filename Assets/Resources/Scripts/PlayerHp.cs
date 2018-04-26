using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour {

    public int maxHp, currentHp;
    public Quaternion DamagedRot;
    Animator anim;

    private void Awake()
    {
        maxHp = 104;
        currentHp = maxHp;
    }

    public void TakeDamage(int damage, GameObject _enemy)
    {
        GetComponent<ChangeMode>().focusing = false;
        Damaged(damage, _enemy);
    }

    void Damaged(int damage, GameObject _enemy)
    {
        Animator anim = transform.Find("Body(Player)").GetComponent<Animator>();
        anim.SetInteger("Damage", damage);

        anim.SetTrigger("TakeDamage");

        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);

        anim.SetInteger("PlayerHp", currentHp);

        if (damage >= 40)
        {
            print("so pain atk");

        }
        else if (damage >= 25)
        {
            print("pretty pain atk");
        }
        else
        {
            print("week atk");
        }

        GameObject.Find("UserHp").GetComponent<HeartMgr>().Damaged(damage);
        RotOnDamaged(_enemy);
        print("currentHp : " + currentHp);
    }

    public void RotOnDamaged(GameObject enemy)
    {
        transform.Find("Body(Player)").LookAt(enemy.transform.position);
        DamagedRot = transform.Find("Body(Player)").rotation;
    }

}
