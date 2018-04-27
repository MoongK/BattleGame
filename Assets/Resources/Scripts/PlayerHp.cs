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
        GetComponent<ChangeMode>().focusing = false;    // change to normalMode
        StartCoroutine(test(damage, _enemy));   // why doesn't work at same time?
    }

    IEnumerator test(int damage, GameObject _enemy)
    {
        yield return null;
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

        GameObject.Find("UserHp").GetComponent<HeartMgr>().Damaged(damage);
        RotOnDamaged(_enemy);
    }

    public void RotOnDamaged(GameObject enemy)
    {
        transform.Find("Body(Player)").LookAt(enemy.transform.position);
        DamagedRot = transform.Find("Body(Player)").rotation;
    }

}
