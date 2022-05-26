using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField]
    PlayerSettingsScriptable playerSettings;

    [SerializeField]
    SpriteRenderer back, head, eyes;

    private void Awake() {
        UpdateColors();
    }

    public void UpdateColors() {
        back.color = playerSettings.color1;
        head.color = playerSettings.color2;
        eyes.color = playerSettings.color3;
    }

    public Color[] GetColors() {
        return new Color[] {
            back.color,
            head.color,
            eyes.color
        };
    }
}
