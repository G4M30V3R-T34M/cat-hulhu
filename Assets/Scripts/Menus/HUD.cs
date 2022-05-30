using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Feto;

public class HUD : Singleton<HUD>
{
    float NOHEALTHALPHA = 110f / 255f;

    [SerializeField] Image[] lives;

    [SerializeField] TextMeshProUGUI clueNumber;

    [SerializeField] Image back;
    [SerializeField] Image head;
    [SerializeField] Image eyes;
    [SerializeField] TextMeshProUGUI investigatorName;

    [SerializeField] TextMeshProUGUI remainingInvestigators;

    void Start()
    {
        UpdateClueNumber();

        back.color = SaveDataManager.Instance.playerData.backColor;
        head.color = SaveDataManager.Instance.playerData.headColor;
        eyes.color = SaveDataManager.Instance.playerData.eyesColor;
        investigatorName.text = SaveDataManager.Instance.playerData.investigatorName;

        remainingInvestigators.text = GetRemainingInvestigatorsText();
    }

    private string GetRemainingInvestigatorsText() {
        int remainingLives = SaveDataManager.Instance.gameData.lives;

        if(15 <= remainingLives &&  remainingLives > 10) { return "A lot of investigators left"; }
        if(10 <= remainingLives &&  remainingLives > 5) { return "Some investigators left"; }
        if(5 <= remainingLives &&  remainingLives > 0) { return "Few investigators left"; }
        return "";
    }

    public void UpdateLives() {
        ResetHealth();
        int totalLives = SaveDataManager.Instance.playerData.health;
        CangeColorToLive(1f, totalLives);
    }

    private void ResetHealth() {
        CangeColorToLive(NOHEALTHALPHA, lives.Length);
    }

    private void CangeColorToLive(float alpha, int length) {
        Color tempColor;
        for (int i = 0; i < length; i++) {
            tempColor = lives[i].color;
            tempColor.a = alpha;
            lives[i].color = tempColor;
        }
    }

    public void UpdateClueNumber() {
        clueNumber.text = SaveDataManager.Instance.cluesData.GetCurrentClues().ToString();
    }

}
