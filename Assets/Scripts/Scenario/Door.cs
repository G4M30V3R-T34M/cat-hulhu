using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Item
{
    [SerializeField] AudioClip closedDoor;
    [SerializeField] AudioClip openDoor;
    SoundManager soundManager;

    [Tooltip("Set 0 for open doors, set key id for key doors")]
    public string id = "";

    [SerializeField]
    bool returnToBigMap = false;

    protected override void Awake() {
        base.Awake();
        soundManager = GameObject.FindGameObjectWithTag("EffectManager").GetComponent<SoundManager>();
    }

    protected override void Start() {
        base.Start();
        CheckOpenDoor();
    }

    private void CheckId() {
        if (id == "") {
            Debug.LogWarning("Id not set for door", gameObject);
        }
    }

    private void CheckOpenDoor() {
        if (SaveDataManager.Instance.doorsData.IsDoorOpen(id) && !returnToBigMap) {
            gameObject.SetActive(false);
        }
    }

    protected override void ActionOnPick(GameObject character) {
        if (id == "0" || SaveDataManager.Instance.keysData.IsKeyCollected(id)) {
            soundManager.PlayClip(openDoor);
            PerformAction(character);
        } else {
            PlayerDialog.Instance.ShowText("The door is closed, I need a key");
            soundManager.PlayClip(closedDoor);
        }
    }

    protected void PerformAction(GameObject character) {
        if (returnToBigMap) {
            character.GetComponent<PlayerController>().SaveHealth();
            SceneManager.Instance.LoadScene((int)Scenes.BigMap);
        } else {
            SaveDataManager.Instance.doorsData.OpenDoor(id);
            gameObject.SetActive(false);
        }
    }
}
