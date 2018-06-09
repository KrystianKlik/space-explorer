using UnityEngine;
using UnityEngine.UI;

public class Czas : MonoBehaviour{
    public Text time;
    public GameObject timeGameObj;

     void Update()
    {
        ZmianaCzasu();
    }

    public void ZmianaCzasu()
    {
        if (Input.GetKey(KeyCode.P))
        {
            time.text = "Time: Paused";
            Time.timeScale = 0f;
        }

       else if (Input.GetKey(KeyCode.Alpha1))
        {
            time.text = "Time: x1";
            if (Time.timeScale != 1.0F)
                Time.timeScale = 1f;
            else
                Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }

       else if (Input.GetKey(KeyCode.Alpha2))
        {
            Time.timeScale = 2f;
            time.text = "Time: x2";
        }

       else if (Input.GetKey(KeyCode.Alpha3))
        {
            Time.timeScale = 4f;
            time.text = "Time: x4";
        }

       else if (Input.GetKey(KeyCode.Alpha4))
        {
            Time.timeScale = 8f;
            time.text = "Time: x8";
        }
       else if (Input.GetKey(KeyCode.Alpha5))
        {
            Time.timeScale = 16f;  //powyżej tej wartosci już się przycina
            time.text = "Time: x16";
        }
       else if (Input.GetKey(KeyCode.Alpha6))
        {
            Time.timeScale = 100; // to już jest maksymalna wartość
            time.text = "Time: x100";
        }
    }
}