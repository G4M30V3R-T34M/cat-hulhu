using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    static float BIGMAPX = 0;
    static float BIGMAPY = -11;

    static List<string> names = new List<string> {
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
        "Father Mateo",
        "Finn Edwards",
        "George Barnaby",
        "Gloria Goldberg",
        "Hank Samson",
        "Harvey Walters",
        "Jacqueline Fine",
        "Jenny Barnes",
        "Jim Culver",
        "Joe Diamond",
        "Kate Winthrop",
        "Leo Anderson",
        "Lily Chen",
        "Lola Hayes",
        "Luke Robinson",
        "Mandy Thompson",
        "Marie Lambeau",
        "Mark Harrigan",
        "Michael McGlen",
        "Minh Thi Phan",
        "Monterey Jack",
        "Norman Withers",
        "Patrice Hathaway",
        "Preston Fairmont",
        "Rex Murphy",
        "Rita Young",
        "Roland Banks",
        "Sefina Rousseau",
        "Silas Marsh",
        "Sister Mary",
        "\"Skids\" O'Toole",
        "Tommy Muldoon",
        "Tony Morgan",
        "Trish Scarborough",
        "Ursula Downs",
        "Vincent Lee",
        "Wendy Adams",
        "William Yorick",
        "Wilson Richards",
        "Zoey Samaras"
    };

    public static void RespawnPlayer() {
        if (PlayerHasLivesLeft()) {
            DecrementTotalLives();
            SetNewRandomColors();
            SetNewName();
            SpawnPlayer();
        } else {
            SceneManager.Instance.LoadScene((int)Scenes.GameOver);
        }
    }

    private static void DecrementTotalLives() {
        SaveDataManager.Instance.gameData.lives -= 1;
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
        int idx = Random.Range(0, names.Count);
        string newName = names[idx];
        names.RemoveAt(idx);
        return newName;
    }

    private static void SpawnPlayer() {
        if (!PlayerFinishedTutorial()) {
            SceneManager.Instance.LoadScene((int)Scenes.TutorialLevel);
        }
        else {
            SaveDataManager.Instance.playerData.lastBigMapPosition.x = BIGMAPX;
            SaveDataManager.Instance.playerData.lastBigMapPosition.y = BIGMAPY;
            SceneManager.Instance.LoadScene((int)Scenes.BigMap);
        }
    }

    private static bool PlayerFinishedTutorial() {
        return SaveDataManager.Instance.keysData.IsKeyCollected("tut-03");
    }


}
