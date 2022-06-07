using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemiesData : MonoBehaviour
{
    List<string> dummiesKilled = new List<string>();

    public bool IsDummyKilled(string dummyId) {
        return dummiesKilled.Contains(dummyId);
    }

    public void KillDummy(string dummyId) {
        dummiesKilled.Add(dummyId);
    }

    public void Reset() {
        dummiesKilled.Clear();
    }
}
