using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _leftGoal;
    [SerializeField]
    private GameObject _rightGoal;

    [SerializeField]
    protected TextMeshProUGUI leftText;
    [SerializeField]
    protected TextMeshProUGUI rightText;

    public string leftScoreTag = "LeftScore";
    public string rightScoreTag = "RightScore";
    public int currentLeftScore;
    public int currentRightScore;

    private void Awake()
    {
        currentLeftScore = PlayerPrefs.GetInt(leftScoreTag);
        currentRightScore = PlayerPrefs.GetInt(rightScoreTag);
        Debug.Log(currentLeftScore);
        Debug.Log(currentRightScore);
        leftText.text = currentLeftScore.ToString();
        rightText.text = currentRightScore.ToString();
    }
    private void Update()
    {
        //for left text
        OnScoreUpdated(leftScoreTag, currentLeftScore, leftText);
        //for right text
        OnScoreUpdated(rightScoreTag, currentRightScore, rightText);
    }

    private void OnScoreUpdated(string tag, int score, TextMeshProUGUI scoreText)
    {
        var newScore = PlayerPrefs.GetInt(tag);
        if (score < newScore)
        {
            scoreText.text = newScore.ToString();
            StartCoroutine(Delay(2));
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
        else if (score >= 5)
        {
            StartCoroutine(ExitSceneDelay(1));
            
        }
    }

    IEnumerator Delay(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    IEnumerator ExitSceneDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

}
