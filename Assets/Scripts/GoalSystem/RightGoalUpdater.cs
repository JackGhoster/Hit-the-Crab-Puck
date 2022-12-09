using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGoalUpdater : MonoBehaviour
{
    public GameManager gameManager;
    private string _rightScoreTag;
    private int _currentRightScore;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        _rightScoreTag = gameManager.rightScoreTag;
        _currentRightScore = PlayerPrefs.GetInt(_rightScoreTag);
    }

    private void OnTriggerEnter(Collider other)
    {
        _currentRightScore++;
        PlayerPrefs.SetInt(_rightScoreTag, _currentRightScore);
        PlayerPrefs.Save();
    }
}
