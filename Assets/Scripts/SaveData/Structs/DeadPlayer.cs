using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DeadPlayer
{
    public DeadPlayer(
        string id,
        Color colorBack,
        Color colorHead,
        Color colorEyes,
        Vector3 position,
        Vector3 rotation
    ) {
        this.id = id;
        this.colorBack = colorBack;
        this.colorHead = colorHead;
        this.colorEyes = colorEyes;
        this.position = position;
        this.rotation = rotation;
    }

    public string id;
    public Color colorBack;
    public Color colorHead;
    public Color colorEyes;
    public Vector3 position;
    public Vector3 rotation;

}
