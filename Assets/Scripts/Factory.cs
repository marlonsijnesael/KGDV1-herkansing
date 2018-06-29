using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// behaviour for factories
/// each factory checks the 8 tiles around it, if it's a house ->  cityhealh goes down.
/// </summary>
/// 
public class Factory : Building_BaseClass {

    public override void UpdateVariables() {
        GameManager._Instance.pollution += base.pollution;
        GameManager._Instance.money += base.money;
        GameManager._Instance.cityHealth += base.health;
    }

    //highlight all tiles surronding the factory
    public override void OnMouseEnter() {
        Collider[] tiles = Physics.OverlapSphere(this.transform.position, 1.5f);

        foreach (Collider col in tiles) {
            Color c = col.gameObject.GetComponent<MeshRenderer>().material.color;
            col.gameObject.GetComponent<MeshRenderer>().material.color = new Color(c.r + 10, c.g, c.b);
        }
    }

    //set tiles back to start color;
    public override void OnMouseExit() {
        Collider[] tiles = Physics.OverlapSphere(this.transform.position, 1.5f);

        foreach (Collider col in tiles) {
            Color c = col.gameObject.GetComponent<MeshRenderer>().material.color;
            col.gameObject.GetComponent<MeshRenderer>().material.color = new Color(c.r - 10, c.g, c.b);
        }
    }
 
    //check if factory is build near houses, if true -> decrease health
    public override void CheckNeighbours() {
        Collider[] tiles = Physics.OverlapSphere(this.transform.position, 2.5f);
        int houseCount = 0;
        foreach (Collider col in tiles) {

            if (col.tag == "House") {
                houseCount++;
            }
            base.health -= houseCount * 0.1f;
        }
    }
}
