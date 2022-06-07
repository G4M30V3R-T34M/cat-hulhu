using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnDifficulty : MonoBehaviour
{
    SpriteRenderer sprite;

    [SerializeField] Difficulty[] difficulties;

    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        foreach (Difficulty diff in difficulties) {
            if (diff == SaveDataManager.Instance.gameData.difficulty) {
                sprite.enabled = false;
            }
        }
    }
}
