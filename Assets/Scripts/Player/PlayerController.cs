using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSettingsScriptable playerSettings;

    public Item weapon;
    public GameObject itemToPick;
    private HealthManager health;
    public bool pickableItem;

    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        health = GetComponent<HealthManager>();
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
        } else {
            health.SetUp(savedHealth);
        }
        health.NoHealth += Die;
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
        pickableItem = false;
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
        gameObject.SetActive(false);
        // TODO implement death and respawn
    }

    public void TakeDamage(int damage) {
        health.TakeDamage(damage);
        // TODO play sound
    }
}
