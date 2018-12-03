using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract3D : MonoBehaviour {
    //6,67408 × 10-11
    const float G = 6.67408f;

    public Rigidbody rb;

    public bool canSimulate = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!canSimulate)
            return;

        Attract3D[] attractorList = FindObjectsOfType<Attract3D>();
        foreach (Attract3D attractor in attractorList)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    void Attract(Attract3D objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
