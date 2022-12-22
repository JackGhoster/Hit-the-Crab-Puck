using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDeformer : MonoBehaviour
{
    public Transform playerTransform;
   
    public Transform pModelTransform;

    [SerializeField]
    private float _perpendicularScaleKoefficient = 5f;
    
    [SerializeField]
    private float _parallelScaleKoefficient = 1.5f;

    private float scaleModifier = 1.5f;

    private Vector3 _scaleDownPerpendicularAxis;
    private Vector3 _scaleUpPerpendicularAxis;

    //it looks better with only scaling up the balloon model along the parallel axis 
    //private Vector3 _scaleDownParallelAxis;
    private Vector3 _scaleUpParallelAxis;


    public virtual void Awake()
    {
        this.GetComponent<ConfigurableJoint>().connectedBody = playerTransform.gameObject.GetComponent<Rigidbody>();
        pModelTransform = playerTransform.GetChild(0).transform;
        //getting scale of the non physic 3d model of a player
        float scaleX = pModelTransform.localScale.x;
        float scaleY = pModelTransform.localScale.y;
        float scaleZ = pModelTransform.localScale.z;
        //setting up the scale modifiers
        _scaleUpPerpendicularAxis = new Vector3(scaleX, scaleY * scaleModifier, scaleZ);
        _scaleDownPerpendicularAxis = new Vector3(scaleX, scaleY / scaleModifier, scaleZ);
        //Debug.Log(_scaleDownPerpendicularAxis);
        _scaleUpParallelAxis = new Vector3(scaleX * scaleModifier, scaleY, scaleZ);        
        //_scaleDownParallelAxis = new Vector3(scaleX / 1.5f, scaleY, scaleZ);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 relativePosition = playerTransform.InverseTransformPoint(transform.position);
        
        float interpolantPerpendicular = relativePosition.y * _perpendicularScaleKoefficient;
        float interpolantParallel = relativePosition.x * _parallelScaleKoefficient;
        
        Vector3 scalePerpendicularly = Lerp3(_scaleDownPerpendicularAxis, pModelTransform.localScale, _scaleUpPerpendicularAxis, interpolantPerpendicular);
       
        pModelTransform.localScale = scalePerpendicularly;
        //this is so the model won't continue to scale up whenever the player moves, these are the best settings I tried a bunch !
        if(pModelTransform.localScale.x > 0.75f && pModelTransform.localScale.x < 1.1f)
        {
            Vector3 scaleParallelary = Vector3.LerpUnclamped(pModelTransform.localScale, _scaleUpParallelAxis, interpolantParallel);
            pModelTransform.localScale = scaleParallelary;
        }
        else
        {
            Vector3 scaleParallelary = Vector3.LerpUnclamped(pModelTransform.localScale, Vector3.one, 1);
            pModelTransform.localScale = scaleParallelary;
        }
    }

    //it scales the object set in the inspector between the operands
    //unlike the usual Lerp method, it interpolates between 3 states
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
