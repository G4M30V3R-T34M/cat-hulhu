using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDeadBodyInteraction : Item
{
    [SerializeField] AudioClip thinkingSound;

    string investigatorName;

    public void SetInvestigatorName(string investigatorName) {
        this.investigatorName = investigatorName;
    }

    protected override void ActionOnPick(GameObject character) {
        SoundManager.Instance.PlayClip(thinkingSound);
        PlayerDialog.Instance.ShowText("Rest in peace, " + investigatorName);
    }
}
