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
        if (SaveDataManager.Instance.keysData.IsKeyCollected(id)) {
            gameObject.SetActive(false);
        }
    }

    protected override void ActionOnPick(GameObject character) {
        SaveDataManager.Instance.keysData.CollectKey(id);
        if (itemSettings.description != string.Empty) {
            PlayerDialog.Instance.ShowText(itemSettings.description);
        }
        gameObject.SetActive(false);
    }
}
