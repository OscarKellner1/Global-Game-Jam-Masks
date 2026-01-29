using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public Color faceColour;
    public ItemCycler billboardSelector;
    public NPCBillboardManager myBillboardManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        billboardSelector.ActivateItemRandom();

        myBillboardManager = billboardSelector.currentItem.GetComponent<NPCBillboardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
