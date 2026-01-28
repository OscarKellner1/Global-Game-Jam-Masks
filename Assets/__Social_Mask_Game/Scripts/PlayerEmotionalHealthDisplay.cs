using UnityEngine;
using TMPro;

public class PlayerEmotionalHealthDisplay : MonoBehaviour
{
    public PlayerMaskManager myPlayerManager;
    public TextMeshProUGUI tmpTexDisplay;
    public string prefix = "Emo.Health: ";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(myPlayerManager == null)
            myPlayerManager = Object.FindFirstObjectByType<PlayerMaskManager>();
    }

    // Update is called once per frame
    void Update()
    {
        tmpTexDisplay.text = prefix + myPlayerManager.emotionalHealth.ToString();
    }
}
