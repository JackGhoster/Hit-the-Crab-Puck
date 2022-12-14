using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DelayTime : MonoBehaviour
{
    [SerializeField]
    private GameObject _puck;

    private Rigidbody _rb;
    
    private Vector3 _startingVector;

    private void Awake()
    {
        _puck = GameObject.FindGameObjectWithTag("Puck");
        _rb = _puck.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _startingVector = _puck.GetComponent<Puck>().startingVector;
    }

    public void StartThrow()
    {
        StartCoroutine(InitialThrowDelay(1.5f));
    }

    IEnumerator InitialThrowDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _rb.AddForce(_startingVector * 155f);
        Debug.Log("Puck Thrown");
    }
}
