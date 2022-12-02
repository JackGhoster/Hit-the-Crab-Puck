using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtonHandler : MonoBehaviour
{
    protected string OfflineSceneName = "OfflineScene";
    protected string LoadingSceneName = "LoadingScene";
    public void OnOfflineButton()
    {
        SceneManager.LoadScene(OfflineSceneName);
    }

    public void OnOnlineButton()
    {
        SceneManager.LoadScene(LoadingSceneName);
    }
}
