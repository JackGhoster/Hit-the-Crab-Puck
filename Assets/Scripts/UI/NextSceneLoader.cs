using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//just the script I use to load main menu scene from player lose scenes after some delay
public class NextSceneLoader : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private float _timeToWait = 2.3f;

    [SerializeField]
    private string _sceneToLoad = "MenuScene";

    private void Awake()
    {
        Invoke("OfflineSceneChanger", 2.5f);
        StartCoroutine(DisconectAfterDelay(_timeToWait));       
    }

    private void OfflineSceneChanger()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }

    IEnumerator DisconectAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        PhotonNetwork.Disconnect();       
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene(_sceneToLoad);
        base.OnDisconnected(cause);
    }
}
