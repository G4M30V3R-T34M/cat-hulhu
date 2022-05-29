using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluesData : MonoBehaviour
{
    List<string> cluesCollected = new List<string>();

    public int GetCurrentClues() {
        return cluesCollected.Count;
    }

    public bool IsClueCollected(string clueID) {
        return cluesCollected.Contains(clueID);
    }

    public void CollectClue(string clueId) {
        cluesCollected.Add(clueId);
    }
}
