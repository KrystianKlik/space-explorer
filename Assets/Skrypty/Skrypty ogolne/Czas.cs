using UnityEngine;

public class Czas : MonoBehaviour {

     void Update()
    {
        PrzyspieszenieCzasu();
    }

    public void PrzyspieszenieCzasu()
    {
        if (Input.GetKey(KeyCode.Q))
        {

            if (Time.timeScale != 1.0F)
                Time.timeScale = 1f;
            else
                Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }

        if (Input.GetKey(KeyCode.Alpha1))
             Time.timeScale = 2f;
        

        if (Input.GetKey(KeyCode.Alpha2))
             Time.timeScale = 4f;


        if (Input.GetKey(KeyCode.Alpha3))
             Time.timeScale = 8f;
        

        if (Input.GetKey(KeyCode.Alpha4))
             Time.timeScale = 16f;  //powyżej tej wartosci już się ścina
        

        if (Input.GetKey(KeyCode.Alpha5))
            Time.timeScale = 100f;
    
    }

}