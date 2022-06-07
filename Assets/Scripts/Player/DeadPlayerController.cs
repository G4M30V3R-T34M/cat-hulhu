using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class DeadPlayerController : PoolableObject
{
    [SerializeField]
    SpriteRenderer back, head, eyes;

    PlayerDeadBodyInteraction investigation;

    protected void Awake() {
        investigation = GetComponentInChildren<PlayerDeadBodyInteraction>();
    }

    public void SetValues(Color back, Color head, Color eyes, Vector3 position, Vector3 rotation, string investigatorName) {
        this.back.color = back;
        this.head.color = head;
        this.eyes.color = eyes;
        transform.SetPositionAndRotation(position, Quaternion.Euler(rotation));
        investigation.SetInvestigatorName(investigatorName);
    }
}
