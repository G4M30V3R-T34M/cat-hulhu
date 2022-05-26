using UnityEngine;
using Feto;

public class CluesManager : Singleton<CluesManager>
{
    [SerializeField]
    GameDataScriptable gameData;

    public int GetCurrentClues() {
        return gameData.clues.Count;
    }

    public bool IsClueCollected(string clueID) {
        return gameData.clues.Contains(clueID);
    }

    public void CollectClue(string clueId) {
        gameData.clues.Add(clueId);
    }

}
