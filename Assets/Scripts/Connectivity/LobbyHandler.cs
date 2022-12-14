using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class LobbyHandler : MonoBehaviourPunCallbacks
{
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

        PhotonNetwork.CreateRoom(_createInputField.text, roomOptions, TypedLobby.Default);
    }

    public void JoinRoom()
    {
        //Debug.Log(_joinInputField.text);
        PhotonNetwork.JoinRoom(_joinInputField.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(_sceneToLoad);
    }


}
