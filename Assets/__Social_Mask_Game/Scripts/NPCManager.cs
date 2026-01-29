using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public Color faceColour;
    public ItemCycler billboardSelector;
    public NPCBillboardManager myBillboardManager;
    public PlayerMaskAttacker myPlayerAttacker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        billboardSelector.ActivateItemRandom();

        myBillboardManager = billboardSelector.currentItem.GetComponent<NPCBillboardManager>();
        myPlayerAttacker.myBillboardManager = myBillboardManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
