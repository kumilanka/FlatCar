using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motorbike : MonoBehaviour
{
    [SerializeField]
    private WheelJoint2D frontWheelJoint;

    [SerializeField]
    private WheelJoint2D backWheelJoint;

    [SerializeField]
    private float motorPower = 1f;

    [SerializeField]
    private float turnPower = 1f;

    [SerializeField]
    private float jumpPower = 1f;

    private JointMotor2D jointMotor;

	// Use this for initialization
	void Start ()
    {
        jointMotor = backWheelJoint.motor;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float up = Input.GetAxis("Vertical");
        if (up != 0f)
        {
            backWheelJoint.useMotor = true;
            jointMotor.motorSpeed = -up * motorPower;
            backWheelJoint.motor = jointMotor;
        }
        else
        {
            backWheelJoint.useMotor = false;
        }
	    
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.AddTorque(turnPower);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.AddTorque(-turnPower);
        }
            
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.AddForce(Vector2.up * jumpPower);
        }
        	
	}
}
