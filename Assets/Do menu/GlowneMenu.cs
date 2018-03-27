using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GlowneMenu : MonoBehaviour {


        public void Graj(int numerPoziomu)
    {
     if(numerPoziomu == 1)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel("SpaceX");
#pragma warning restore CS0618 // Type or member is obsolete

        }

    else if(numerPoziomu == 2)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel("Gra glowna");
#pragma warning restore CS0618 // Type or member is obsolete
        }
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }

		public void QuitGame()
    {
        Debug.Log("wyjscie");
        Application.Quit();
    }
	
  
}
