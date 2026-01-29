using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public PlayerMaskManager myPlayerManager;
    public TextMeshProUGUI tmpTexDisplay;
    public string prefix = "Emo.Health: ";
    public Image healthBar;

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

        healthBar.fillAmount = (myPlayerManager.emotionalHealth / 100);
    }
}
