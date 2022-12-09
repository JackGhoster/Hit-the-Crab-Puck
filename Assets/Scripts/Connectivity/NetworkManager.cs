using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Spawner spawner;

    [SerializeField]
    private Puck _puck;

    private float _maxPlayers = 2;
    private void Start()
    {
        //first player getting spawned on connect
        if(PhotonNetwork.CurrentRoom.PlayerCount < _maxPlayers)
        {
            spawner.SpawnGameObject(spawner.Player1, spawner.InitialPlayer1Pos, spawner.InitialPlayer1Rot);
            spawner.SpawnGameObject(spawner.Deformer1,spawner.InitialPlayer1Pos, Quaternion.identity);
        }
        //when there are more then 1 player in the room, the player 2 spawns and the game starts!
        else
        {
            spawner.SpawnGameObject(spawner.Player2, spawner.InitialPlayer2Pos, spawner.InitialPlayer2Rot);
            spawner.SpawnGameObject(spawner.Deformer2, spawner.InitialPlayer2Pos, Quaternion.identity);
            
        }
    }
    //public override void OnPlayerEnteredRoom(Player newPlayer)
    //{        
    //    base.OnPlayerEnteredRoom(newPlayer);
    //}
}
