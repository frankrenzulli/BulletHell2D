using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public Animator StartAnim;
    public GameManager gm;

    public void PlayGame()
    {
        StartAnim.SetTrigger("StartTrig");
        

        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
