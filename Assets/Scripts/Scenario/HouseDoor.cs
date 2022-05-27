using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoor : Item
{
    [SerializeField]
    Scenes scene;

    public override void Attack() {
        throw new System.NotImplementedException();
    }

    protected override void ActionOnPick() {
        SceneManager.LoadScene((int)scene);
    }
}
