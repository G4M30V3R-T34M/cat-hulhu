using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerHandColor : MonoBehaviour
{
    Image image;

    private void Awake() {
        image = GetComponent<Image>();
    }

    private void Start() {
        image.color = SaveDataManager.Instance.playerData.backColor;
    }
}
