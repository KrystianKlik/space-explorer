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
        percentageText.text = Mathf.RoundToInt(value * 0.694444f) + "%";
    }

    public void textUpdatePaliwoBocznychBoosterow(float value)
    {
        percentageText.text = Mathf.RoundToInt(value / 0.8f) + "%";
    }
    public void textUpdateDlaCiagu(float value)
    {
        percentageText.text = Mathf.RoundToInt(value * 2272f) + "%";
    }

    public void textUpdateFuelForMainBooster(float value)
    {
        percentageText.text = Mathf.RoundToInt(value * 5681.818f) + "%";
    }

    public void textUpdateDlaOwieki(float value)
    {
        percentageText.text = Mathf.RoundToInt(value * 22727f) + "%";
    }

    public void textUpdatedlaPaliwaSecondStage(float value)
    {
        percentageText.text = Mathf.RoundToInt(value / 0.8f) + "%";
    }

    public void textUpdateForLunadLander(float value)
    {
        percentageText.text = Mathf.RoundToInt(value * 0.625f) + "%";
    }
}
