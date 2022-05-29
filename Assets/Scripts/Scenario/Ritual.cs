using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ritual : Item
{
    [SerializeField]
    int mediumClues, hardClues;

    protected override void ActionOnPick(GameObject character) {
        int cluesRecovered = SaveDataManager.Instance.cluesData.GetCurrentClues();

        if (EnoughCluesRecovered(cluesRecovered)) {
            SceneManager.LoadScene((int)Scenes.GameClear);
        } else {
            PlayerDialog.Instance.ShowText(itemSettings.description);
        }
    }

    private bool EnoughCluesRecovered(int clues) {
        return
            (SaveDataManager.Instance.gameData.difficulty == Difficulty.EASY) ||
            (SaveDataManager.Instance.gameData.difficulty == Difficulty.MEDIUM && clues >= mediumClues) ||
            (SaveDataManager.Instance.gameData.difficulty == Difficulty.HARD && clues >= hardClues);
    }
}
