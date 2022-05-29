using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapData : MonoBehaviour
{
    public const string EMPTY_TRAP = "";
    List<ActivatedTrap> activatedTraps = new List<ActivatedTrap>();

    public ActivatedTrap GetTrap(string trapId) {
        ActivatedTrap trap = new ActivatedTrap(EMPTY_TRAP, Color.black, Color.black, Color.black);

        int i = 0;
        while (i < activatedTraps.Count && trap.id  == EMPTY_TRAP) {
            if (activatedTraps[i].id == trapId) {
                trap = activatedTraps[i];
            }
            i++;
        }

        return trap;
    }

    public void SaveTrap(string id, Color backColor, Color headColor, Color eyesColor) {
        ActivatedTrap trap = new ActivatedTrap(id, backColor, headColor, eyesColor);
        activatedTraps.Add(trap);
    }

    public void Reset() {
        activatedTraps.Clear();
    }
}
