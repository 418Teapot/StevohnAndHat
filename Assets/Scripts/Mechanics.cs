using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mechanics : MonoBehaviour {
	private int numberOfTables = 0;
	public GameObject winZone;
    public bool fakeWin = false;
    private int score = 0;
    private int tablesCount = 0;
    private bool uploadScores = true;

	// Use this for initialization
	void Start () {
		numberOfTables = GameObject.FindGameObjectsWithTag("Table").Length;
        tablesCount = numberOfTables;
		Debug.Log ("Tables" + numberOfTables);
        GameObject.FindWithTag("TablesText").GetComponent<Text>().text = "Tables Left: " + tablesCount;
    }
	    

	// Update is called once per frame
	void Update () {
		if(numberOfTables <= winZone.GetComponent<winCounter>().Tables() || fakeWin){
			Debug.Log("you haz won");
			Time.timeScale = 0.5f;
            GameObject.FindWithTag("WinText").GetComponent<Text>().enabled = true;
            GameObject.FindWithTag("AnyBtnTryAgain").GetComponent<Text>().enabled = true;
            GameObject player = GameObject.FindWithTag("Player");
            foreach(CircleCollider2D cc in player.GetComponents<CircleCollider2D>())
            {
                cc.enabled = false;
            }

            foreach(BoxCollider2D bc in player.GetComponents<BoxCollider2D>())
            {
                bc.enabled = false;
            }

            // update scores på serveren            
            StartCoroutine(putHighscores(score));

            if (Input.GetButtonDown("Jump")){
                Application.LoadLevel(Application.loadedLevel);
            }
                
		} else
        {
            Time.timeScale = 1.0f;
            GameObject.FindWithTag("WinText").GetComponent<Text>().enabled = false;
            GameObject.FindWithTag("AnyBtnTryAgain").GetComponent<Text>().enabled = false;
        }
	}

    IEnumerator putHighscores(int scores)
    {
        if (uploadScores)
        {
            uploadScores = false;
            WWW web = new WWW("http://46.101.251.99/stevohn/highscores.php?a=set&n=stevohn&s=" + scores);
            yield return web;
            if (web.text == "NEWHS")
            {
                Debug.Log("New Highscore");
                GameObject.FindWithTag("HsText").GetComponent<Text>().enabled = true;
            }
            StopAllCoroutines(); //only run once :)
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int addScore)
    {
        score += addScore;
        tablesCount--;
        GameObject.FindWithTag("TablesText").GetComponent<Text>().text = "Tables Left: " + tablesCount;
        GameObject.FindWithTag("ScoreText").GetComponent<Text>().text = "Score: " + GetScore();
    }
}
