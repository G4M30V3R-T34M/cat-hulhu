using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI investigatorName;

    [SerializeField]
    Image Back, Head, Eyes;

    [SerializeField]
    DifficultyManager difficultyManager;

    [SerializeField]
    ChangeScene changeScene;

    public void Play() {
        SaveDataManager.Instance.playerData.investigatorName = (investigatorName.text.Length != 1)
            ? investigatorName.text
            : "NoName";

        SaveDataManager.Instance.playerData.backColor = Back.color;
        SaveDataManager.Instance.playerData.headColor = Head.color;
        SaveDataManager.Instance.playerData.eyesColor = Eyes.color;

        SaveDataManager.Instance.gameData.difficulty = difficultyManager.difficulty;
        SaveDataManager.Instance.gameData.lives = (int)difficultyManager.difficulty;

        changeScene.LoadGameIntro();
    }
}
