using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBodyData : MonoBehaviour
{
    public const string EMPTY_DEAD = "";
    List<DeadBody> bodies = new List<DeadBody>();

    public DeadBody GetDeadBody(string deadId) {
        DeadBody dead = new DeadBody(EMPTY_DEAD, Color.black, Color.black, Color.black, Color.black);

        int i = 0;
        while (i < bodies.Count && dead.id  == EMPTY_DEAD) {
            if (bodies[i].id == deadId) {
                dead = bodies[i];
            }
            i++;
        }

        return dead;
    }

    public void SaveDead(string id, Color colorBack, Color colorHead, Color colorEyes, Color colorBlood) {
        DeadBody dead = new DeadBody(id, colorBack, colorHead, colorEyes, colorBlood);
        bodies.Add(dead);
    }

    public void Reset() {
        bodies.Clear();
    }
}
