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

    public void SaveTrap(TrapScriptable newTrap) {
        bool found = false;

        int i = 0;
        while (i < gameData.traps.Count && !found) {
            if (gameData.traps[i].id == "") {
                gameData.traps[i].id = newTrap.id;
                gameData.traps[i].backColor = newTrap.backColor;
                gameData.traps[i].headColor = newTrap.headColor;
                gameData.traps[i].eyesColor = newTrap.eyesColor;
                found = true;
            }
            i++;
        }
    }
}
