using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class DeadPlayerPool : MonoBehaviour
{
    ObjectPool pool;

    protected void Awake() {
        pool = GetComponent<ObjectPool>();
    }

    protected void Start() {
        GenerateDeadPlayers();
    }

    private void GenerateDeadPlayers() {
        foreach (DeadPlayer deadPlayer in SaveDataManager.Instance.deadPlayerData.deadPlayers) {
            if (deadPlayer.id == UnityEngine.SceneManagement.SceneManager.GetActiveScene().name) {
                DeadPlayerColors deadPlayerColors = (DeadPlayerColors)pool.GetNext();
                deadPlayerColors.SetValues(
                    deadPlayer.colorBack,
                    deadPlayer.colorHead,
                    deadPlayer.colorEyes,
                    deadPlayer.position,
                    deadPlayer.rotation);
                deadPlayerColors.gameObject.SetActive(true);
            }
        }
    }
}
