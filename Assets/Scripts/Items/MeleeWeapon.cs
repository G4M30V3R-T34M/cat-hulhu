using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Item
{
    public override void Attack() {
        // TODO implement attack
        Debug.Log("Attacking");
    }

    protected override void ActionOnPick(GameObject chracter) {}
}
