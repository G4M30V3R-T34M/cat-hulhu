using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ActivatedTrap 
{
    public ActivatedTrap (string id, Color back, Color head, Color eyes) {
        this.id = id;
        this.backColor = back;
        this.headColor = head;
        this.eyesColor = eyes;
    }

    public string id;
    public Color backColor;
    public Color headColor;
    public Color eyesColor;
}
