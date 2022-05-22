using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : Item
{
    public override void Attack() {
        throw new System.NotImplementedException();
    }

    protected override void ActionOnPick() {
        // TODO open canvas and  display clue description
        Debug.Log(itemSettings.description);
    }
}
