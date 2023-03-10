using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;
    private int levelToLoad;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            FadeToLevel(1);
        }
    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeIn");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(1);
    }

    
}
