using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChanger : MonoBehaviour
{
    public SkateColorChanger SkateColorChanger;  
    public int skateIndex;  // Index for the skate color

    public Button button;

    private void Start()
    {
        Debug.Log($"Button clicked! Skate index: {skateIndex}");
        // listener for button click
        button.onClick.AddListener(ChangeSkateColor);
    }

    private void ChangeSkateColor()
    {
        SkateColorChanger.ChangeSkateColor(skateIndex);
    }
}
