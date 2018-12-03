using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public Asteroid3D asteroid;

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
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Asteroid3D ast = Instantiate(asteroid.gameObject).GetComponent<Asteroid3D>();
            ast.init();
        }
	}

    public void OnResetUI()
    {
        _txtAsteroidsCount.text = _asteroidsCount.value.ToString("00");
        _txtAsteroidsSpeed.text = _asteroidsSpeed.value.ToString("00");
        _txtAsteroidsMass.text = _asteroidsMass.value.ToString("000");
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
