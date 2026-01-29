using UnityEngine;
using UnityEngine.Events;

public class PlayerMaskAttacker : MonoBehaviour
{
    public NPCMaskReactor myReactor;
    public float emotionalDamage;
    public UnityEvent onAttack;
    public NPCBillboardManager myBillboardManager;
    public float attackClock;
    public float attackDelay = 2;
    public bool attackFlag = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attackFlag)
        {
            if(attackClock > 0)
            {
                attackClock -= Time.deltaTime;
            }
            else
            {
                Attack(emotionalDamage);
                attackClock = attackDelay;
            }
        }
    }

    public void Attack()
    {
        attackFlag = true;
        attackClock = attackDelay;
    }

    public void Attack(float ed)
    {
        if(myReactor != null)
        {
            if(myReactor.subject != null)
            {
                myReactor.subject.TakeDamageOneshot(ed);
            }
        }

        if(myBillboardManager != null)
        {
            myBillboardManager.activeAnimator.SetTrigger("attack");
        }
    }

    public void StopAttack()
    {
        attackFlag = false;
        attackClock = 0;
        AttackDrain(0);
    }

    public void AttackDrain(float ed)
    {
        if (myReactor != null)
        {
            if (myReactor.subject != null)
            {
                myReactor.subject.DrainDamage(ed);
            }
        }
    }
}
