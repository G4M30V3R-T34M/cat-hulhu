using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    public EnemyAIPath aIPath;

    Vector2 direction;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        faceEnemy();
    }

    void faceEnemy() {
        direction = aIPath.desiredVelocity;

        transform.up = -direction;
    }
}
