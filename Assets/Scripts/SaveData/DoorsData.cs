using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsData : MonoBehaviour
{
    List<string> openedDoors = new List<string>();

    public bool IsDoorOpen(string doorId) {
        return openedDoors.Contains(doorId);
    }

    public void OpenDoor(string doorId) {
        openedDoors.Add(doorId);
    }

    public void Reset() {
        openedDoors.Clear();
    }
}
