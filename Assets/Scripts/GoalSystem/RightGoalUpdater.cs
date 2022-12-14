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
    private void Awake()
    {
        _networkManager = GameObject.FindGameObjectWithTag("NetworkManager");
        gameManager = FindObjectOfType<GameManager>();
        _rightScoreTag = gameManager.rightScoreTag;
        _currentRightScore = PlayerPrefs.GetInt(_rightScoreTag);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_networkManager != null)
        {
            OnlineAddScore();
        }
        else
        {
            OfflineAddScore();
        }
    }

    private void OfflineAddScore()
    {
        _currentRightScore++;
        PlayerPrefs.SetInt(_rightScoreTag, _currentRightScore);
        PlayerPrefs.Save();
    }
    private void OnlineAddScore()
    {
        if (!PhotonNetwork.IsMasterClient) return;
        else
        {
            _currentRightScore++;
            PlayerPrefs.SetInt(_rightScoreTag, _currentRightScore);
            PlayerPrefs.Save();
        }
    }
}
