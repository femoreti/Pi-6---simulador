using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public Object3D[] asteroid;
    public Object3D Planet;
    public GameObject UI;

    [Header("UI - Asteroid")]
    public Slider _asteroidsCount;
    public Text _txtAsteroidsCount;
    [Header("UI - Speed")]
    public Slider _asteroidsSpeed;
    public Text _txtAsteroidsSpeed;
    [Header("UI - Mass")]
    public Slider _asteroidsMass;
    public Text _txtAsteroidsMass;
    [Header("UI - Distance")]
    public Slider _asteroidsDistance;
    public Text _txtAsteroidsDistance;

    // Use this for initialization
    void Start () {
        OnResetUI();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickInit()
    {
        int i;
        for (i = 0; i < _asteroidsCount.value; i++)
        {
            Object3D ast = Instantiate(asteroid[Random.Range(0, asteroid.Length)].gameObject).GetComponent<Object3D>();

            float rMass = Random.Range(1, _asteroidsMass.value);
            float rDist = Random.Range(50f, _asteroidsDistance.value);
            float rSpeed = Random.Range(-_asteroidsSpeed.value, _asteroidsSpeed.value);

            ast.init(rMass, rDist, rSpeed);
        }

        for (i = 0; i < 15; i++)
        {
            Object3D ast = Instantiate(Planet.gameObject).GetComponent<Object3D>();

            float rMass = Random.Range(50, 300);
            float rDist = Random.Range(250f, 700f);
            float rSpeed = Random.Range(-300f, 300f);

            ast.GetComponent<MeshRenderer>().material.color = new Color32((byte)(Random.value * 255f), (byte)(Random.value * 255f), (byte)(Random.value * 255f), (byte)255f);

            ast.init(rMass, rDist, rSpeed);
        }

        UI.SetActive(false);
    }

    public void OnResetUI()
    {
        _txtAsteroidsCount.text = _asteroidsCount.value.ToString("00");
        _txtAsteroidsSpeed.text = _asteroidsSpeed.value.ToString("00");
        _txtAsteroidsMass.text = _asteroidsMass.value.ToString("00");
        _txtAsteroidsDistance.text = _asteroidsDistance.value.ToString("00");
    }

    public void OnChangeSliderAsteroidsCount()
    {
        _txtAsteroidsCount.text = _asteroidsCount.value.ToString("00");
    }
    
    public void OnChangeSliderAsteroidsSpeed()
    {
        _txtAsteroidsSpeed.text = _asteroidsSpeed.value.ToString("00");
    }

    public void OnChangeSliderAsteroidsMass()
    {
        _txtAsteroidsMass.text = _asteroidsMass.value.ToString("000");
    }

    public void OnChangeSliderAsteroidsDistance()
    {
        _txtAsteroidsDistance.text = _asteroidsDistance.value.ToString("00");
    }
}
