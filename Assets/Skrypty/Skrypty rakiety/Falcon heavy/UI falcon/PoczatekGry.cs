using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PoczatekGry : MonoBehaviour {

    public Button yourButton;

    void Start()
    {
        Time.timeScale = 0f;
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
       // Debug.Log("You have clicked the button!");
        Time.timeScale = 1f;
    }
}