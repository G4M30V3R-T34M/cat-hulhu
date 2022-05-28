using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemScriptableObject", menuName = "Scriptables/ItemScriptableObject", order = 3)]
public class ItemScriptableObject : ScriptableObject
{
    public bool isWeapon;

    public int damage;

    public string description;
}
