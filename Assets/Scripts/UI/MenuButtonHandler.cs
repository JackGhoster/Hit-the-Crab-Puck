using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtonHandler : MonoBehaviour
{
    [SerializeField]
    private AudioSource _sfx;

    protected string OfflineSceneName = "OfflineScene";
    protected string OnlineSceneName = "LoadingScene";
    public void OnOfflineButton()
    {
        _sfx.Play();
        StartCoroutine(OnSoundPlayedLoad(OfflineSceneName));
        //SceneManager.LoadScene(OfflineSceneName);
    }

    public void OnOnlineButton()
    {
        _sfx.Play();
        StartCoroutine(OnSoundPlayedLoad(OnlineSceneName));
        //SceneManager.LoadScene(LoadingSceneName);
    }

    IEnumerator OnSoundPlayedLoad(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
