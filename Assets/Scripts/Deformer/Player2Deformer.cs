using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Deformer : AbstractDeformer
{
    public override void Awake()
    {
        //playerTransform = GameObject.Find("Player2").transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player2").transform;
        base.Awake();
    }
    private void Start()
    {
        if (playerTransform) return;
        else if (playerTransform == null)
        {
            InvokeRepeating("FindPlayer", 0f, 2f);
        }
    }
    private void FindPlayer()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player1").transform;
    }
}
