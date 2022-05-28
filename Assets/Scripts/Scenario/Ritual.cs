using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ritual : Item
{
    [SerializeField]
    GameDataScriptable gameData;

    [SerializeField]
    int mediumClues, hardClues;

    public override void Attack() {
        throw new System.NotImplementedException();
    }

    protected override void ActionOnPick(GameObject character) {
        int cluesRecovered = CluesManager.Instance.GetCurrentClues();

        if (EnoughCluesRecovered(cluesRecovered)) {
            SceneManager.LoadScene((int)Scenes.GameClear);
        } else {
            PlayerDialog.Instance.ShowText("I need to find more clues to stop the ritual");
        }
    }

    private bool EnoughCluesRecovered(int clues) {
        return
            (gameData.difficulty == Difficulty.EASY) ||
            (gameData.difficulty == Difficulty.MEDIUM && clues >= mediumClues) ||
            (gameData.difficulty == Difficulty.HARD && clues >= hardClues);
    }
}
