using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsDemo : MonoBehaviour
{

    public PhysicBody teste;
    // Use this for initialization
    void Start()
    {
        teste = GetComponent<PhysicBody>();
        teste.mass = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            teste.AddForce(new Vector3(0, 0, 10));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            teste.AddForce(new Vector3(0, 0, -100));
        }

        //teste.transform.Translate(new Vector3(teste.acceleration.x * Time.deltaTime,
        //    teste.acceleration.y * Time.deltaTime,
        //    teste.acceleration.z * Time.deltaTime));
    }

    //private void FixedUpdate()
    //{
    //    teste.transform.Translate(new Vector3(teste.acceleration.x * Time.fixedDeltaTime,
    //        teste.acceleration.y * Time.fixedDeltaTime,
    //        teste.acceleration.z * Time.fixedDeltaTime));
    //}
}
