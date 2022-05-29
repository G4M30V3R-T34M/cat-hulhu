using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysData : MonoBehaviour
{
    List<string> keysCollected = new List<string>();

    public int GetCurrentKeys() {
        return keysCollected.Count;
    }

    public bool IsKeyCollected(string keyId) {
        return keysCollected.Contains(keyId);
    }

    public void CollectKey(string keyId) {
        keysCollected.Add(keyId);
    }

    public void Reset() {
        keysCollected.Clear();
    }
}
