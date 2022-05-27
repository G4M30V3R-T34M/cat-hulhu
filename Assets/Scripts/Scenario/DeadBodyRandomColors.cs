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
        back.color = RandomColor.Generate();
        head.color = RandomColor.Generate();
        eyes.color = RandomColor.Generate();

        if (Random.Range(0f, 1f) <= ratio ) {
            GreenBlood();
        }
    }

    private void GreenBlood() {
        for (int i = 0; i < blood.Length; i++) {
            blood[i].color = Color.green;
        }
    }
}
