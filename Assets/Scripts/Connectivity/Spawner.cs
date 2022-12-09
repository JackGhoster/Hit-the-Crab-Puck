using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //all the objects that are required in the mp
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

    //and their public properties
    public GameObject Deformer1 { get; private set; }
    public GameObject Deformer2 { get; private set; }
    public GameObject Player1 { get; private set; }
    public GameObject Player2 { get; private set; }
    public GameObject Puck { get; private set; }

    //positions of the objects
    private Vector3 _initialPlayer1Pos = new Vector3(-4f, 0.21f, -10f);
    private Vector3 _initialPlayer2Pos = new Vector3(4f, 0.21f, -10f);
    private Vector3 _initialPuckPos = new Vector3(0f, 0.106f, -10f);
    //and their public properties
    public Vector3 InitialPlayer1Pos { get; private set; }
    public Vector3 InitialPlayer2Pos { get; private set; }
    public Vector3 InitialPuckPos { get; private set; }

    //rotations of the objects
    private Quaternion _initialPlayer1Rot = new Quaternion(-0.5f, -0.5f, -0.5f, 0.5f);
    private Quaternion _initialPlayer2Rot = new Quaternion(0.5f, -0.5f, -0.5f, -0.5f);
    //and their public properties
    public Quaternion InitialPlayer1Rot { get; private set; }
    public Quaternion InitialPlayer2Rot { get; private set; }

    private void Awake()
    {
        //setting the properties
        Deformer1 = _deformer1;
        Deformer2 = _deformer2;

        Player1 = _player1;
        Player2 = _player2;
        Puck = _puck;

        InitialPlayer1Pos = _initialPlayer1Pos;
        InitialPlayer2Pos = _initialPlayer2Pos;
        InitialPuckPos = _initialPuckPos;

        InitialPlayer1Rot = _initialPlayer1Rot;
        InitialPlayer2Rot = _initialPlayer2Rot;
    }   
    //method that can be accessed publicly, and spawns objects in the photon mp environment
    public void SpawnGameObject(GameObject player, Vector3 position, Quaternion rotation)
    {
        PhotonNetwork.Instantiate(player.name, position, rotation);
    }
}
