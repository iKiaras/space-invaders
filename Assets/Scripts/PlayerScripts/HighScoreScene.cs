using System;
using System.Collections;
using System.Collections.Generic;
using PlayerScripts;
using UnityEngine;

public class HighScoreScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void loadHighScores(string test)
    {
        HighScore highScore = new HighScore();
        JsonUtility.FromJson(test, (typeof(HighScore)));
    }
}
