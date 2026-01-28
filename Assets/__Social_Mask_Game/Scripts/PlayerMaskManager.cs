using UnityEngine;
using UnityEngine.Events;

public class PlayerMaskManager : MonoBehaviour
{
    public int maskType;
    public float emotionalHealth;
    public UnityEvent onTakeDamage;
    [Header("System Stuff")]
    public PlayerUIManager myUIManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myUIManager = GameObject.FindFirstObjectByType<PlayerUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMaskA()
    {
        maskType = 0;
    }

    void OnMaskB()
    {
        maskType = 1;
    }

    void OnMaskC()
    {
        maskType = 2;
    }

    void OnMaskD()
    {
        maskType = 3;
    }

    public void TakeDamage(float dmg)
    {
        emotionalHealth -= dmg;
        onTakeDamage.Invoke();
        myUIManager.onDamage.Invoke();
    }
}
