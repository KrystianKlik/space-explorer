using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Przedmioty : MonoBehaviour
{
    public GameObject czesc;
    public Transform miejsce;
    public Button yourButton;

 

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0)&&(yourButton.enabled)
    //        Instantiate(czesc, miejsce.position, miejsce.rotation);
    //}

    public void Start()
    {
     
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(Tworz);
    }


    void Tworz()
    {
        Instantiate(czesc, miejsce.position, miejsce.rotation);
        Debug.Log("Cos powstalo");
    }




    //public void Klikniecie()
    //{
    //    Debug.Log("Owiewka");
    //}

}

   