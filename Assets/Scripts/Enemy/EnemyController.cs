using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(AIDestinationSetter))]
public class EnemyController : MonoBehaviour
{
    AIDestinationSetter destinationSetter;

    GameObject startPosition;

    private void Awake() {
        destinationSetter = gameObject.GetComponent<AIDestinationSetter>();
    }

    private void Start() {
        startPosition = new GameObject();
        startPosition.transform.position = this.gameObject.transform.position;
        startPosition.transform.localScale = this.gameObject.transform.localScale;
        startPosition.transform.rotation = this.gameObject.transform.rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            destinationSetter.target = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            destinationSetter.target = startPosition.transform;
        }
    }
}
