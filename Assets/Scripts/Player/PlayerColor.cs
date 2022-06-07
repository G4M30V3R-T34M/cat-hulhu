using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer back, head, eyes;

    private void Start() {
        UpdateColors();
    }

    public void UpdateColors() {
        back.color = SaveDataManager.Instance.playerData.backColor;
        head.color = SaveDataManager.Instance.playerData.headColor;
        eyes.color = SaveDataManager.Instance.playerData.eyesColor;
    }

    public Color[] GetColors() {
        return new Color[] {
            back.color,
            head.color,
            eyes.color
        };
    }
}
