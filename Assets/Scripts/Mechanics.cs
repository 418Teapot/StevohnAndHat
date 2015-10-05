using UnityEngine;
using UnityEngine.UI;

public class Mechanics : MonoBehaviour {
	private int numberOfTables = 0;
	public GameObject winZone;
    public bool fakeWin = false;
    private int score = 0;
    private int tablesCount = 0;

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
