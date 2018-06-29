using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// class updates UI with variables from the gamemanager instance
/// </summary>
public class UpdateUI : MonoBehaviour {

    [Header("TextUI")]
    public Text moneyUI;
    public Text populationUI;
    public Text polutionUI;
    public Text healthUI;
    public Text ratingUI;

    private void SetUI(float _value, Text _text, string _name, string extraString = "")
    {
        _text.text = _name + _value.ToString() + extraString;
    }

    // Update is called once per frame
    void Update () {
        SetUI(GameManager._Instance.money, moneyUI, "Money: ");
        SetUI(GameManager._Instance.population, populationUI, "Population: ");
        SetUI(GameManager._Instance.pollution, polutionUI, "Polution: ");
        SetUI(GameManager._Instance.cityHealth, healthUI, "health: ");
        SetUI(GameManager._Instance.cityRating, ratingUI, "Rating: ", "/100");
    }
}
