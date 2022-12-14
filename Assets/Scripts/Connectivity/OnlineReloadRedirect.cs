using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class OnlineReloadRedirect : MonoBehaviour
{
    private void Awake()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Not a MasterClient to load the level");
            return;
        }
        PhotonNetwork.LoadLevel("OnlineEmptyScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
