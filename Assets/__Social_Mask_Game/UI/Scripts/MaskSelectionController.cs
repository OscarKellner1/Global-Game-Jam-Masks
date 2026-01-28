using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MaskSelectionController : MonoBehaviour
{
    [Header("Buttons in visual order (left → right)")]
    public Button[] maskButtons;

    [Header("Each element is the Outline child GameObject for the matching button")]
    public GameObject[] outlines;

    private int currentIndex = -1;

    void Start()
    {
        // Bind button clicks
        for (int i = 0; i < maskButtons.Length; i++)
        {
            int index = i;
            maskButtons[i].onClick.AddListener(() => SelectMask(index));
        }

        // Optional: default selection
        SelectMask(0);
    }

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.digit1Key.wasPressedThisFrame || kb.numpad1Key.wasPressedThisFrame) SelectMask(0);
        if (kb.digit2Key.wasPressedThisFrame || kb.numpad2Key.wasPressedThisFrame) SelectMask(1);
        if (kb.digit3Key.wasPressedThisFrame || kb.numpad3Key.wasPressedThisFrame) SelectMask(2);
        if (kb.digit4Key.wasPressedThisFrame || kb.numpad4Key.wasPressedThisFrame) SelectMask(3);
    }

    public void SelectMask(int index)
    {
        if (index < 0 || index >= maskButtons.Length) return;

        currentIndex = index;

        // Turn all outlines off
        for (int i = 0; i < outlines.Length; i++)
        {
            if (outlines[i] != null)
                outlines[i].SetActive(false);
        }

        // Turn selected outline on
        if (index < outlines.Length && outlines[index] != null)
            outlines[index].SetActive(true);

        Debug.Log("Selected mask index: " + index);

        // TODO: Hook gameplay logic here
    }
}
