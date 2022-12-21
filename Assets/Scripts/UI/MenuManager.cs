using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MenuManager : MonoBehaviour
{
    public string leftScoreTag = "LeftScore";
    public string rightScoreTag = "RightScore";

    private void Awake()
    {
        PlayerPrefs.SetFloat(leftScoreTag, 0f);
        PlayerPrefs.SetFloat(rightScoreTag, 0f);
    }
    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
    }
}
