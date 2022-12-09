using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineThrower : MonoBehaviour
{
    [SerializeField]
    private GameObject _puck;
     
    // Start is called before the first frame update
    void Start()
    {
        _puck.GetComponent<DelayTime>().StartThrow();
    }
}
