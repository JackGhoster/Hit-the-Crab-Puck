using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OwnershipTransferer : MonoBehaviourPun
{
    private GameObject _currentOwner;
    private void Awake()
    {
        _currentOwner = GameObject.FindGameObjectWithTag("Player1");
    }
    private void Start()
    {
        _currentOwner = GameObject.FindGameObjectWithTag("Player1");
    }

    public void OnCollisionRequestOwnership(Collision col)
    {
        if (col == null) return;
        Debug.Log(_currentOwner);
        var newOwner = col.gameObject;

        if (newOwner.GetComponent<PhotonView>() == null) return;
        
        if (_currentOwner != newOwner)
        {
            _currentOwner = newOwner;
            base.photonView.RequestOwnership();
            Debug.Log(_currentOwner);
        }       
    }
}
