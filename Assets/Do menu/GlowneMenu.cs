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
            Application.LoadLevel("Ksiezyc");
#pragma warning restore CS0618 // Type or member is obsolete
        }

        else if (numerPoziomu == 3)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel("Awaria");
#pragma warning restore CS0618 // Type or member is obsolete
        }
        
    }

		public void QuitGame()
    {
        Debug.Log("wyjscie");
        Application.Quit();
    }
	
  
}
