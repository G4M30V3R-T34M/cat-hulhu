using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(HealthManager))]
public class EnemyDummyController : MonoBehaviour
{
    [SerializeField] private EnemyScriptable enemySettings;

    [SerializeField] GameObject drop;

    HealthManager health;
    Animator animator;

    private void Awake() {
        health = GetComponent<HealthManager>();
        health.SetUp(enemySettings.health); ;
        health.NoHealth += Die;
        animator = GetComponent<Animator>();
    }

    // Health manager function
    public void TakeDamage(int damage) {
        health.TakeDamage(damage);
        // TODO play sound
    }
    private void Die() {
        health.NoHealth -= Die;
        drop.SetActive(true);
        gameObject.SetActive(false);
        // TODO play sound
    }

}
