using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string investigatorName;

    public Color backColor;
    public Color headColor;
    public Color eyesColor;

    public Vector2 lastBigMapPosition = new Vector2(-4.5f, -9f);

    public int health = 0;

    public void Reset() {
        investigatorName = "";
        backColor = Color.black;
        headColor = Color.black;
        eyesColor = Color.black;
        lastBigMapPosition = new Vector2(-4.5f, -9f);
        health = 0;
    }
}
