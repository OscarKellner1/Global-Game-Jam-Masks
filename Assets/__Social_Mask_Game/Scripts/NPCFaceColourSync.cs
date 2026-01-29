using UnityEngine;

public class NPCFaceColourSync : MonoBehaviour
{
    public NPCManager myNPCManager;
    public SpriteRenderer myRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (myNPCManager == null)
            myNPCManager = GetComponentInParent<NPCManager>();

        if (myRenderer == null)
            myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myNPCManager != null && myRenderer != null)
            myRenderer.color = myNPCManager.faceColour;
    }
}
