using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ActivatedTrap 
{
    public ActivatedTrap (string id, Color back, Color head, Color eyes, string investigatorName) {
        this.id = id;
        this.backColor = back;
        this.headColor = head;
        this.eyesColor = eyes;
        this.investigatorName = investigatorName;
    }

    public string id;
    public Color backColor;
    public Color headColor;
    public Color eyesColor;
    public string investigatorName;
}
