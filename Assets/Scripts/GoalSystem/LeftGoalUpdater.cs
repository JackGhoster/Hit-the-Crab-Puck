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
    private void Awake()
    {
        _networkManager = GameObject.FindGameObjectWithTag("NetworkManager");
        gameManager = FindObjectOfType<GameManager>();
        _leftScoreTag = gameManager.leftScoreTag;
        _currentLeftScore = PlayerPrefs.GetInt(_leftScoreTag);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_networkManager != null)
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
        _currentLeftScore++;
        PlayerPrefs.SetInt(_leftScoreTag, _currentLeftScore);
        PlayerPrefs.Save();
    }
    private void OnlineAddScore()
    {
        if (!PhotonNetwork.IsMasterClient) return;
        else
        {
            _currentLeftScore++;
            PlayerPrefs.SetInt(_leftScoreTag, _currentLeftScore);
            PlayerPrefs.Save();
        }
    }
}
