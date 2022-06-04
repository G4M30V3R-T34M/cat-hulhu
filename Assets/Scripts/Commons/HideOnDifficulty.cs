using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnDifficulty : MonoBehaviour
{
    SpriteRenderer sprite;

    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        if (SaveDataManager.Instance.gameData.difficulty == Difficulty.HARD) {
            sprite.enabled = false;
        }
    }
}
