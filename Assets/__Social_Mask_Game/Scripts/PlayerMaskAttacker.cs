using UnityEngine;
using UnityEngine.Events;

public class PlayerMaskAttacker : MonoBehaviour
{
    public NPCMaskReactor myReactor;
    public float emotionalDamage;
    public UnityEvent onAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        Attack(emotionalDamage);
    }

    public void Attack(float ed)
    {
        if(myReactor != null)
        {
            if(myReactor.subject != null)
            {
                myReactor.subject.TakeDamage(ed);
            }
        }
    }
}
