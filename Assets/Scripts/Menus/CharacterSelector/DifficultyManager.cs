using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyManager : MonoBehaviour
{
    public Difficulty difficulty { get; private set; }

    [SerializeField]
    private TextMeshProUGUI difficultyText, difficultyDetail;

    private void Awake() {
        difficulty = Difficulty.MEDIUM;
    }

    public void IncreaseDifficulty() {
        if (difficulty == Difficulty.EASY) {
            difficulty = Difficulty.MEDIUM;
        } else if (difficulty == Difficulty.MEDIUM) {
            difficulty = Difficulty.HARD;
        } else {
            difficulty = Difficulty.EASY;
        }

        UpdateDifficulty();
    }

    public void DecreaseDifficulty() {
        if (difficulty == Difficulty.HARD) {
            difficulty = Difficulty.MEDIUM;
        } else if (difficulty == Difficulty.MEDIUM) {
            difficulty = Difficulty.EASY;
        } else {
            difficulty = Difficulty.HARD;
        }

        UpdateDifficulty();
    }

    private void UpdateDifficulty() {
        UpdateDifficultyText();
        UpdateDifficultyDetail();
    }

    private void UpdateDifficultyText() {
        difficultyText.text = difficulty.ToString();
    }
    
    private void UpdateDifficultyDetail() {
        difficultyDetail.text = (int)difficulty + " Investigators";
    }

}
