using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Deformer : AbstractDeformer
{
    public override void Awake()
    {
        
        //playerTransform = GameObject.Find("Player1").transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player1").transform;
        
        base.Awake();
    }
    private void Start()
    {
        if (playerTransform) return;
        else if (playerTransform == null)
        {
            InvokeRepeating("FindPlayer",0, 2);
        }
        
    }
    private void FindPlayer()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player1").transform;
    }
}
