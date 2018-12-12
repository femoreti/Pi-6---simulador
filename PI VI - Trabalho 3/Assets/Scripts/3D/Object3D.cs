using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attract3D))]
public class Object3D : MonoBehaviour
{
    public float _initialSpeed;
    public float _initialMass;
    public float _initialDistance;

    GameObject sun;
    PhysicBody rb;


    //velocity
    Vector3 lastPos;
    public float minDist {
        get; set;
    }
    public float maxDist
    {
        get;set;
    }


    // Use this for initialization
    public void init (float p_mass, float p_dist, float p_speed)
    {
        sun = GameObject.FindGameObjectWithTag("Sun");
        rb = GetComponent<PhysicBody>();
        transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

        _initialMass = p_mass;
        _initialDistance = p_dist;
        _initialSpeed = p_speed;

        rb.mass = _initialMass;
        rb.AddRelativeForce(Vector3.forward * (_initialSpeed * 10));

        transform.position = RandomCircle(sun.transform.position, _initialDistance);
        lastPos = transform.position;

        minDist = 999999;
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
    
    public float getVelocity
    {
        get
        {
            return rb.accelerationRelative.magnitude;
        }
    }

    public float getDist
    {
        get
        {
            float dist = (sun.transform.position - this.transform.position).magnitude;

            if (dist < minDist)
                minDist = dist;

            if (dist > maxDist)
                maxDist = dist;

            return dist;
        }
    }
}
