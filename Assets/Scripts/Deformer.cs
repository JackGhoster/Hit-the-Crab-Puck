using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deformer : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private Transform _pModelTransform;

    [SerializeField]
    private float _perpendicularScaleKoefficient;
    [SerializeField]
    private float _parallelScaleKoefficient;

    private Vector3 _scaleDownPerpendicularAxis;
    private Vector3 _scaleUpPerpendicularAxis;

    //it looks better with only scaling up the balloon model along the parallel axis 
    //private Vector3 _scaleDownParallelAxis;
    private Vector3 _scaleUpParallelAxis;


    private void Awake()
    {
        //getting scale of the non physic 3d model of a player
        float scaleX = _pModelTransform.localScale.x;
        float scaleY = _pModelTransform.localScale.y;
        float scaleZ = _pModelTransform.localScale.z;
        //setting up the scale modifiers
        _scaleUpPerpendicularAxis = new Vector3(scaleX, scaleY * 1.5f, scaleZ);
        _scaleDownPerpendicularAxis = new Vector3(scaleX, scaleY / 1.5f, scaleZ);
        //Debug.Log(_scaleDownPerpendicularAxis);
        _scaleUpParallelAxis = new Vector3(scaleX * 1.5f, scaleY, scaleZ);        
        //_scaleDownParallelAxis = new Vector3(scaleX / 1.5f, scaleY, scaleZ);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 relativePosition = _playerTransform.InverseTransformPoint(transform.position);
        float interpolantPerpendicular = relativePosition.y * _perpendicularScaleKoefficient;
        float interpolantParallel = relativePosition.x * _parallelScaleKoefficient;
        
        Vector3 scalePerpendicularly = Lerp3(_scaleDownPerpendicularAxis, _pModelTransform.localScale, _scaleUpPerpendicularAxis, interpolantPerpendicular);
        //Debug.Log(scalePerpendicularly);
        _pModelTransform.localScale = scalePerpendicularly;

        Vector3 scaleParallelary = Vector3.LerpUnclamped(_pModelTransform.localScale, _scaleUpParallelAxis, interpolantParallel);
        //Debug.Log(scaleParallelary);
        _pModelTransform.localScale = scaleParallelary;
    }

    //it scales the object set in the inspector between the operands
    //unlike the usual Lerp, it interpolates between 3 operands
    Vector3 Lerp3(Vector3 firstOperand, Vector3 secondOperand, Vector3 thirdOperand, float interpolationVariable)
    {
        float addent = 1f;

        if (interpolationVariable < 0)
        {
            return Vector3.LerpUnclamped(firstOperand, secondOperand, interpolationVariable + addent);
        }
        else
        {
            return Vector3.LerpUnclamped(secondOperand, thirdOperand, interpolationVariable);
        }
    }
}
