using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Feto; 

[RequireComponent(typeof(AIDestinationSetter))]
[RequireComponent(typeof(AIPath))]
[RequireComponent(typeof(HealthManager))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] string id;
    [SerializeField] private EnemyScriptable enemySettings;
    [SerializeField] private CircleCollider2D detectionCollider;
    [SerializeField] ObjectPool deadEnemiesPool;
    Collider2D enemyCollider;


    private AIDestinationSetter destinationSetter;
    HealthManager health;

    GameObject startPosition;
    Animator animator;

    bool isAttacking;
    bool isDead = false;

    private void Awake() {
        CheckId();
        destinationSetter = gameObject.GetComponent<AIDestinationSetter>();
        health = GetComponent<HealthManager>();
        health.SetUp(enemySettings.health); ;
        health.NoHealth += Die;
        detectionCollider.radius = enemySettings.detectionRadius;
        GetComponent<AIPath>().maxSpeed = enemySettings.speed;
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider2D>();
    }

    private void CheckId() {
        if (id == "") {
            Debug.LogError("Enemy without ID", gameObject);
        }
    }

    private void Start() {
        CheckDead();
        // Game object to remember initial position
        startPosition = new GameObject();
        startPosition.transform.position = this.gameObject.transform.position;
        startPosition.transform.localScale = this.gameObject.transform.localScale;
        startPosition.transform.rotation = this.gameObject.transform.rotation;
    }

    private void CheckDead() {
        DeadEnemy enemy = SaveDataManager.Instance.enemiesData.GetEnemy(id);
        if (enemy.id != EnemiesData.EMPTY_ENEMY) {
            DeadEnemyPoolable deadEnemy = (DeadEnemyPoolable)deadEnemiesPool.GetNext();
            deadEnemy.transform.SetPositionAndRotation(enemy.position, Quaternion.Euler(enemy.rotation));
            deadEnemy.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == (int)Layers.Player) {
            SetTarget(collision.gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (isAttacking) { return; }
        if (collision.gameObject.layer == (int)Layers.Player) {
            SetTarget(startPosition.transform);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.layer == (int)Layers.Player) {
            SetTarget(collision.gameObject.transform);
        }
    }

    public void Attack() {
        isAttacking = true;
        detectionCollider.enabled = false;
        SetTarget(null);
        animator.SetBool("isAttacking", true);
    }

    public void FinishAttack() {
        isAttacking = false;
        animator.SetBool("isAttacking", false);
        StartCoroutine(FinishAttackCoroutine());
    }

    public IEnumerator FinishAttackCoroutine() {
        yield return new WaitForSeconds(0.7f);
        SetTarget(startPosition.transform);
        detectionCollider.enabled = true;
    }

    private void SetTarget(Transform target) {
        if (isDead) { return; }
        destinationSetter.target = target;
    }

    public bool TargetIsPlayer() {
        return
            destinationSetter.target != null &&
            destinationSetter.target.gameObject.layer == (int)Layers.Player;
    }

    // Health manager function
    public void TakeDamage(int damage) {
        health.TakeDamage(damage);
        // TODO play sound
    }
    private void Die() {
        health.NoHealth -= Die;
        animator.SetTrigger("Death");
        isDead = true;
        destinationSetter.target = null;
        detectionCollider.enabled = false;
        enemyCollider.enabled = false;
        SaveDataManager.Instance.enemiesData.SaveEnemy(
            this.id,
            transform.position,
            transform.rotation.eulerAngles
        ) ;
        // TODO play sound
    }

}
