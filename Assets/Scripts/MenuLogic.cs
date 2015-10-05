using UnityEngine;
using System.Collections;

public class MenuLogic : MonoBehaviour {

	public void loadLevel()
    {
        Debug.Log("Loading...");
        //GameObject.FindWithTag("MainCamera").GetComponent<ScreenFader>().EndScene(1);
        Application.LoadLevel("daClub");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
