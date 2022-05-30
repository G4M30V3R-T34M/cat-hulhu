using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBodyRandomColors : MonoBehaviour
{
    [SerializeField]
    string id = "";

    [SerializeField]
    SpriteRenderer back, head, eyes;

    [SerializeField, Range(0,1)]
    float ratio;

    [SerializeField]
    SpriteRenderer[] blood;


    private void Awake() {
        DeadBody body = SaveDataManager.Instance.deadBodyData.GetDeadBody(id);

        if (body.id == DeadBodyData.EMPTY_DEAD) {
            SetNewColors();
        } else {
            AssignColors(body);
        }
        checkID();
    }

    private void SetNewColors() {
        back.color = RandomColor.Generate();
        head.color = RandomColor.Generate();
        eyes.color = RandomColor.Generate();

        if (Random.Range(0f, 1f) <= ratio ) {
            GreenBlood();
        }

        SaveDataManager.Instance.deadBodyData.SaveDead(
            id, back.color, head.color, eyes.color, blood[0].color);
    }

    private void AssignColors (DeadBody body) {
        back.color = body.colorBack;
        head.color = body.colorHead;
        eyes.color = body.colorEyes;
        for (int i = 0; i < blood.Length; i++) {
            blood[i].color = body.bloodColor;
        }
    }

    private void checkID() {
        if (id == "") {
            Debug.LogError("DeadBody without id", gameObject);
        }
    }

    private void GreenBlood() {
        for (int i = 0; i < blood.Length; i++) {
            blood[i].color = Color.green;
        }
    }
}
