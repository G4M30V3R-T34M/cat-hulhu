using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    private Animator animator;

    protected override void Awake() {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (MustIgnore(collision)) { return; };

        if(collision.gameObject.layer == (int)Layers.Player) {
            collision.GetComponent<PlayerController>().TakeDamage(itemSettings.damage);
        } else if (collision.gameObject.layer == (int)Layers.Enemy) {
            collision.GetComponent<EnemyController>().TakeDamage(itemSettings.damage);
        }
    }

    private bool MustIgnore(Collider2D collision) {
        return gameObject.layer == collision.gameObject.layer;
    }

    protected override void ActionOnPick(GameObject character) {
        // TODO play pick up sound
    }


}
