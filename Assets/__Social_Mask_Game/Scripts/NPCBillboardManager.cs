using UnityEngine;
using UnityEngine.AI;

public class NPCBillboardManager : MonoBehaviour
{
    [Header("Player References")]
    public string playerTag = "Player";
    public Transform playerTransform;


    [Header("NPC Billboard References")]
    public NavMeshAgent agent;
    public Transform npcRootTransform;
    public Transform billboardLookTransfom;    
    public GameObject frontOnSprite;
    public GameObject sideLeftSprite;
    public GameObject sideRightSprite;
    public GameObject backSprite;

    [Header("Billboard Random Colour")]
    public Color colRangeStart = Color.white;
    public Color colRangeEnd = Color.grey;
    public Color billBoardTint = Color.black;

    [Header("Billboard Settings")]
    public float sideAngleThreshold;
    public float backAngleThreshold;
    public float renderDistance = 25;

    [Header("System Stuff")]
    public Animator activeAnimator;
    public float angle2Player;
    public int angleMode = -1;
    public int prevAngleMode;
    public float distance2Player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(playerTransform == null)
            playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;

        if(billBoardTint == Color.black)
        {
            billBoardTint = Color.Lerp(colRangeStart, colRangeEnd, Random.Range(0.0f, 1.0f));

            frontOnSprite.GetComponent<SpriteRenderer>().color = billBoardTint;
            sideLeftSprite.GetComponent<SpriteRenderer>().color = billBoardTint;
            sideRightSprite.GetComponent<SpriteRenderer>().color = billBoardTint;
            backSprite.GetComponent<SpriteRenderer>().color = billBoardTint;
        }
    }

    // Update is called once per frame
    void Update()
    {   

        if (playerTransform != null && billboardLookTransfom != null && npcRootTransform != null)
        {
            distance2Player = Vector3.Distance(playerTransform.position, transform.position);

            //BillBoard();

            if (distance2Player <= renderDistance)
            {
                HandleAngles();
                AnimationSync();
            }
            else
            {
                DisableSprites();
            }
        }

        prevAngleMode = angleMode;
    }

    public void BillBoard()
    {
        
        //transform.LookAt(playerTransform.position);
    }

    public void HandleAngles()
    {
        angle2Player = Vector3.SignedAngle(npcRootTransform.forward, billboardLookTransfom.forward, npcRootTransform.up);

        //show the back facing sprite
        if (angle2Player < (180 - backAngleThreshold) || angle2Player > (-180 + backAngleThreshold))
        {
            angleMode = 3;
        }

        //show the right facing sprite
        if (angle2Player < sideAngleThreshold && angle2Player < (180 - backAngleThreshold))
        {
            angleMode = 1;
        }

        //show the left facing sprite
        if (angle2Player > -sideAngleThreshold && angle2Player > (-180 + backAngleThreshold))
        {
            angleMode = 2;
        }

        //show the front facing sprite
        if (angle2Player < sideAngleThreshold && angle2Player > -sideAngleThreshold)
        {
            angleMode = 0;
        }

        if(prevAngleMode != angleMode)
        {
            //show the front facing sprite
            if (angleMode == 0)
            {
                frontOnSprite.SetActive(true);
                sideLeftSprite.SetActive(false);
                sideRightSprite.SetActive(false);
                backSprite.SetActive(false);

                activeAnimator = frontOnSprite.GetComponent<Animator>();
            }

            //show the right facing sprite
            if (angleMode == 1)
            {
                frontOnSprite.SetActive(false);
                sideLeftSprite.SetActive(true);
                sideRightSprite.SetActive(false);
                backSprite.SetActive(false);

                activeAnimator = sideLeftSprite.GetComponent<Animator>();
            }

            //show the left facing sprite
            if (angleMode == 2)
            {
                frontOnSprite.SetActive(false);
                sideLeftSprite.SetActive(false);
                sideRightSprite.SetActive(true);
                backSprite.SetActive(false);

                activeAnimator = sideRightSprite.GetComponent<Animator>();
            }

            //show the back facing sprite
            if (angleMode == 3)
            {
                frontOnSprite.SetActive(false);
                sideLeftSprite.SetActive(false);
                sideRightSprite.SetActive(false);
                backSprite.SetActive(true);

                activeAnimator= backSprite.GetComponent<Animator>();
            }
        }
    }

    void AnimationSync()
    {
        if(activeAnimator != null)
        {
            activeAnimator.SetFloat("speed", agent.velocity.magnitude);
        }
    }

    public void DisableSprites()
    {
        frontOnSprite.SetActive(false);
        sideLeftSprite.SetActive(false);
        sideRightSprite.SetActive(false);
        backSprite.SetActive(false);
    }
}
