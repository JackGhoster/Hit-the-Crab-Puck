using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    #region Fields
    [SerializeField]
    private Spawner spawner;

    [SerializeField]
    private GameObject _puck;

    public Player p1;
    public Player p2;
    private float _maxPlayers = 2;

    private bool _isEnoughPlayers = false;

    #endregion

    #region Properties
    public bool IsEnoughPlayers {get{ return _isEnoughPlayers; }}

    public Vector3 StartingPuckPos { get; private set; }
    #endregion
    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        StartingPuckPos = spawner.InitialPuckPos;
        //PhotonNetwork.SetMasterClient(PhotonNetwork.CurrentRoom.GetPlayer(1));
        spawner.SeekAndDestroy();
        InitialSpawn();
    }
    private void Update()
    {
        
    }
    #region Private Methods
    private void InitialSpawn()
    {
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

    //private void OnPuck
    #endregion

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

    #region Photon Overrides
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //_isEnoughPlayers = true;
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PhotonNetwork.Disconnect();
        //_isEnoughPlayers = false;
        base.OnPlayerLeftRoom(otherPlayer);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene(0);
        base.OnDisconnected(cause);
    }
    #endregion
}
