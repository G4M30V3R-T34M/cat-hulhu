using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    public string id = "";

    protected override void Awake() {
        base.Awake();
        if (id == "") {
            Debug.LogError("Id not set for key", gameObject);
        }
    }

    protected override void Start() {
        if (KeyManager.Instance.IsKeyCollected(id)) {
            gameObject.SetActive(false);
        }
    }

    public override void Attack() {
        throw new System.NotImplementedException();
    }

    protected override void ActionOnPick() {
        KeyManager.Instance.CollectKey(id);
        gameObject.SetActive(false);
    }
}