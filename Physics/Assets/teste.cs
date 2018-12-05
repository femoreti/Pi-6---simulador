using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour {
    public Rigidbody rb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rb.AddRelativeForce(new Vector3(0, 0, 10));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rb.AddRelativeForce(new Vector3(0, 0, -100));
        }
    }
}
