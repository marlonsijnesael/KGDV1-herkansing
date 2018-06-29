using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// class is used to highlight tiles on hover
/// </summary>
public class MouseOver : MonoBehaviour {

    public Color startCol;
    public Color lastCol;
    public static string selected;

    private void Start() {
        startCol = this.GetComponent<MeshRenderer>().material.color;
        lastCol = startCol;
    }

    public void SetSelected() {
        this.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void OnMouseOver() {
        this.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void OnMouseExit() {
        this.GetComponent<MeshRenderer>().material.color = startCol;
    }

    public void IsSelected() {
        if (selected == this.gameObject.name) {
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if (selected != this.gameObject.name) {
            this.GetComponent<MeshRenderer>().material.color = lastCol;
        }
    }

}
