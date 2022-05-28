using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorsManager : MonoBehaviour
{
    [SerializeField]
    Slider[] color1, color2, color3;

    [SerializeField]
    Image back, head, eyes;

    private void Awake() {
        GenerateColor(color1, back);
        GenerateColor(color2, head);
        GenerateColor(color3, eyes);
    }

    public void UpdateColor(int colorInt) {
        switch (colorInt) {
            case 0:
                DoUpdateColor(color1, back);
                break;
            case 1:
                DoUpdateColor(color2, head);
                break;
            case 2:
                DoUpdateColor(color3, eyes);
                break;
        }
    }

    public void DoUpdateColor(Slider[] sliders, Image image) {
        Color color = new Color(
            sliders[0].value,
            sliders[1].value,
            sliders[2].value);

        image.color = color;
    }

    private void GenerateColor(Slider[] sliders, Image image) {
        Color color = RandomColor.Generate();

        sliders[0].value = color.r;
        sliders[1].value = color.g;
        sliders[2].value = color.b;

        image.color = color;
    }
}
