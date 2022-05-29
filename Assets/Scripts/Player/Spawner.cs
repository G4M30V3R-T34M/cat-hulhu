using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    PlayerSettingsScriptable playerSettings;

    string[] names = new string[] {
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

    int nameIndex = 0;

    public void RespawnPlayer() {
        DecrementTotalLives();
        SetNewRandomColors();
        SetNewName();
        SpawnPlayer();
    }

    private void DecrementTotalLives() {
        if (PlayerHasLivesLeft()) {
            // TODO Decrement in new Save system
        }
        else {
            SceneManager.LoadScene((int)Scenes.GameOver);
        }
    }

    private bool PlayerHasLivesLeft() {
        // TODO get this lives from new Save system
        int lives = 15;
        return lives == 0;
    }

    private void SetNewRandomColors() {
        playerSettings.color1 = RandomColor.Generate();
        playerSettings.color2 = RandomColor.Generate();
        playerSettings.color3 = RandomColor.Generate();
    }

    private void SetNewName() {
        playerSettings.investigatorName = GetNextName();
    }

    private string GetNextName() {
        string newNAme = names[nameIndex];
        nameIndex += 1;
        return newNAme;
    }

    private void SpawnPlayer() {
        if (!PlayerFinishedTutorial()) {
            SceneManager.LoadScene((int)Scenes.TutorialLevel);
        }
        SceneManager.LoadScene((int)Scenes.BigMap);
    }

    private bool PlayerFinishedTutorial() {
        // TODO get this value from save system
        return true;
    }


}
