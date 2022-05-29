using UnityEngine;

public class GameData : MonoBehaviour
{
    public Difficulty difficulty;
    public int lives;

    public void Reset() {
        difficulty = Difficulty.MEDIUM;
        lives = 0;
    }
}
