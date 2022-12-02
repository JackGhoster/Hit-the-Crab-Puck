using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public string leftScoreTag = "LeftScore";
    public string rightScoreTag = "RightScore";

    private void Awake()
    {
        PlayerPrefs.SetFloat(leftScoreTag, 0f);
        PlayerPrefs.SetFloat(rightScoreTag, 0f);
    }
}
