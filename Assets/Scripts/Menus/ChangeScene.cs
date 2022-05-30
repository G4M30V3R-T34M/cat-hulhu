using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void LoadMainMenu () {
        SceneManager.Instance.LoadScene((int)Scenes.MainMenu);
    }

    public void LoadCharacterSelect () {
        SceneManager.Instance.LoadScene((int)Scenes.CharacterSelect);
    }

    public void LoadCredits () {
        SceneManager.Instance.LoadScene((int)Scenes.Credits);
    }

    public void LoadGameIntro() {
        SceneManager.Instance.LoadScene((int)Scenes.GameIntro);
    }
}
