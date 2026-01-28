using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    public PlayerMaskManager myPlayerManager;
    public TextMeshProUGUI tmpTexDisplay;
    public string prefix = "Emo.Health: ";

    public UnityEvent onDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(myPlayerManager == null)
            myPlayerManager = Object.FindFirstObjectByType<PlayerMaskManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tmpTexDisplay != null)
            tmpTexDisplay.text = prefix + myPlayerManager.emotionalHealth.ToString();
    }
}
