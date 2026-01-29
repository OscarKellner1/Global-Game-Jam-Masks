using UnityEngine;
using UnityEngine.Events;


public class NPCMaskReactor : MonoBehaviour
{
    public PlayerMaskManager subject;
    public NMAWalkTowards walkingManager;
    public Transform lookAtRoot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public UnityEvent onMaskA;
    public UnityEvent onMaskB;
    public UnityEvent onMaskC;
    public UnityEvent onMaskD;
    public UnityEvent onExit;

    public bool onMaskFlag;
    public int prevMaskType = -1;

    public void Update()
    {
        if (subject != null)
        {
            if (prevMaskType != subject.maskType)
                onMaskFlag = false;

            if (!onMaskFlag)
            {
                Debug.Log(" pmm:" + subject.maskType);

                if (subject.maskType == 0)
                    onMaskA.Invoke();

                if (subject.maskType == 1)
                    onMaskB.Invoke();

                if (subject.maskType == 2)
                    onMaskC.Invoke();

                if (subject.maskType == 3)
                    onMaskD.Invoke();

                onMaskFlag = true;
            }

            prevMaskType = subject.maskType;

            lookAtRoot.LookAt(subject.transform);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("NPCMaskReactor: " + other.name);
        subject = other.GetComponent<PlayerMaskManager>();
        onMaskFlag = false;

    }

    private void OnTriggerStay(Collider other)
    {
        if(subject == null)
        {
            Debug.Log("NPCMaskReactor: Subject Restored: " + other.name);
            subject = other.GetComponent<PlayerMaskManager>();
            onMaskFlag = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onExit.Invoke();

        walkingManager.destination = null;
        subject = null;
        onMaskFlag = false;
    }

    public void WalkToSubject()
    {
        if(subject != null)
        {
            walkingManager.destination = subject.transform;
        }
    }
}
