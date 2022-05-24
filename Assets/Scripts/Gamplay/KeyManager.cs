using UnityEngine;
using Feto;

public class KeyManager : Singleton<KeyManager>
{
    [SerializeField]
    GameDataScriptable gameData;

    public bool IsKeyCollected(string keyId) {
        return gameData.keys.Contains(keyId);
    }

    public void CollectKey(string keyId) {
        gameData.keys.Add(keyId);
    }
}
