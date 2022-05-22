using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyManager : MonoBehaviour
{
    public enum Difficulty { Easy, Medium , Hard}
    public int[] difficultyInvestigators;

    public Difficulty difficulty { get; private set; }

    [SerializeField]
    private TextMeshProUGUI difficultyText, difficultyDetail;

    private void Awake() {
        difficulty = Difficulty.Medium;
    }

    public void IncreaseDifficulty() {
        difficulty++;
        if ((int)difficulty > (int)Difficulty.Hard) {
            difficulty = Difficulty.Easy;
        }

        UpdateDifficulty();
    }

    public void DecreaseDifficulty() {
        difficulty--;
        if ((int)difficulty < (int)Difficulty.Easy) {
            difficulty = Difficulty.Hard;
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
