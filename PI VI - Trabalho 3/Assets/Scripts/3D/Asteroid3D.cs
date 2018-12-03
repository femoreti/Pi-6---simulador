using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid3D : MonoBehaviour
{
    public float _initialSpeed;
    public float _initialMass;
    public float _initialDistance;

    GameObject sun;
    Rigidbody rb;

	// Use this for initialization
	public void init ()
    {
        sun = GameObject.FindGameObjectWithTag("Sun");
        rb = GetComponent<Rigidbody>();
        transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

        _initialMass = Random.Range(1f, 10f);
        _initialDistance = Random.Range(10f, 40f);
        _initialSpeed = Random.Range(500f, 1000f);

        rb.mass = _initialMass;
        rb.AddRelativeForce(Vector3.forward * _initialSpeed);

        transform.position = RandomCircle(sun.transform.position, _initialDistance);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Make object position between distance
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;

        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        ang = Random.value * 360;
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        ang = Random.value * 360;
        pos.z = center.z + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        return pos;
    }
}
