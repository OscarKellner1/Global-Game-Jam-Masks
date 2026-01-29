using UnityEngine;

public class NPCBillboardManager : MonoBehaviour
{
    [Header("Player References")]
    public string playerTag = "Player";
    public Transform playerTransform;
    public float angle2Player;

    [Header("Billboard References")]
    public Transform npcRootTransform;
    public Transform billboardRoot;
    public GameObject frontOnSprite;
    public GameObject sideLeftSprite;
    public GameObject sideRightSprite;
    public GameObject backSprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(playerTransform == null)
            playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null && billboardRoot != null && npcRootTransform != null)
        {
            BillBoard();
            HandleAngles();
        }
    }

    public void BillBoard()
    {
        
        transform.LookAt(playerTransform.position);
    }

    public void HandleAngles()
    {
        angle2Player = Vector3.Angle(npcRootTransform.forward, billboardRoot.forward);
    }
}
