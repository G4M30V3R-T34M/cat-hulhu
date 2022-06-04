using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DeadBody
{
    public string id;
    public Color colorBack;
    public Color colorHead;
    public Color colorEyes;
    public Color bloodColor;

    public DeadBody(
        string id,
        Color colorBack,
        Color colorHead,
        Color colorEyes,
        Color bloodColor
    ) {
        this.id = id;
        this.colorBack = colorBack;
        this.colorHead = colorHead;
        this.colorEyes = colorEyes;
        this.bloodColor = bloodColor;
    }
}
