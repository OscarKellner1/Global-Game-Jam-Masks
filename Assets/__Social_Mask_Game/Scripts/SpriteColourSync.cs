using UnityEngine;

public class SpriteColourSync : MonoBehaviour
{
    public SpriteRenderer spriteRef;
    public SpriteRenderer mySprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mySprite.color = spriteRef.color;
    }
}
