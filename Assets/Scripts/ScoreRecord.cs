using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRecord : MonoBehaviour
{
    // Start is called before the first frame update

    public Text scoreRecord;
    private int ScoreNum;
    // Update is called once per frame
    void Update()
    {
        ScoreNum = 0;
        scoreRecord.text = "Score: " + ScoreNum;
    }
}
