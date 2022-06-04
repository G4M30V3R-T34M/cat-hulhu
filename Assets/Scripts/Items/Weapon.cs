using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    private Animator animator;

    [SerializeField, Range(0, 2)]
    float damageWaitTimeForEnemies;
    float lastAttack;

    protected override void Awake() {
        base.Awake();
        animator = GetComponent<Animator>();
        lastAttack = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (MustIgnore(collision)) { return; };

        if(collision.gameObject.layer == (int)Layers.Player && TimeBetweenAttacks()) {
            collision.GetComponent<PlayerController>()?.TakeDamage(itemSettings.damage);
            lastAttack = Time.time;
        } else if (collision.gameObject.layer == (int)Layers.Enemy) {
            collision.GetComponent<EnemyController>()?.TakeDamage(itemSettings.damage);
            collision.GetComponent<EnemyDummyController>()?.TakeDamage(itemSettings.damage);
        }
    }

    bool TimeBetweenAttacks() {
        return (Time.time - lastAttack) > damageWaitTimeForEnemies;
    }

    private bool MustIgnore(Collider2D collision) {
        return gameObject.layer == collision.gameObject.layer;
    }

    protected override void ActionOnPick(GameObject character) {
        // TODO play pick up sound
    }


}
