using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour {

    public float minFOVx, maxFOVx;
    public float sensitivity;
    public Slider sliderFOV;
    public Transform center;
    public GameObject parent;
    public int max, min;

    private void Start() {
        sliderFOV.value = 60;
        Camera.main.fieldOfView = 60;
        Camera mycam = Camera.main;
    }
   
   private  void Update() {
        MoveCamCamera();
    }

    private void MoveCamCamera() {

        //get field of view of camera
        float fov = Camera.main.fieldOfView;
        
        //get keyboard input 
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = -1 * Input.GetAxisRaw("Vertical");

        //horinzontal input, move parent object
        if (moveHorizontal != 0) {
            float currentPosX = parent.transform.position.x + moveHorizontal;
            if (currentPosX > min && currentPosX < max) {
                parent.transform.position = new Vector3(parent.transform.position.x + moveHorizontal, parent.transform.position.y, parent.transform.position.z);
            }
        }

        //vertical input, move field of view
        if (moveVertical != 0) {
            sliderFOV.value += moveVertical;
        }

        //set field of view relative to slider input
        fov = sliderFOV.value;
        fov = Mathf.Clamp(fov, minFOVx, maxFOVx);
        Camera.main.fieldOfView = fov;

        //make sure camera is facing center object
        Camera.main.gameObject.transform.LookAt(center.position);

    }
}
