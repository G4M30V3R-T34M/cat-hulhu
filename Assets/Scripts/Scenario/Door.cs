using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Item
{
    public string id = "";

    protected override void Awake() {
        base.Awake();
        if (id == "") {
            Debug.LogWarning("Id not set for door", gameObject);
        }
    }

    public override void Attack() {
        throw new System.NotImplementedException();
    }

    protected override void ActionOnPick(GameObject character) {
        if (id == "" || KeyManager.Instance.IsKeyCollected(id)) {
            gameObject.SetActive(false);
            // TODO: door open sound
        } else {
            PlayerDialog.Instance.ShowText("The door is closed, I need a key");
            // TODO: Error sound
        }
    }
}
