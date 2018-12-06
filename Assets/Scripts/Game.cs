using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game instance;

    [SerializeField]
    private GameObject motorbikePrefab;

    private GameObject motorbike;

    [SerializeField]
    private GameObject startPosition;

    [SerializeField]
    private GameObject endPosition;

    [SerializeField]
    private CameraFollow cameraFollow;

    [SerializeField]
    private Transform levelBottom;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        SpawnMotorbike();	
	}

    private void SpawnMotorbike()
    {
        if (motorbike == null)
        {
            motorbike = Instantiate(motorbikePrefab, startPosition.transform.position, Quaternion.identity);
            cameraFollow.SetCameraFollowTarget(motorbike);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (motorbike != null && motorbike.transform.position.y < levelBottom.transform.position.y)
        {
            OnMotorbikeDeath();
        }	
	}

    public void OnMotorbikeDeath()
    {
        Destroy(motorbike);
        motorbike = null;
        SpawnMotorbike();

    }

    public void OnEndPointReached()
    {
        Destroy(motorbike);
        motorbike = null;
        SpawnMotorbike();
    }
}
