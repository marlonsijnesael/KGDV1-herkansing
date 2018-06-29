using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/// <summary>
/// The functions of this class are  called by buttons on the Build-canvas
/// The values for the Buildhouse() function are set in the inspector at the respective button
/// </summary>


//custom struct to make a vector 2 like construction of the prefab the button should load and how much it should cost
public struct ButtonInput {
    public int cost;
    public string prefabName;
}

public class BuildScripts : MonoBehaviour {
    public GameObject cameraParent;

    //used to have 2 inputs from on click in unity UI
    //splits String in to parts and parsed them to integers and puts them in a ButtonInput struct
    private ButtonInput SplitOutput(string _item) {
        string[] _split = _item.Split(","[0]);
        int _cost = int.Parse(_split[0]);
        string _prefabName = _split[1];
        ButtonInput _returnValue = new ButtonInput();
        _returnValue.cost = _cost;
        _returnValue.prefabName = _prefabName;
        return _returnValue;
    }


    public void ReplaceTile(GameObject _prefab) {
        //cache Gameobject to avoid repition
        GameObject objectToReplace = GameManager._Instance.selectedObject;
        GameObject building = Instantiate(_prefab);

        //make camera shake when building is placed (camera shake script not made by me)
        cameraParent.GetComponent<CameraShake>().ShakeCamera(0.25f, 0.1f);

        //set new building's properties to old building's properties
        building.transform.position = objectToReplace.transform.position;
        building.transform.rotation = objectToReplace.transform.rotation;
        building.transform.SetParent(objectToReplace.transform.parent);

        //destroy old building
        Destroy(objectToReplace);
    }

    public void ChopTree(GameObject _prefab) {
        ReplaceTile(_prefab);
        GameManager._Instance.money += 10;
    }

    //add number for cost and prefab in this format: "x,y" 
    public void Build(string _costsAndPrefab) {
        //split cost and prefab to spawn, for readabilty
        int money = GameManager._Instance.money;

        //cast cost as int
        int cost = (int)SplitOutput(_costsAndPrefab).cost;
        GameObject prefabToSpawn = Resources.Load(SplitOutput(_costsAndPrefab).prefabName, typeof(GameObject)) as GameObject;

        if (cost <= money) {

            //scale building price with amount of buildings of that type, checks how many there are by searching for the tag of the buildings
            float scaler = 1.2f * (GameObject.FindGameObjectsWithTag(prefabToSpawn.tag).Length + 1);
            Debug.Log(cost * scaler);
            //charge cost
            GameManager._Instance.money -= (int)(cost * scaler);
            ReplaceTile(prefabToSpawn);
        }
    }
}


