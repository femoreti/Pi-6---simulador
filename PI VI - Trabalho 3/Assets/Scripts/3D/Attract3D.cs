using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract3D : MonoBehaviour {
    //6,67408 × 10-11
    const float G = 6.67408f;

    private PhysicBody rb;

    public bool canSimulate = true;

    private void Start()
    {
        rb = GetComponent<PhysicBody>();
    }

    private void FixedUpdate()
    {
        if (!canSimulate)
            return;

        Attract3D[] attractorList = FindObjectsOfType<Attract3D>();
        foreach (Attract3D attractor in attractorList)
        {
            if (attractor != this && attractor.enabled)
                Attract(attractor);
        }
    }

    void Attract(Attract3D objToAttract)
    {
        PhysicBody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.transform.position - rbToAttract.transform.position;
        float distance = direction.magnitude;

        if (distance == 0f)
        {
            
            return;
        }

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;
        transform.rotation = Quaternion.LookRotation(-direction.normalized, Vector3.up);

        rbToAttract.AddRelativeForce(force);
    }
}
