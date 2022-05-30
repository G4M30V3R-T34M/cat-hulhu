using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class DeadPlayerColors : PoolableObject
{
    [SerializeField]
    SpriteRenderer back, head, eyes;

    public void SetValues(Color back, Color head, Color eyes, Vector3 position, Vector3 rotation) {
        this.back.color = back;
        this.head.color = head;
        this.eyes.color = eyes;
        transform.SetPositionAndRotation(position, Quaternion.Euler(rotation));
    }
}
