using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : MonoBehaviour
{
    public GameObject Planet, _Asteroid;

	// Use this for initialization
	void Start () {
        Rigidbody2D rbPlanet = Planet.GetComponent<Rigidbody2D>();
        rbPlanet.mass = Random.Range(100000, 1000000);
        rbPlanet.isKinematic = true;
        Rigidbody2D rbAsteroid = _Asteroid.GetComponent<Rigidbody2D>();
        rbAsteroid.mass = Random.Range(10000, 300000);
        Asteroid a = _Asteroid.GetComponent<Asteroid>();
        a.initialVelocity = Random.Range(50, 130);
        a.initialRot = Random.Range(-45f, 45f);
        a.Init();

        Planet.GetComponent<Attractor>().canSimulate = true;
        _Asteroid.GetComponent<Attractor>().canSimulate = true;
    }

    public void OnReset()
    {
        Asteroid a = _Asteroid.GetComponent<Asteroid>();
        a.OnReset();
        Start();
        a.Init();
    }
}
