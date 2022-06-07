using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadBodyInteraction : Item
{
    [SerializeField] AudioClip investigateSound;
    string investigatorName;

    public void SetInvestigatorName(string investigatorName) {
        this.investigatorName = investigatorName;
    }

    protected override void ActionOnPick(GameObject character) {
        PlayerDialog.Instance.ShowText("Rest in peace, " + investigatorName);
    }
}
