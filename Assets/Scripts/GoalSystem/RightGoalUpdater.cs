using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGoalUpdater : MonoBehaviour
{
    [SerializeField]
    private GameObject _networkManager;

    public GameManager gameManager;
    private string _rightScoreTag;
    private int _currentRightScore;

    private bool _ready;
    private void Awake()
    {
        _networkManager = GameObject.FindGameObjectWithTag("NetworkManager");
        gameManager = FindObjectOfType<GameManager>();
        _rightScoreTag = gameManager.rightScoreTag;
        _currentRightScore = PlayerPrefs.GetInt(_rightScoreTag);
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
            _currentRightScore++;
            PlayerPrefs.SetInt(_rightScoreTag, _currentRightScore);
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
