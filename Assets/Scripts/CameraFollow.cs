using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraFollowTarget;

    private Vector3 currentVelocity;

    [SerializeField]
    private float followSpeed = 1f;

    [SerializeField]
    private float followDistance = -10f;

    public void SetCameraFollowTarget(GameObject followTarget)
    {
        cameraFollowTarget = followTarget;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (cameraFollowTarget != null)
        {
            Vector3 targetPos = new Vector3(cameraFollowTarget.transform.position.x, cameraFollowTarget.transform.position.y, followDistance);
            Vector3 newPos = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, followSpeed);
            transform.position = newPos;
        }	
	}
}
