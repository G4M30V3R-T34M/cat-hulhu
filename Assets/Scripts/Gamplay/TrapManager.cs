using UnityEngine;
using Feto;

public class TrapManager : Singleton<TrapManager>
{
    [SerializeField]
    GameDataScriptable gameData;

    public TrapScriptable GetTrap(string trapId) {
        TrapScriptable trap = null;

        int i = 0;
        while (i < gameData.traps.Count && trap == null) {
            if (gameData.traps[i].id == trapId) {
                trap = gameData.traps[i];
            }
            i++;
        }

        return trap;
    }

    public void SaveTrap(string id, Color backColor, Color headColor, Color eyesColor) {
        bool found = false;

        int i = 0;
        while (i < gameData.traps.Count && !found) {
            if (gameData.traps[i].id == "") {
                gameData.traps[i].id = id;
                gameData.traps[i].backColor = backColor;
                gameData.traps[i].headColor = headColor;
                gameData.traps[i].eyesColor = eyesColor;
                found = true;
            }
            i++;
        }
    }
}
