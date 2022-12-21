using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class LobbyHandler : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private AudioSource _sfx;

    [SerializeField]
    private TMP_InputField _createInputField;

    [SerializeField]
    private TMP_InputField _joinInputField;

    private string _sceneToLoad = "OnlineScene";

    public void CreateRoom()
    {
        //Debug.Log(_createInputField.text);
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            MaxPlayers = 2
        };
        _sfx.Play();
        StartCoroutine(OnSoundPlayedLoad());
        PhotonNetwork.CreateRoom(_createInputField.text, roomOptions, TypedLobby.Default);
    }

    public void JoinRoom()
    {
        //Debug.Log(_joinInputField.text);
        _sfx.Play();
        StartCoroutine(OnSoundPlayedLoad());
        PhotonNetwork.JoinRoom(_joinInputField.text);
    }

    public override void OnJoinedRoom()
    {
        _sfx.Play();
        StartCoroutine(OnSoundPlayedLoad());
        PhotonNetwork.LoadLevel(_sceneToLoad);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        base.OnJoinRoomFailed(returnCode, message);
    }


    IEnumerator OnSoundPlayedLoad()
    {
        yield return new WaitForSeconds(0.5f);        
    }

}
