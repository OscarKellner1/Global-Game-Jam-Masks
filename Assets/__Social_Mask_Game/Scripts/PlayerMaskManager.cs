using UnityEngine;

public class PlayerMaskManager : MonoBehaviour
{
    public int maskType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}
