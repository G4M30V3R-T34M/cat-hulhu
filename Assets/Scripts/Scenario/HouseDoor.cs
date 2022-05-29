using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoor : Item
{
    [SerializeField]
    Scenes scene;

    protected override void ActionOnPick(GameObject character) {
        SaveDataManager.Instance.playerData.lastBigMapPosition = new Vector2(
            character.transform.position.x,
            character.transform.position.y
        );
        SceneManager.LoadScene((int)scene);
    }
}
