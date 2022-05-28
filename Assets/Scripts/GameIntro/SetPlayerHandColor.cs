using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerHandColor : MonoBehaviour
{
    [SerializeField]
    PlayerSettingsScriptable player;

    Image image;

    private void Awake() {
        image = GetComponent<Image>();
        image.color = player.color1;
    }
}
