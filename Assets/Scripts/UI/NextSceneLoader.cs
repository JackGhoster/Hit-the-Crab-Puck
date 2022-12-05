using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//just the script I use to load main menu scene from player lose scenes after some delay
public class NextSceneLoader : MonoBehaviour
{
    [SerializeField]
    private float _timeToWait = 2.3f;

    [SerializeField]
    private string _sceneToLoad = "MenuScene";

    private void Awake()
    {
            StartCoroutine(LoadSceneWithDelay(_timeToWait));    
    }

    IEnumerator LoadSceneWithDelay(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(_sceneToLoad);
    }
}
