using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGoalUpdater : MonoBehaviour
{
    public GameManager gameManager;
    private string _leftScoreTag;
    private int _currentLeftScore;
    private void Awake()
    {
        _leftScoreTag = gameManager.leftScoreTag;
        _currentLeftScore = PlayerPrefs.GetInt(_leftScoreTag);
    }

    private void OnTriggerEnter(Collider other)
    {
        _currentLeftScore++;
        PlayerPrefs.SetInt(_leftScoreTag, _currentLeftScore);
        PlayerPrefs.Save();
    }
}
