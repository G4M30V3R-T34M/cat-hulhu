using UnityEngine;

public struct DeadEnemy
{
    public DeadEnemy(string id, Vector3 position, Vector3 rotation) {
        this.id = id;
        this.position = position;
        this.rotation = rotation;
    }

    public string id;
    public Vector3 position;
    public Vector3 rotation;
}
