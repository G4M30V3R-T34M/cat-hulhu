using UnityEngine;
using Feto;

[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(GameData))]
[RequireComponent(typeof(CluesData))]
[RequireComponent(typeof(TrapData))]
[RequireComponent(typeof(KeysData))]
[RequireComponent(typeof(HouseData))]
public class SaveDataManager : SingletonPersistent<SaveDataManager>
{
    public PlayerData playerData;
    public GameData gameData;
    public CluesData cluesData;
    public TrapData trapData;
    public KeysData keysData;
    public HouseData houseData;

    protected override void Awake() {
        base.Awake();
        playerData = GetComponent<PlayerData>();
        gameData = GetComponent<GameData>();
        cluesData = GetComponent<CluesData>();
        trapData = GetComponent<TrapData>();
        keysData = GetComponent<KeysData>();
        houseData = GetComponent<HouseData>();
    }

}
