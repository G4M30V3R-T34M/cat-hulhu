using UnityEngine;
using Feto;

[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(GameData))]
public class SaveDataManager : SingletonPersistent<SaveDataManager>
{
    public PlayerData playerData;
    public GameData gameData;

    protected override void Awake() {
        base.Awake();
        playerData = GetComponent<PlayerData>();
        gameData = GetComponent<GameData>();
    }

}
