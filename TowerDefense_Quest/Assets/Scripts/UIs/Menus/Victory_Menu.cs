using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory_Menu : MonoBehaviour
{

    public void Start()
    {
        gameObject.SetActive(true);
      //  AudioManager.Instance.PlayMusic(AudioManager.Instance.Victory_Menu);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
