using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class LeftGoalUpdater : MonoBehaviour
{
    [SerializeField]
    private GameObject _networkManager;

    public GameManager gameManager;
    
    private string _leftScoreTag;
    private int _currentLeftScore;

    private bool _ready = true;

    private void Awake()
    {
        _networkManager = GameObject.FindGameObjectWithTag("NetworkManager");
        gameManager = FindObjectOfType<GameManager>();
        _leftScoreTag = gameManager.leftScoreTag;
        _currentLeftScore = PlayerPrefs.GetInt(_leftScoreTag);
    }

    private void Start()
    {
        _ready = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        AddScore();   
    }

    private void AddScore()
    {
        if(_ready == true)
        {
            _currentLeftScore++;
            PlayerPrefs.SetInt(_leftScoreTag, _currentLeftScore);
            PlayerPrefs.Save();
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        _ready = false;
        yield return new WaitForSeconds(2);
        _ready = true;
    }
}
