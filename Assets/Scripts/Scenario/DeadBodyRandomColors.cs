using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBodyRandomColors : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer back, head, eyes;

    [SerializeField, Range(0,1)]
    float ratio;
    [SerializeField]
    SpriteRenderer[] blood;


    private void Awake() {
        back.color = RandomColors();
        head.color = RandomColors();
        eyes.color = RandomColors();

        if (Random.Range(0f, 1f) <= ratio ) {
            GreenBlood();
        }
    }

    private Color RandomColors() {
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
    }

    private void GreenBlood() {
        for (int i = 0; i < blood.Length; i++) {
            blood[i].color = Color.green;
        }
    }
}
