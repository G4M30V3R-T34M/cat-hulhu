using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoor : Item
{
    [SerializeField]
    PlayerPositionBigMapScriptable position;

    [SerializeField]
    Scenes scene;

    protected override void ActionOnPick(GameObject character) {
        position.xPos = character.transform.position.x;
        position.yPos = character.transform.position.y;
        SceneManager.LoadScene((int)scene);
    }
}
