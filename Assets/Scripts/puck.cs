using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public Transform player;
    private Rigidbody _rb;
    private float _speedX = 4000;
    private float _speedZ = 500;

    private float x1 = 1;
    private float x2 = -1;
    private List<float> _randomXList = new List<float>();
    private Vector3 _startingVector = Vector3.zero;
    

    // Start is called before the first frame update
    private void Awake()
    {
        //choosing where the puck will go along the x axis at the start of the round!
        _randomXList.Add(x1);
        _randomXList.Add(x2);
        _startingVector.x = _randomXList[Random.Range(0, _randomXList.Count)];

        _rb = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        //the delay of a throw at the beginning of each round
        StartCoroutine(InitialThrowDelay(2));     
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //var playerPos = player.position;          
    }

    private void OnCollisionEnter(Collision collision)
    {
        //i read that contacts is bad since creates garbage, so I won't be using it
        //var colPoint = collision.contacts[0].point;

        // instead I'll get the pos of collision since it works fine enough
        var colTransform = collision.transform.position;
        _rb.AddForce(-colTransform.x * _speedX * Time.deltaTime, 0, colTransform.z * _speedZ * Time.deltaTime);
    }

    IEnumerator InitialThrowDelay(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        _rb.AddForce(_startingVector * 155f);
    }
}
