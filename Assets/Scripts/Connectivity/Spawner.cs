using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Fields   
    //objects
    [SerializeField]
    private GameObject _deformer1;

    [SerializeField]
    private GameObject _deformer2;

    [SerializeField]
    private GameObject _player1;
    
    [SerializeField]
    private GameObject _player2;

    [SerializeField]
    private GameObject _puck;
    //positions of the objects
    private Vector3 _initialPlayer1Pos = new Vector3(-4f, 0.21f, -10f);
    private Vector3 _initialPlayer2Pos = new Vector3(4f, 0.21f, -10f);
    private Vector3 _initialPuckPos = new Vector3(0f, 0.106f, -10f);
    //rotations of the objects
    private Quaternion _initialPlayer1Rot = new Quaternion(-0.5f, -0.5f, -0.5f, 0.5f);
    private Quaternion _initialPlayer2Rot = new Quaternion(0.5f, -0.5f, -0.5f, -0.5f);
    #endregion

    #region Properties

    //game objects
    public GameObject Deformer1 { get { return _deformer1; } }
    public GameObject Deformer2 { get { return _deformer2; } }
    public GameObject Player1 { get { return _player1; } }
    public GameObject Player2 { get { return _player2; } }
    public GameObject Puck { get { return _puck; } }

    //positions of the objects
    public Vector3 InitialPlayer1Pos { get { return _initialPlayer1Pos; } }
    public Vector3 InitialPlayer2Pos { get { return _initialPlayer2Pos; } }
    public Vector3 InitialPuckPos { get { return _initialPuckPos; } }

    //rotations of the objects
    public Quaternion InitialPlayer1Rot { get { return _initialPlayer1Rot; } }
    public Quaternion InitialPlayer2Rot { get { return _initialPlayer2Rot; } }
    #endregion

    private void Awake()
    {
        
    }   
    //method that can be accessed publicly, and spawns objects in the photon mp environment
    public void SpawnGameObject(GameObject player, Vector3 position, Quaternion rotation)
    {
        PhotonNetwork.Instantiate(player.name, position, rotation);
    }

    public void SeekAndDestroy()
    {
        Destroy(GameObject.FindGameObjectWithTag(Player1.tag));
        Destroy(GameObject.FindGameObjectWithTag(Player2.tag));
        Destroy(GameObject.FindGameObjectWithTag(Deformer1.tag));
        Destroy(GameObject.FindGameObjectWithTag(Deformer2.tag));
    }
}
