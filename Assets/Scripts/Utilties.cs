using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// collection of functions that can be used in more than one class, but do not actually belong in them
/// </summary>
public class Utilties : MonoBehaviour {


    //if active object is deactivated and vice versa
    public void ActiveOrInactive(GameObject _ObjectToChange) {
        _ObjectToChange.SetActive(!_ObjectToChange.activeInHierarchy);
    }

    public void ChangeScene(int _scene) {
        SceneManager.LoadScene(_scene);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
