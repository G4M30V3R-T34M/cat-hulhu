using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerSettingsScriptable", menuName = "Scriptables/PlayerSettingsScriptable", order =1)]
public class PlayerSettingsScriptable : ScriptableObject
{
    [Range(0, 15)]
    public float speed;

    public string investigatorName;

    public Color color1, color2, color3;

}
