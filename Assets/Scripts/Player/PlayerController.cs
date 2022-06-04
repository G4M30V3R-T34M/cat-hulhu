using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSettingsScriptable playerSettings;

    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip death;

    public Item weapon;
    public GameObject itemToPick;
    private HealthManager health;
    public bool pickableItem;
    PlayerColor playerColors;
    bool isDying = false;

    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        health = GetComponent<HealthManager>();
        playerColors = GetComponent<PlayerColor>();
    }

    private void Start() {
        SetUpHealth();
    }

    private void Update() {
        if (CanPickUp() && IsTryingToPick()) {
            PickItem();
        }
        else if (IsTryingToAttack() && CanAttack()) {
            AttackWithWeapon();
        }
    }

    private void SetUpHealth() {
        int savedHealth = SaveDataManager.Instance.playerData.health;
        if (savedHealth == 0) {
            health.SetUp(playerSettings.health);
            SaveDataManager.Instance.playerData.health = playerSettings.health;
        } else {
            health.SetUp(savedHealth);
        }
        health.NoHealth += Die;
        HUD.Instance.UpdateLives();
    }

    public void SaveHealth() {
        SaveDataManager.Instance.playerData.health = health.GetCurrentHealth();
    }

    private bool CanPickUp() {
        return pickableItem;
    }

    private bool IsTryingToPick() {
        return Input.GetKeyDown(KeyCode.E);
    }

    private void PickItem() {
        Item item = itemToPick.GetComponent<Item>();
        item.Pick(this.gameObject);
        if (item.basicItem) {
            pickableItem = false;
        }
        if (item.IsWeapon()) {
            if (weapon != null) {
                weapon.DropItem(this.transform.position);
            }
            weapon = item;
        }
    }

    private bool IsTryingToAttack() {
        return Input.GetKeyDown(KeyCode.Mouse0);
    }

    private bool CanAttack() {
        return weapon != null && weapon.IsWeapon();
    }

    private void AttackWithWeapon() {
        animator.SetTrigger("attack");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (IsPickable(collision)) {
            itemToPick = collision.gameObject;
            pickableItem = true;
        }
    }

    private bool IsPickable(Collider2D collision) {
        return collision.gameObject.layer == (int)Layers.Items;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (IsPickable(collision)) {
            itemToPick = null;
            pickableItem = false;
        }
    }

    private void Die() {
        if (!isDying) {
            SoundManager.Instance.PlayClip(death);
            SaveDeadBody();
            animator.SetTrigger("Death");
            isDying = true;
        }
    }

    public void TakeDamage(int damage) {
        if (!isDying) {
            health.TakeDamage(damage);
            SaveDataManager.Instance.playerData.health = health.GetCurrentHealth();

            HUD.Instance.UpdateLives();
            SoundManager.Instance.PlayClip(hit);
        }
    }

    public void DeathByTrap() {
        health.NoHealth -= Die;
        SoundManager.Instance.PlayClip(death);
        health.TakeDamage(playerSettings.health);
        SaveDataManager.Instance.playerData.health = health.GetCurrentHealth();
        animator.SetTrigger("Death");
    }

    private void SaveDeadBody() {
        SaveDataManager.Instance.deadPlayerData.SaveDeadPlayer(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name,
            playerColors.back.color,
            playerColors.head.color,
            playerColors.eyes.color,
            transform.position,
            transform.rotation.eulerAngles,
            SaveDataManager.Instance.playerData.investigatorName
            );
    }

    public void RespawnPlayer() {
        Spawner.RespawnPlayer();
    }
}
