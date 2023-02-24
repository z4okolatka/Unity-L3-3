using System;
using UnityEditor.UI;
using UnityEngine;

public class RopeUnhooker : MonoBehaviour
{
    [SerializeField] KeyCode Key;
    private HingeJoint2D _joint;
    private Rigidbody2D _rigidBody;
    
    private void Start()
    {
        _joint = GetComponent<HingeJoint2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            _joint.enabled = false;

            _rigidBody.angularVelocity = -_rigidBody.velocity.x * 4;
        }    
    }
}
