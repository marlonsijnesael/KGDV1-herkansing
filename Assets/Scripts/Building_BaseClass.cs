using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all buildings, also checks if variables should be updated
/// Behaviour of UpdateVariables() is 
/// </summary>

public abstract class Building_BaseClass : MonoBehaviour {

    public int population, pollution, money;
    public float health;

    private void Awake() {
        //add or substract values when instantiated
        GameManager._Instance.population += population;
        GameManager._Instance.pollution += pollution;
        GameManager._Instance.cityHealth += health;
        GameManager._Instance.money += money;
    }

    public void FixedUpdate() {

        if (GameManager._Instance.updateValues) {
            CheckNeighbours();
            UpdateVariables();
        }
    }

    //updates all variables that are influenced by this building
    public virtual void UpdateVariables() {}

    //checksIfBuildingsAffectNeighbours:
    public virtual void CheckNeighbours() {}

    public virtual void OnMouseEnter() {}

    public virtual void OnMouseExit() {}


}
