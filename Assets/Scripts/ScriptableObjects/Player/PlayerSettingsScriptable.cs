using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettingsScriptable", menuName = "Scriptables/PlayerSettingsScriptable", order = 1)]
public class PlayerSettingsScriptable : ScriptableObject
{
    [Range(0, 15)]
    public float speed;

    [Range(1, 5)]
    public int health;

    [Range(1f, 2f)]
    public float speedMultiplier;
}
