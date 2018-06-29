using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Singleton GameManager
/// This Script keeps track of all the variables like: Money, Health etc    
/// if city rating >= 100/100, you win;
/// </summary>
public class GameManager : MonoBehaviour {

    [Header("GameObjects")]
    public GameObject buildCanvas;
    public GameObject WoodCanvas;
    public GameObject selectedObject;
    public GameObject WinPanel;
    private GameObject LastSelectedObject;

    [Header("city numbers")]
    public int amountOfHouses;
    public int amountOfFactories;
    public int amountOfLumberyards = 0;
    public int money, population, pollution;
    public float cityHealth;
    public float cityRating;

    private Color resetColor;

    public bool updateValues = false;
    public bool hasLumberYard = false;

    //singleton reference
    public static GameManager _Instance;
    private void Awake() {
        if (_Instance == null) {
            _Instance = this;
        } else {
            Destroy(this);
        }
    }

    private void Start() {
        buildCanvas.SetActive(false);
        WoodCanvas.SetActive(false);
        StartCoroutine(GameTicker());
    }

    void Update() {
        RaycastMouse();
        cityRating = Rating();
        if (cityRating >= 100) {
            cityRating = 100;
            WinPanel.SetActive(true);
            Debug.Log("you have destroyed the world, thank you!!!");
        }
    }

    private float Rating() {
        //get percentage of starthealth (100) and devide it by 100 to get current city rating. The more you ruin the environment, the higher your score;
        float preCalc = Mathf.Abs((100 - pollution) - 100);
        return preCalc / 10;
    }

    //in game ticks, all values are updated every 5 seconds
    private IEnumerator GameTicker() {
        yield return new WaitForSeconds(5);
        Debug.Log("updating");
        updateValues = true;

        yield return new WaitForFixedUpdate();
        updateValues = false;
        StartCoroutine(GameTicker());
    }

    //enable player to chop wood!
    public void SetLumberyard() {
        hasLumberYard = true;
    }

    //raycast to check mouseclick, then sets selected object to that object
    void RaycastMouse() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f)) {
                if (hit.transform.tag == "Buildable Tile") {
                    buildCanvas.SetActive(true);
                    selectedObject = hit.transform.gameObject;
                    selectedObject.GetComponent<MouseOver>().SetSelected();

                } else if (hit.transform.tag == "Factory") {
                    //factory behaviour  

                } else if (hit.transform.tag == "Tree" && GameManager._Instance.hasLumberYard) {
                    buildCanvas.SetActive(false);
                    WoodCanvas.SetActive(true);
                    selectedObject = hit.transform.gameObject;
                } else if (hit.transform.tag != "UI") {
                    buildCanvas.SetActive(false);
                }
            }
        }
    }
}
