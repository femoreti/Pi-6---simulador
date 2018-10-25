using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Range(-45,45)]
    public float initialRot;
    public float initialVelocity;

	// Use this for initialization
	void Start ()
    {
        Vector3 dir = Quaternion.AngleAxis(initialRot, Vector3.forward) * Vector3.left;
        GetComponent<Rigidbody2D>().velocity = (dir*initialVelocity);
        transform.eulerAngles = new Vector3(0, 0, initialRot);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
