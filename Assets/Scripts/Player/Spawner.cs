using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner
{
    static float BIGMAPX = 0;
    static float BIGMAPY = -11;

     static string[] names = new string[] {
        "Agatha Crane",
        "Agnes Baker",
        "Akachi Onyele",
        "Amanda Sharpe",
        "Ashcan Pete",
        "Bob Jenkins",
        "Calvin Wright",
        "Carolyn Fern",
        "Carson Sinclair",
        "Charlie Kane",
        "Daisy Walker",
        "Daniela Reyes",
        "Darrell Simmons",
        "Dexter Drake",
        "Diana Stanley",
        "Father Mateo"
    };

    static int nameIndex = 0;

    public static void RespawnPlayer() {
        DecrementTotalLives();
        SetNewRandomColors();
        SetNewName();
        SpawnPlayer();
    }

    private static void DecrementTotalLives() {
        if (PlayerHasLivesLeft()) {
            SaveDataManager.Instance.gameData.lives -= 1;
        }
        else {
            SceneManager.LoadScene((int)Scenes.GameOver);
        }
    }

    private static bool PlayerHasLivesLeft() {
        return SaveDataManager.Instance.gameData.lives > 0;
    }

    private static void SetNewRandomColors() {
        SaveDataManager.Instance.playerData.backColor = RandomColor.Generate();
        SaveDataManager.Instance.playerData.headColor = RandomColor.Generate();
        SaveDataManager.Instance.playerData.eyesColor = RandomColor.Generate();
    }

    private static void SetNewName() {
        SaveDataManager.Instance.playerData.investigatorName = GetNextName();
    }

    private static string GetNextName() {
        string newName = names[nameIndex];
        nameIndex += 1;
        return newName;
    }

    private static void SpawnPlayer() {
        if (!PlayerFinishedTutorial()) {
            SceneManager.LoadScene((int)Scenes.TutorialLevel);
        }
        else {
            SaveDataManager.Instance.playerData.lastBigMapPosition.x = BIGMAPX;
            SaveDataManager.Instance.playerData.lastBigMapPosition.y = BIGMAPY;
            SceneManager.LoadScene((int)Scenes.BigMap);
        }
    }

    private static bool PlayerFinishedTutorial() {
        return SaveDataManager.Instance.keysData.IsKeyCollected("tut-03");
    }


}
