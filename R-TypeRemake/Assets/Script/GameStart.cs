using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public Animator StartAnim;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    public void PlayGame()
    {
        StartAnim.SetTrigger("StartTrig");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
