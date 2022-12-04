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
    protected TextMeshProUGUI rightPointsText;
    [SerializeField]
    protected TextMeshProUGUI leftPointsText;

    public string leftScoreTag = "LeftScore";
    public string rightScoreTag = "RightScore";
    public int currentLeftScore;
    public int currentRightScore;

    private void Awake()
    {
        currentLeftScore = PlayerPrefs.GetInt(leftScoreTag);
        currentRightScore = PlayerPrefs.GetInt(rightScoreTag);
        rightPointsText.text = currentRightScore.ToString();
        leftPointsText.text = currentLeftScore.ToString();
    }
    private void Update()
    {       
        //when the left one is getting crabed on
        OnScoreUpdated(leftScoreTag, currentLeftScore, leftPointsText, "LeftLostScene");
        //when the right one is getting crabed on
        OnScoreUpdated(rightScoreTag, currentRightScore, rightPointsText, "RightLostScene");
    }

    private void OnScoreUpdated(string tag, int score, TextMeshProUGUI scoreText, string sceneName)
    {
        var newScore = PlayerPrefs.GetInt(tag);
        var targetScore = 5;

        if (newScore > targetScore-1)
        {
            scoreText.text = newScore.ToString();
            StartCoroutine(ExitSceneDelay(0.3f,sceneName));
        }
        else if (score < newScore)
        {
            scoreText.text = newScore.ToString();
            StartCoroutine(ReloadScene(0.5f));
            
        }

    }

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

}
