using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadMainMenu () {
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }

    public void LoadCharacterSelect () {
        SceneManager.LoadScene((int)Scenes.CharacterSelect);
    }

    public void LoadCredits () {
        SceneManager.LoadScene((int)Scenes.Credits);
    }

    public void LoadGameIntro() {
        SceneManager.LoadScene((int)Scenes.GameIntro);
    }
}
