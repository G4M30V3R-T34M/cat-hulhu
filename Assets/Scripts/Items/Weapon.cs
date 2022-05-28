using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponScriptable weaponSettings;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (MustIgnore(collision)) { return; };
        print(collision.gameObject.layer);
        if(collision.gameObject.layer == (int)Layers.Player) {
            collision.GetComponent<PlayerController>().TakeDamage(weaponSettings.damage);
        }
    }

    private bool MustIgnore(Collider2D collision) {
        return gameObject.layer == collision.gameObject.layer;
    }

}
