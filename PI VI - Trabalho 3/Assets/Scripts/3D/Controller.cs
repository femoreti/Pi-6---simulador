using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    public static Controller instance;

    public Object3D[] asteroid;
    public Object3D Planet;
    public GameObject UI;
    public List<PhysicBody> _objs = new List<PhysicBody>();

    private int currentObj = 0;

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

    CameraScript cam;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        OnResetUI();
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
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentObj--;
            if (currentObj < 0)
                currentObj = _objs.Count - 1;

            while(currentObj > _objs.Count - 1)
                currentObj = _objs.Count - 1;

            cam.OnSetTarget(_objs[currentObj].transform);
        }
    }

    public void OnClickInit()
    {
        _objs.Clear();
        currentObj = 0;
        _objs.Add(GameObject.FindWithTag("Sun").GetComponent<PhysicBody>());

        int i;
        for (i = 0; i < _asteroidsCount.value; i++)
        {
            Object3D ast = Instantiate(asteroid[Random.Range(0, asteroid.Length)].gameObject).GetComponent<Object3D>();

            float rMass = Random.Range(1, _asteroidsMass.value);
            float rDist = Random.Range(50f, _asteroidsDistance.value);
            float rSpeed = Random.Range(-_asteroidsSpeed.value, _asteroidsSpeed.value);

            ast.init(rMass, rDist, rSpeed);
            _objs.Add(ast.GetComponent<PhysicBody>());
        }

        for (i = 0; i < 15; i++)
        {
            Object3D ast = Instantiate(Planet.gameObject).GetComponent<Object3D>();

            float rMass = Random.Range(50, 300);
            float rDist = Random.Range(250f, 700f);
            float rSpeed = Random.Range(-300f, 300f);

            ast.GetComponent<MeshRenderer>().material.color = new Color32((byte)(Random.value * 255f), (byte)(Random.value * 255f), (byte)(Random.value * 255f), (byte)255f);

            ast.init(rMass, rDist, rSpeed);
            _objs.Add(ast.GetComponent<PhysicBody>());
        }

        cam.OnInit();
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
