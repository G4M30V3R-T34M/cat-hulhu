using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =" GameDataScriptable", menuName = "Scriptables/GameDataScriptable", order = 3)]
public class GameDataScriptable : ScriptableObject
{
    public int lives;

    public List<string> clues;

    public List<string> keys;

    public List<TrapScriptable> traps;
}
