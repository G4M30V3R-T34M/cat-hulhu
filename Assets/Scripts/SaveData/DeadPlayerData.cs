using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayerData : MonoBehaviour
{
    public const string EMPTY_PLAYER = "";
    public List<DeadPlayer> deadPlayers { get; private set; }

    private void Awake() {
        deadPlayers = new List<DeadPlayer>();
    }
    public DeadPlayer GetDeadPlayer(string playerId) {
        DeadPlayer player = new DeadPlayer(EMPTY_PLAYER, Color.black, Color.black, Color.black, Vector3.zero, Vector3.zero, EMPTY_PLAYER);

        int i = 0;
        while (i < deadPlayers.Count && player.id  == EMPTY_PLAYER) {
            if (deadPlayers[i].id == playerId) {
                player = deadPlayers[i];
            }
            i++;
        }

        return player;
    }

    public void SaveDeadPlayer(
        string id,
        Color backColor,
        Color headColor,
        Color eyesColor,
        Vector3 position,
        Vector3 rotation,
        string investigatorName
    ) {
        DeadPlayer player = new DeadPlayer(id, backColor, headColor, eyesColor, position, rotation, investigatorName);
        deadPlayers.Add(player);
    }

    public void Reset() {
        deadPlayers.Clear();
    }
}
