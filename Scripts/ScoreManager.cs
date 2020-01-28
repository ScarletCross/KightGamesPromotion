using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    private int score = 0;

    private Text scoreLabel;



    // Use this for initialization
    void Start()
    {

        scoreLabel = GameObject.Find("ScoreText").GetComponent<Text>();

        scoreLabel.text = "Score" + score;


    }

    // Update is called once per frame
    void Update()
    {

    }

    // スコアを増加させるメソッド
    // 外部からアクセスするためpublicで定義する
    public void AddScore(int amount)
    {

        score += amount;
        scoreLabel.text = "SCORE：" + score;
    }
}
