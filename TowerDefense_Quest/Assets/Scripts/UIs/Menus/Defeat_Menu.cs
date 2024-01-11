using UnityEngine;
using UnityEngine.SceneManagement;

public class Defeat_Menu : MonoBehaviour
{

    //public void Start()
    //{
    //    AudioManager.Instance.PlayMusic(AudioManager.Instance.Defeat_Menu);
    //}


    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
