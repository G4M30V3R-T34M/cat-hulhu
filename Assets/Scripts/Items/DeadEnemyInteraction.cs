using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemyInteraction : Item
{
    [SerializeField] AudioClip thinkingSound;

    protected override void ActionOnPick(GameObject character) {
        SoundManager.Instance.PlayClip(thinkingSound);
        PlayerDialog.Instance.ShowText(itemSettings.description);
    }
}
