using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Item
{
    [Tooltip("Set 0 for open doors, set key id for key doors")]
    public string id = "";

    [SerializeField]
    bool returnToBigMap = false;

    protected override void Awake() {
        base.Awake();
        if (id == "") {
            Debug.LogWarning("Id not set for door", gameObject);
        }
    }

    protected override void ActionOnPick(GameObject character) {
        if (id == "0" || SaveDataManager.Instance.keysData.IsKeyCollected(id)) {
            PerformAction();
            // TODO: door open sound
        } else {
            PlayerDialog.Instance.ShowText("The door is closed, I need a key");
            // TODO: Error sound
        }
    }

    protected void PerformAction() {
        if (returnToBigMap) {
            SceneManager.LoadScene((int)Scenes.BigMap);
        } else {
            gameObject.SetActive(false);
        }
    }
}
