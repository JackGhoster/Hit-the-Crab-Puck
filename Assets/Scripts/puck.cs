using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Puck : MonoBehaviourPun
{

    [HideInInspector]
    public Vector3 startingVector = Vector3.zero;

    [SerializeField]
    private ParticleSystem _particleSystem;

    [SerializeField]
    private AudioSource _hitSound;

    private Rigidbody _rb;
    private float _speedX = 4000;
    private float _speedZ = 500;

    private float x1 = 1;
    private float x2 = -1;
    private List<float> _randomXList = new List<float>();


    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        //choosing where the puck will go along the x axis at the start of the round!
        _randomXList.Add(x1);
        _randomXList.Add(x2);
        startingVector.x = _randomXList[Random.Range(0, _randomXList.Count)];
    }

    private void OnCollisionEnter(Collision collision)
    {
        //upon a collision spawns water particles
        Instantiate(_particleSystem, this.transform.position, Quaternion.identity);
        //and plays the sound
        _hitSound.Play();

        //TransferOwnership(collision);

        //i read that contacts is bad since creates garbage, so I won't be using it
        //var colPoint = collision.contacts[0].point;

        // instead I'll get the pos of collision since it works fine enough
        var colTransform = collision.transform.position;
        _rb.AddForce(-colTransform.x * _speedX * Time.deltaTime, 0, colTransform.z * _speedZ * Time.deltaTime);

    }

    private void TransferOwnership(Collision col)
    {
        var ownershipTransferer = GetComponent<OwnershipTransferer>();
        ownershipTransferer.OnCollisionRequestOwnership(col);
    }
}
