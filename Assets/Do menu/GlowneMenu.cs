using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GlowneMenu : MonoBehaviour {


        public void Graj()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

		public void QuitGame()
    {
        Debug.Log("wyjscie");
        Application.Quit();
    }
	
  
}
