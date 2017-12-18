using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scoreBoard : MonoBehaviour {

    public static scoreBoard instance;

    //creating variables for text objects
    public Text leftPlayerScoretxt;
    public Text rightPlayerScoretxt;

    //int variables for the score method
    public int leftplayerScore;
    public int rightplayerScore;
    public int maxPoints = 3;

	
	void Start () {
        instance = this;

        leftplayerScore = rightplayerScore = 0; //both player start with 0 as score
	}
	
	void Update () {
        if(leftplayerScore >= maxPoints || rightplayerScore >= maxPoints)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}

    public void GiveleftPlayerPoint()
    {
        leftplayerScore += 1;

        leftPlayerScoretxt.text = leftplayerScore.ToString();
    }

    public void GiverightPlayerPoint()
    {
        rightplayerScore += 1;

        rightPlayerScoretxt.text = rightplayerScore.ToString();
    }
}
