using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptable", menuName = "Scriptables/EnemyScriptable", order = 5)]
public class EnemyScriptable : ScriptableObject
{
    [Range(1, 10)]
    public int health;

    [Range(1, 10)]
    public float detectionRadius;

    [Range(1, 20)]
    public float speed;

    [Range(0, 5)]
    public float attackCooldown;
}
