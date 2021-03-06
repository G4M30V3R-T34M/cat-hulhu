using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAIPath : AIPath
{
    private EnemyController enemyController;


    protected override void Awake() {
        base.Awake();
        enemyController = GetComponent<EnemyController>();
    }

    public override void OnTargetReached() {
        base.OnTargetReached();
        if (enemyController.TargetIsPlayer()) {
            enemyController.Attack();
        }
    }
}
