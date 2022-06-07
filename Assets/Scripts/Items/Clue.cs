using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : Item
{
    [SerializeField] AudioClip cluePicked, thinking;
    [SerializeField] GameObject playerAid;

    public string id = "";
    bool searched = false;

    protected override void Awake() {
        base.Awake();
        if (id == "") {
            Debug.LogError("Id not set for clue", gameObject);
        }
    }

    protected override void Start() {
        if (SaveDataManager.Instance.cluesData.IsClueCollected(id)) {
            searched = true;
            playerAid.SetActive(false);
        }
    }

    protected override void ActionOnPick(GameObject character) {
        if (!searched) {
            SaveDataManager.Instance.cluesData.CollectClue(id);
            HUD.Instance.UpdateClueNumber();
            playerAid.SetActive(false);
            SoundManager.Instance.PlayClip(cluePicked);
            searched = true;
        } else {
            SoundManager.Instance.PlayClip(thinking);
        }
        PlayerDialog.Instance.ShowText(itemSettings.description);
    }
}
