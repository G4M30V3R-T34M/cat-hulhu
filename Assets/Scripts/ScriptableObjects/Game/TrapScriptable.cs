using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TrapScriptable", menuName = "Scriptables/TrapScriptable", order = 4)]
public class TrapScriptable : ScriptableObject
{
    public string id;

    public Color backColor, headColor, eyesColor;
}
