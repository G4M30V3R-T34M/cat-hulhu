using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : Item
{
    public string id = "";

    protected override void Awake() {
        base.Awake();
        if (id == "") {
            Debug.LogError("Id not set for clue", gameObject);
        }
    }

    protected override void Start() {
        if (CluesManager.Instance.IsClueCollected(id)) {
            gameObject.SetActive(false);
        }
    }

    protected override void ActionOnPick(GameObject character) {
        CluesManager.Instance.CollectClue(id);
        gameObject.SetActive(false);
        PlayerDialog.Instance.ShowText(itemSettings.description);
    }
}
