using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(HealthManager))]
public class EnemyDummyController : MonoBehaviour
{
    [SerializeField] private AudioClip hit;

    [SerializeField] private EnemyScriptable enemySettings;

    [SerializeField] GameObject drop;

    [SerializeField] string id = "";
    HealthManager health;
    Animator animator;

    private void Awake() {
        CheckId();
        health = GetComponent<HealthManager>();
        health.SetUp(enemySettings.health); ;
        health.NoHealth += Die;
        animator = GetComponent<Animator>();
    }

    private void Start() {
        if (SaveDataManager.Instance.dummyEnemiesData.IsDummyKilled(id)) {
            this.gameObject.SetActive(false);
        }
    }

    void CheckId() {
        if (id == "") {
            Debug.LogError("Dummy enemy without id", gameObject);
        }
    }

    // Health manager function
    public void TakeDamage(int damage) {
        SoundManager.Instance.PlayClip(hit);
        health.TakeDamage(damage);
    }
    private void Die() {
        health.NoHealth -= Die;
        drop.SetActive(true);
        SaveDataManager.Instance.dummyEnemiesData.KillDummy(id);
        gameObject.SetActive(false);
    }

}
