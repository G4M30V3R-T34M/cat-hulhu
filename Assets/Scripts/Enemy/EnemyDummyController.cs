using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(HealthManager))]
public class EnemyDummyController : MonoBehaviour
{
    [SerializeField] private AudioClip hit;
    SoundManager soundManager;

    [SerializeField] private EnemyScriptable enemySettings;

    [SerializeField] GameObject drop;

    HealthManager health;
    Animator animator;

    private void Awake() {
        health = GetComponent<HealthManager>();
        health.SetUp(enemySettings.health); ;
        health.NoHealth += Die;
        animator = GetComponent<Animator>();
        soundManager = GameObject.FindGameObjectWithTag("EffectManager").GetComponent<SoundManager>();
    }

    // Health manager function
    public void TakeDamage(int damage) {
        soundManager.PlayClip(hit);
        health.TakeDamage(damage);
    }
    private void Die() {
        health.NoHealth -= Die;
        drop.SetActive(true);
        gameObject.SetActive(false);
    }

}
