using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyManager : MonoBehaviour
{
    public int[] difficultyInvestigators;

    public Difficulty difficulty { get; private set; }

    [SerializeField]
    private TextMeshProUGUI difficultyText, difficultyDetail;

    private void Awake() {
        difficulty = Difficulty.MEDIUM;
    }

    public void IncreaseDifficulty() {
        difficulty++;
        if ((int)difficulty > (int)Difficulty.HARD) {
            difficulty = Difficulty.EASY;
        }

        UpdateDifficulty();
    }

    public void DecreaseDifficulty() {
        difficulty--;
        if ((int)difficulty < (int)Difficulty.EASY) {
            difficulty = Difficulty.HARD;
        }

        UpdateDifficulty();
    }

    public int GetDifficultyInvestigators() {
        return difficultyInvestigators[(int)difficulty];
    }

    private void UpdateDifficulty() {
        UpdateDifficultyText();
        UpdateDifficultyDetail();
    }

    private void UpdateDifficultyText() {
        difficultyText.text = difficulty.ToString();
    }
    
    private void UpdateDifficultyDetail() {
        difficultyDetail.text = GetDifficultyInvestigators() + " Investigators";
    }

}
