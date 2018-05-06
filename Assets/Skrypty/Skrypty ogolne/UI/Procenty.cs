using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Procenty : MonoBehaviour {

     Text percentageText;

    // Use this for initialization
    void Start () {
        percentageText = GetComponent<Text>();
    }

    public void textUpdatePaliwoGlownegoBoostera(float value)
    {
        percentageText.text = Mathf.RoundToInt(value / 2.5f) + "%";
    }

    public void textUpdatePaliwoBocznychBoosterow(float value)
    {
        percentageText.text = Mathf.RoundToInt(value / 2) + "%";
    }
    public void textUpdateDlaCiagu(float value)
    {
        percentageText.text = Mathf.RoundToInt(value / 4) + "%";
    }

    public void textUpdateDlaOwieki(float value)
    {
        percentageText.text = Mathf.RoundToInt(value * 2) + "%";
    }

    public void textUpdatedlaPaliwaSecondStage(float value)
    {
        percentageText.text = Mathf.RoundToInt(value) + "%";
    }
}
