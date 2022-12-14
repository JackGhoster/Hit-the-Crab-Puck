using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Spawner spawner;

    [SerializeField]
    private GameObject _puck;

    private float _maxPlayers = 2;

    private bool _isEnoughPlayers = false;
    public bool IsEnoughPlayers {get{ return _isEnoughPlayers; }}

    public Vector3 StartingPuckPos { get; private set; }

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        StartingPuckPos = spawner.InitialPuckPos;
        //first player getting spawned on connect

        //when there are more then 1 player in the room, the player 2 spawns and the game starts!
        if (!PhotonNetwork.IsMasterClient)
        {
            spawner.SpawnGameObject(spawner.Player2, spawner.InitialPlayer2Pos, spawner.InitialPlayer2Rot);
            spawner.SpawnGameObject(spawner.Deformer2, spawner.InitialPlayer2Pos, Quaternion.identity);           
        }
        else 
        {
            //spawner.SpawnGameObject(spawner.Puck,spawner.InitialPuckPos,Quaternion.identity);

            spawner.SpawnGameObject(spawner.Player1, spawner.InitialPlayer1Pos, spawner.InitialPlayer1Rot);
            spawner.SpawnGameObject(spawner.Deformer1, spawner.InitialPlayer1Pos, Quaternion.identity);
        }
    }

    public bool PlayerCountChecker()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            _isEnoughPlayers = true;
        }
        else
        {
            _isEnoughPlayers = false;
        }
        return IsEnoughPlayers;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //_isEnoughPlayers = true;
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        SceneManager.LoadScene(0);
        //_isEnoughPlayers = false;
        base.OnPlayerLeftRoom(otherPlayer);
    }
}
