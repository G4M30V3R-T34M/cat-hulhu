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
        if(aIPath.destination.x != Mathf.Infinity) {
            direction = aIPath.desiredVelocity == new Vector3(0, 0, 0) ? transform.position - aIPath.destination : -aIPath.desiredVelocity;
            transform.up = direction;
        }
    }
}
