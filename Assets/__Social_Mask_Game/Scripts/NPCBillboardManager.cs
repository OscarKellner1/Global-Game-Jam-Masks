using UnityEngine;

public class NPCBillboardManager : MonoBehaviour
{
    public string playerTag = "Player";
    public Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(playerTransform == null)
            playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null)
            transform.LookAt(playerTransform.position);
    }
}
