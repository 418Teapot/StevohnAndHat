using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuLogic : MonoBehaviour {

    private string hsFromServer;
    private bool showingScores = false;

    private GameObject logo;

	public void loadLevel()
    {
        Debug.Log("Loading...");
        
        Application.LoadLevel("daClub");
    }

    void Start()
    {
        logo = GameObject.FindWithTag("LogoGfx");
    }

    void Update()
    {
        if (showingScores)
        {
            if (Input.GetButtonDown("Jump"))
            {
                toggleScores();
            }
        }
    }

    public void showHighscores()
    {
        logo.SetActive(false);
        //Text hsTxt = GameObject.FindWithTag("HsText").GetComponent<Text>();
        StartCoroutine(GetScores());        
    }

    public void toggleScores()
    {
        if (!showingScores)
        {
            showHighscores();
            showingScores = true;
            GameObject.FindWithTag("HsBtn").GetComponentInChildren<Text>().text = "Back";
        } else if (showingScores)
        {
            showingScores = false;
            logo.SetActive(true);
            GameObject.FindWithTag("HsBtn").GetComponentInChildren<Text>().text = "Highscores";
        }
    }
    

    IEnumerator GetScores()
    {
        WWW web = new WWW("http://46.101.251.99/stevohn/highscores.php?a=get");
        yield return web;    
        hsFromServer = web.text;
        Debug.Log("Higscores: " + hsFromServer);

        string[] scores = hsFromServer.Split(';');
        hsFromServer = "Highscores:\n\t\t\t\t";
        int scoreNr = 1;
        foreach(string s in scores)
        {
            string[] score = s.Split('=');
            hsFromServer += scoreNr+"# - "+score[1] + "\n\t\t\t\t";
            scoreNr++;
        }
        GameObject.FindWithTag("HsText").GetComponent<Text>().text = hsFromServer;
        GameObject.FindWithTag("HsText").GetComponent<Text>().enabled = true;
        StopCoroutine(GetScores());
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
