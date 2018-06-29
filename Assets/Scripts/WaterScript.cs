using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//simple script to animate the water tiles;
public class WaterScript : MonoBehaviour {

    private Renderer rend;

    [Range(0, 1)]
    public float scaler;

    void Start() {
        rend = GetComponent<Renderer>();
    }

   //takes texture scale and moves it along the cos/sin of time.time * scale
    void Update() {
        float scalerX = Mathf.Cos(Time.time) * scaler + 1;
        float scalerY = Mathf.Sin(Time.time) * scaler + 1;
        rend.material.SetTextureScale("_MainTex", new Vector2(scalerX, scalerY));
    }
}
