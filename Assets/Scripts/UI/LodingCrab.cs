using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LodingCrab : MonoBehaviour
{
    private float _speed = 300f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, _speed * Time.deltaTime, 0, Space.Self);
    }
}
