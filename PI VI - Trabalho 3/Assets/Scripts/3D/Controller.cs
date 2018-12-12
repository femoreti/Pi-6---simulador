using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    public static Controller instance;

    public Object3D[] asteroid;
    public Object3D Planet;
    public GameObject UI_Home, UI_Game;
    public List<GameObject> _objs = new List<GameObject>();

    private int currentObj = 0;
    public Object3D selected;

    [Header("UI - Quantity")]
    public Slider _asteroidsCount;
    public Slider _planetsCount;
    public Text _txtAsteroidsCount, _txtPlanetsCount;
    [Header("UI - Speed")]
    public Slider _asteroidsSpeed;
    public Slider _planetsSpeed;
    public Text _txtAsteroidsSpeed, _txtPlanetsSpeed;
    [Header("UI - Mass")]
    public Slider _asteroidsMass;
    public Slider _planetsMass;
    public Text _txtAsteroidsMass, _txtPlanetsMass;
    [Header("UI - Distance")]
    public Slider _asteroidsDistance;
    public Slider _planetsDistance;
    public Text _txtAsteroidsDistance, _txtPlanetsDistance;

    [Header("Game")]
    public Text objInfo;

    CameraScript cam;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        OnReset();
        cam = Camera.main.GetComponent<CameraScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentObj++;
            if (currentObj > _objs.Count-1)
                currentObj = 0;

            cam.OnSetTarget(_objs[currentObj].transform);
            selected = _objs[currentObj].GetComponent<Object3D>();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentObj--;
            if (currentObj < 0)
                currentObj = _objs.Count - 1;

            while(currentObj > _objs.Count - 1)
                currentObj = _objs.Count - 1;

            selected = _objs[currentObj].GetComponent<Object3D>();
            cam.OnSetTarget(_objs[currentObj].transform);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!UI_Home.activeSelf)
                OnReset();
        }

        OnUpdateObjectData();
    }

    public void OnClickInit()
    {
        _objs.Clear();
        currentObj = 0;
        _objs.Add(GameObject.FindWithTag("Sun"));

        int i;
        for (i = 0; i < _asteroidsCount.value; i++)
        {
            Object3D ast = Instantiate(asteroid[Random.Range(0, asteroid.Length)].gameObject).GetComponent<Object3D>();
            ast.name = "Asteroid " + (i + 1);

            float rMass = Random.Range(1, _asteroidsMass.value);
            float rDist = Random.Range(50f, _asteroidsDistance.value);
            float rSpeed = Random.Range(-_asteroidsSpeed.value, _asteroidsSpeed.value);

            ast.init(rMass, rDist, rSpeed);
            _objs.Add(ast.gameObject);
        }

        for (i = 0; i < _planetsCount.value; i++)
        {
            Object3D ast = Instantiate(Planet.gameObject).GetComponent<Object3D>();
            ast.name = "Planet " + (i+1);

            float rMass = Random.Range(50, _planetsMass.value);
            float rDist = Random.Range(250f, _planetsDistance.value);
            float rSpeed = Random.Range(-_planetsSpeed.value, _planetsSpeed.value);

            ast.GetComponent<MeshRenderer>().material.color = new Color32((byte)(Random.value * 255f), (byte)(Random.value * 255f), (byte)(Random.value * 255f), (byte)255f);
            ast.transform.localScale = Vector3.one * (rMass / 10f);
            ast.init(rMass, rDist, rSpeed);
            _objs.Add(ast.gameObject);
        }

        cam.OnInit();
        UI_Home.SetActive(false);
        UI_Game.SetActive(true);
    }

    public void OnReset()
    {
        UI_Home.SetActive(true);
        UI_Game.SetActive(false);

        _txtAsteroidsCount.text = _asteroidsCount.value.ToString("00");
        _txtAsteroidsSpeed.text = _asteroidsSpeed.value.ToString("00");
        _txtAsteroidsMass.text = _asteroidsMass.value.ToString("00");
        _txtAsteroidsDistance.text = _asteroidsDistance.value.ToString("00");

        _txtPlanetsCount.text = _planetsCount.value.ToString("00");
        _txtPlanetsSpeed.text = _planetsSpeed.value.ToString("00");
        _txtPlanetsMass.text = _planetsMass.value.ToString("00");
        _txtPlanetsDistance.text = _planetsDistance.value.ToString("00");

        selected = null;

        foreach (GameObject o in _objs)
        {
            if (o.tag == "Sun")
                continue;
            Destroy(o);
        }

        _objs.Clear();

        if (cam != null)
            cam.transform.position = new Vector3(0, 115, -550);
    }

    //Sliders
    //Asteroids
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

    //Planets
    public void OnChangeSliderPlanetsCount()
    {
        _txtPlanetsCount.text = _planetsCount.value.ToString("00");
    }

    public void OnChangeSliderPlanetsSpeed()
    {
        _txtPlanetsSpeed.text = _planetsSpeed.value.ToString("00");
    }

    public void OnChangeSliderPlanetsMass()
    {
        _txtPlanetsMass.text = _planetsMass.value.ToString("000");
    }

    public void OnChangeSliderPlanetsDistance()
    {
        _txtPlanetsDistance.text = _planetsDistance.value.ToString("00");
    }

    void OnUpdateObjectData()
    {
        string txt = string.Empty;

        if (selected == null)
        {
            txt = "Sun\n\nMass 500";
        }
        else
        {
            string objName = selected.gameObject.name;
            string objMass = selected._initialMass.ToString();
            string objInitSpeed = Mathf.Abs(selected._initialSpeed).ToString();
            string objCurrSpeed = (selected.getVelocity * 10f).ToString();
            string distActual = selected.getDist.ToString();
            string distMin = selected.minDist.ToString();
            string distMax = selected.maxDist.ToString();

            txt = string.Format("{0}\n\n" +
            "Mass {1}\n\n" +
            "Initial Force {2}\n" +
            "Current Velocity {3}\n\n" +
            "Distance to Sun\n" +
            "Minimum {4}\n" +
            "Maximum {5}\n" +
            "Actual {6}"
            , objName, objMass, objInitSpeed, objCurrSpeed, distMin, distMax, distActual);
        }

        objInfo.text = txt;
    }
}
