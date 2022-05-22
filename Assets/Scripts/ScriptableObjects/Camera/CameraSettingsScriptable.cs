using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraSettingsScriptable", menuName = "Scriptables/CameraSettingsScriptable", order = 2)]
public class CameraSettingsScriptable : ScriptableObject
{
    [Range(0, 5)]
    public float speed;
}
