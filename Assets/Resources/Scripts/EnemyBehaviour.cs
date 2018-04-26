using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

    GameObject player;
    Animator anim;
    EnemyHp MobHp;
    public NavMeshAgent myNav;


    float moveSpeed;
    float originSpeed, fatalSpeed;
    public bool attacking;  // 어택 중인지 아닌지 판별
    public bool attackTrigger;  // 켜져 있을 때 어택함수 실행

    void Awake () {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        MobHp = GetComponent<EnemyHp>();
        myNav = GetComponent<NavMeshAgent>();

        moveSpeed = 3f;
        originSpeed = moveSpeed;
        fatalSpeed = moveSpeed * 2f;

        attacking = false;
        attackTrigger = false;
    }

    void Update()
    {
        float distCheck = (player.transform.position - transform.position).magnitude;

        if (player.GetComponent<PlayerHp>().currentHp > 0)
        {
            if (anim.GetBool("isStarted"))
            {
                if (MobHp.currentHp != 0f)
                {
                    // 공격 상태 or 따라오는 상태 판별
                    if (distCheck >= 3f && !BossAttacking())
                    {
                        print("(EnemyBehaviour2) : first case");
                        ChasePlayer();
                        ChaseRot();
                        attackTrigger = false;
                    }
                    else if (distCheck >= 3f && BossAttacking())
                    {
                        print("(EnemyBehaviour2) : second case");
                        attackTrigger = false;
                    }
                    else
                    {
                        print("(EnemyBehaviour2) : third case");
                        attackTrigger = true;
                    }


                    if (attackTrigger)  // 공격 범위 안에 있음.
                    {
                        myNav.SetDestination(transform.position);
                        if (!attacking)
                        {
                            print("(EnemyBehaviour2) : invokeChooseNum");
                            Invoke("ChooseNum", 0f);
                        }
                    }
                    //else
                    //    attacking = false;


                    anim.SetBool("AtkTrigger", attackTrigger);
                    anim.SetBool("Attacking", attacking);

                    // Walk or Run
                    if (MobHp.currentHp < MobHp.maxHp / 2f) // 체력 50% 이하 : 한번 Roar 후 달리기
                    {
                        anim.speed = 1.3f;
                        moveSpeed = fatalSpeed;
                    }
                    else
                    {
                        anim.speed = 1f;
                        moveSpeed = originSpeed;
                    }

                    myNav.speed = moveSpeed;
                }
                else
                {
                    anim.speed = 1f;
                    myNav.speed = 0;
                    Invoke("Death", 5f);
                }
            }
            else
                transform.rotation = Quaternion.Euler(Vector3.zero);
        }else
        {
            Reset();
        }
    }

    private void Reset()
    {
        anim.SetBool("AtkTrigger", false);
        anim.SetFloat("Moving", 0f);
    }

    private void FixedUpdate()
    {
        AngleCheck();   // yello
        LTKAngleCheck(); // blue
        NTKAngleCheck(); // green
        STKAngleCheck(); // red
    }

    void Death()
    {
        myNav.enabled = false;
        transform.GetComponent<Rigidbody>().useGravity = false;
        transform.GetComponent<Rigidbody>().isKinematic = true;
        transform.position += Vector3.down * 0.2f * Time.deltaTime;
        
    }

    public void AtkChange()
    {
        attacking = false;
    }

    public void ChooseNum()
    {
        attacking = true;
        int atkNum = Random.Range(1, 4);
        anim.SetInteger("AtkNum", atkNum);
    }

    public void ChasePlayer() // 따라오기
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Roar") && !anim.GetCurrentAnimatorStateInfo(0).IsName("BeforeStartIdle") && !anim.GetCurrentAnimatorStateInfo(0).IsName("StartRoar"))
        {
            print("(EnemyBehaviour2) : Roar!!!");

            //transform.position += transform.forward * moveSpeed * Time.deltaTime;
            myNav.SetDestination(player.transform.position);

            anim.SetFloat("Moving", moveSpeed);
        }
    }

    public void ChaseRot() // 바라보기
    {
        Vector3 looker = new Vector3(player.transform.position.x - transform.position.x, 0f, player.transform.position.z - transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(looker), 7f * Time.deltaTime);
    }

    bool BossAttacking()        // Attacking 체크
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("LightAtk") ||
           anim.GetCurrentAnimatorStateInfo(0).IsName("NormalAtk") ||
           anim.GetCurrentAnimatorStateInfo(0).IsName("SpecialAtk"))
        {
            transform.rotation = transform.rotation;
            print("(EnemyBehaviour2) : BossAttacking");
            attacking = true;
            return true;
        }
        else
        {
            attacking = false;
            print("(EnemyBehaviour2) : BossNotAttacking");
            return false;
        }
    }

    public void Jumper()    //  점프 시 위로 힘주기
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 22000f);
    }


    public void LightAtk()
    {
        Vector3 eulerChecker = transform.InverseTransformPoint(player.transform.position);  // google solution

        if ((0f < eulerChecker.z && eulerChecker.z < 2f) && (Mathf.Abs(eulerChecker.x) <= eulerChecker.z))
            player.GetComponent<PlayerHp>().TakeDamage(10, gameObject);
    }

    public void NormalAtk()
    {
        Vector3 eulerChecker = transform.InverseTransformPoint(player.transform.position);

        if ((0f < eulerChecker.z && eulerChecker.z < 4f) && (Mathf.Abs(eulerChecker.x) <= eulerChecker.z))
            player.GetComponent<PlayerHp>().TakeDamage(25, gameObject);
    }

    public  void SpecialAtk()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 8f && !player.GetComponent<PlayerMove>().isJump)
        {
            player.GetComponent<PlayerHp>().TakeDamage(40, gameObject);
            player.GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position).normalized * 500f + player.transform.up * 300f);
        }
        else
        {
            return;
        }
    }

    void AngleCheck()
    {
        Debug.DrawRay(transform.position + Vector3.up, transform.forward * 10f, Color.yellow);
        Debug.DrawRay(transform.position + Vector3.up, -transform.forward * 10f, Color.yellow);
        Debug.DrawRay(transform.position + Vector3.up, transform.right * 10f, Color.yellow);
        Debug.DrawRay(transform.position + Vector3.up, -transform.right * 10f, Color.yellow);
    }
    void LTKAngleCheck()
    {
        float t_f = 2f;
        float t_forigin = t_f;

        for (int i = 0; i < 10; i++)
        {
            var t_vector1 = transform.right * t_f + transform.forward * t_forigin;
            var t_vector2 = transform.right * -t_f + transform.forward * t_forigin;
            Debug.DrawRay(transform.position + Vector3.up * 1.3f, t_vector1, Color.blue);
            Debug.DrawRay(transform.position + Vector3.up * 1.3f, t_vector2, Color.blue);
            t_f -= t_forigin * 0.1f;
        }
    }

    void NTKAngleCheck()
    {
        float t_f = 4f;
        float t_forigin = t_f;

        for (int i = 0; i < 10; i++)
        {
            var t_vector1 = transform.right * t_f + transform.forward * t_forigin;
            var t_vector2 = transform.right * -t_f + transform.forward * t_forigin;
            Debug.DrawRay(transform.position + Vector3.up * 1.2f , t_vector1, Color.green);
            Debug.DrawRay(transform.position + Vector3.up * 1.2f , t_vector2, Color.green);
            t_f -= t_forigin * 0.1f;
        }
    }
    void STKAngleCheck()
    {
        var t_vector3 = (transform.forward - transform.right).normalized;

        for (int i = 0; i < 10; i++)
        {
            Debug.DrawRay(transform.position + Vector3.up * 1.1f, t_vector3 * 8f, Color.black);
        }
        
    }




    void earthQuake()
    {
        Camera cam = Camera.main;
        Vector3 origin = cam.transform.localPosition;
        Vector3 crash = new Vector3(origin.x, origin.y - 2f, origin.z);

        StartCoroutine(Quake(origin, crash));
    }

    IEnumerator Quake(Vector3 _origin, Vector3 _crash)
    {
        Camera cam = Camera.main;
        float term = 30f;

        for (int h = 0; h < 3; h++)
        {
            for (int i = 0; i < 10; i++)
            {
                cam.transform.localPosition = Vector3.MoveTowards(cam.transform.localPosition, _crash, term * Time.deltaTime);
                yield return null;
            }
            term -= 4f;
            yield return new WaitForSeconds(0.05f);
        }
    }
}

