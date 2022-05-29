using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(AIDestinationSetter))]
[RequireComponent(typeof(AIPath))]
[RequireComponent(typeof(HealthManager))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyScriptable enemySettings;
    [SerializeField] private CircleCollider2D detectionCollider;
    Collider2D enemyCollider;


    private AIDestinationSetter destinationSetter;
    HealthManager health;

    GameObject startPosition;
    Animator animator;

    bool isAttacking;

    private void Awake() {
        destinationSetter = gameObject.GetComponent<AIDestinationSetter>();
        health = GetComponent<HealthManager>();
        health.SetUp(enemySettings.health); ;
        health.NoHealth += Die;
        detectionCollider.radius = enemySettings.detectionRadius;
        GetComponent<AIPath>().maxSpeed = enemySettings.speed;
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider2D>();
    }

    private void Start() {
        // Game object to remember initial position
        startPosition = new GameObject();
        startPosition.transform.position = this.gameObject.transform.position;
        startPosition.transform.localScale = this.gameObject.transform.localScale;
        startPosition.transform.rotation = this.gameObject.transform.rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == (int)Layers.Player) {
            destinationSetter.target = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (isAttacking) { return; }
        if (collision.gameObject.layer == (int)Layers.Player) {
            destinationSetter.target = startPosition.transform;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.layer == (int)Layers.Player) {
            destinationSetter.target = collision.gameObject.transform;
        }
    }

    public void Attack() {
        isAttacking = true;
        detectionCollider.enabled = false;
        destinationSetter.target = null;
        animator.SetBool("isAttacking", true);
    }

    public void FinishAttack() {
        isAttacking = false;
        animator.SetBool("isAttacking", false);
        StartCoroutine(FinishAttackCoroutine());
    }

    public IEnumerator FinishAttackCoroutine() {
        yield return new WaitForSeconds(0.7f);
        destinationSetter.target = startPosition.transform;
        detectionCollider.enabled = true;
    }

    public bool TargetIsPlayer() {
        return destinationSetter.target != null && destinationSetter.target.gameObject.layer == (int)Layers.Player;
    }

    // Health manager function
    public void TakeDamage(int damage) {
        health.TakeDamage(damage);
        // TODO play sound
    }
    private void Die() {
        health.NoHealth -= Die;
        animator.SetTrigger("Death");
        destinationSetter.target = null;
        detectionCollider.enabled = false;
        enemyCollider.enabled = false;
        //gameObject.SetActive(false);
        // TODO play sound
    }

}
