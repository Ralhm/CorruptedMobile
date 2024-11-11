using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public bool EnterLevelWithTransition;
    public bool ExitLevelWithTransition;
    public string SceneName;

    public Animator transition;
    public float transitionTime = 1.0f;

    public void Awake()
    {
        if (EnterLevelWithTransition)
        {
            transition.SetTrigger("End");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneName);
    }


    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());


        
    }
}
