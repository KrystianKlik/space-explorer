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
        percentageText.text = Mathf.RoundToInt(value / 2.17f) + "%";
    }

    public void textUpdatePaliwoBocznychBoosterow(float value)
    {
        percentageText.text = Mathf.RoundToInt(value / 1.48f) + "%";
    }
    public void textUpdateDlaCiagu(float value)
    {
        percentageText.text = Mathf.RoundToInt(value / 3.47f) + "%";
    }

    public void textUpdateFuelForMainBooster(float value)
    {
        percentageText.text = Mathf.RoundToInt(value / 2.86f) + "%";
    }

    public void textUpdateDlaOwieki(float value)
    {
        percentageText.text = Mathf.RoundToInt(value * 2) + "%";
    }

    public void textUpdatedlaPaliwaSecondStage(float value)
    {
        percentageText.text = Mathf.RoundToInt(value / 1.3f) + "%";
    }
}
