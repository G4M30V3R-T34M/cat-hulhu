using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    [SerializeField]
    string id = "";

    [SerializeField]
    GameObject DeadBodySprite;

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
        } else {
            DeadBodySprite.SetActive(false);
            trapCollider.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == (int)Layers.Player) {
            PlayerColor playerColor = collision.gameObject.GetComponent<PlayerColor>();
            Color[] colors = playerColor.GetColors();
            SaveDataManager.Instance.trapData.SaveTrap(id, colors[0], colors[1], colors[2]);

            // TODO: KILL PLAYER
            SceneManager.LoadScene((int)Scenes.TutorialLevel);
        }
    }
}
