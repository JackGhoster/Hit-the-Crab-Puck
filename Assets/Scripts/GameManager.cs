using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using Photon.Pun;
using System.Net.NetworkInformation;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _leftGoal;
    [SerializeField]
    private GameObject _rightGoal;
    [SerializeField]
    private GameObject _networkManager;
    [SerializeField]
    private GameObject _puck;

    [SerializeField]
    protected TextMeshProUGUI rightPointsText;
    [SerializeField]
    protected TextMeshProUGUI leftPointsText;



    public string leftScoreTag = "LeftScore";
    public string rightScoreTag = "RightScore";
    public int currentLeftScore;
    public int currentRightScore;

    private bool _matchStarted = false;
    private Action OnMatchStarted;
    private Action OnScored;
    private void Awake()
    {
        currentLeftScore = PlayerPrefs.GetInt(leftScoreTag);
        currentRightScore = PlayerPrefs.GetInt(rightScoreTag);
        rightPointsText.text = currentRightScore.ToString();
        leftPointsText.text = currentLeftScore.ToString();
        _puck = GameObject.FindGameObjectWithTag("Puck");
    }

    private void Start()
    {

        InvokeRepeating("CheckForPlayersReady", 3, 3);
        _puck = GameObject.FindGameObjectWithTag("Puck");
    }

    private void Update()
    {
        UpdateScores();
    }

    private void UpdateScores()
    {
        if(_networkManager == null)
        {
            //when the left one is getting crabed on in offline
            OnScoreUpdated(leftScoreTag, currentLeftScore, leftPointsText, "LeftLostScene");
            //when the right one is getting crabed on in offline
            OnScoreUpdated(rightScoreTag, currentRightScore, rightPointsText, "RightLostScene");
        }
        else{
            //when the left one is getting crabed on in online
            OnOnlineScoreUpdated(leftScoreTag, currentLeftScore, leftPointsText, "LeftLostScene");
            //when the right one is getting crabed on in online
            OnOnlineScoreUpdated(rightScoreTag, currentRightScore, rightPointsText, "RightLostScene");
        }
    }

    private void OnScoreUpdated(string tag, int score, TextMeshProUGUI scoreText, string sceneName)
    {
        var targetScore = 5;
        int newScore = PlayerPrefs.GetInt(tag);
        
        if (newScore > targetScore - 1)
        {
            scoreText.text = newScore.ToString();
            StartCoroutine(ExitSceneDelay(0.3f, sceneName));
        }
        else if (score < newScore)
        {
            scoreText.text = newScore.ToString();
            StartCoroutine(ReloadScene(0.5f));
        }
    }

    private void OnOnlineScoreUpdated(string tag, int score, TextMeshProUGUI scoreText, string sceneName)
    {
        var targetScore = 5;
        int newScore = 0;
        newScore = PlayerPrefs.GetInt(tag);
        if (newScore > targetScore - 1)
        {
            scoreText.text = newScore.ToString();
            StartCoroutine(ExitSceneDelay(0.3f, sceneName));
        }
        else if (score < newScore)
        {
            scoreText.text = newScore.ToString();
            _matchStarted = false;
            StartCoroutine(ReloadScene(0.2f));
        }
   
    }

    //when there is enough players in the mp the puck will be thrown after a delay
    private void CheckForPlayersReady()
    {
        if (_networkManager == null) return;
        else
        {
            var isEnoughPlayers = _networkManager.GetComponent<NetworkManager>().PlayerCountChecker();
            Debug.Log(string.Format("Is there enough players to start?: {0}", isEnoughPlayers));
            if (isEnoughPlayers == true && _matchStarted == false)
            {
                _puck = GameObject.FindGameObjectWithTag("Puck");
                OnMatchStarted();
            }
        }
    }

    private void ThrowPuck()
    {
        if (_puck == null) return;
        else
        {
            _puck.GetComponent<DelayTime>().StartThrow();
            _matchStarted = true;
        }
    }

    //private void ResetPuck()
    //{
    //    if (_puck != null)
    //    {
    //        Debug.Log("reset");
    //        var puckInitPos = _networkManager.GetComponent<NetworkManager>().StartingPuckPos;
    //        _puck.transform.position = puckInitPos;
    //        _matchStarted = false;
    //    }
    //}

    IEnumerator ReloadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    IEnumerator ExitSceneDelay(float seconds, string sceneToLoad)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnEnable()
    {
        OnMatchStarted += ThrowPuck;
        //OnScored += ResetPuck;
    }

    private void OnDisable()
    {
        OnMatchStarted -= ThrowPuck;
        //OnScored -= ResetPuck;
    }

}
