using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    static bool playerDead = false;

    [SerializeField]
    string id = "";

    [SerializeField]
    GameObject DeadBodySprite;

    TrapDeadBodyInteraction interaction;

    [SerializeField]
    Collider2D obstacle;

    Collider2D trapCollider;

    [SerializeField]
    SpriteRenderer backColor, headColor, eyesColor;

    private void Awake() {
        if (id == "") {
            Debug.LogError("Trap without id ", gameObject);
        }

        trapCollider = GetComponent<Collider2D>();
        interaction = GetComponentInChildren<TrapDeadBodyInteraction>();
        playerDead = false;
    }

    private void Start() {
        LoadTrapData();
    }

    private void LoadTrapData() {
        ActivatedTrap trap = SaveDataManager.Instance.trapData.GetTrap(id);
        if (trap.id !=  TrapData.EMPTY_TRAP) {
            backColor.color = trap.backColor;
            headColor.color = trap.headColor;
            eyesColor.color = trap.eyesColor;
            DeadBodySprite.SetActive(true);
            trapCollider.enabled = false;
            obstacle.enabled = false;
            interaction.gameObject.SetActive(true);
            interaction.SetInvestigatorName(trap.investigatorName);
        } else {
            DeadBodySprite.SetActive(false);
            trapCollider.enabled = true;
            interaction.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == (int)Layers.Player && !playerDead) {
            playerDead = true;
            PlayerColor playerColor = collision.gameObject.GetComponent<PlayerColor>();
            Color[] colors = playerColor.GetColors();
            string investigatorName = SaveDataManager.Instance.playerData.investigatorName;
            SaveDataManager.Instance.trapData.SaveTrap(id, colors[0], colors[1], colors[2], investigatorName);

            collision.gameObject.GetComponent<PlayerController>().DeathByTrap();
        }
    }
}
