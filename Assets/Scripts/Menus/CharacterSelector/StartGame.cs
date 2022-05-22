using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    PlayerSettingsScriptable player;

    [SerializeField]
    GameDataScriptable game;

    [SerializeField]
    TextMeshProUGUI investigatorName;

    [SerializeField]
    Image Back, Head, Eyes;

    [SerializeField]
    DifficultyManager difficultyManager;

    [SerializeField]
    ChangeScene changeScene;

    public void Play() {
        player.investigatorName = (investigatorName.text.Length != 1)
            ? investigatorName.text
            : "NoName";

        player.color1 = Back.color;
        player.color2 = Head.color;
        player.color3 = Eyes.color;

        game.lives = difficultyManager.GetDifficultyInvestigators();

        changeScene.LoadGameIntro();
    }
}
