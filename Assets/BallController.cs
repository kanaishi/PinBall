using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    public GameObject TextScore; //テキストスコア表示
    public int score;
    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 2;
            TextScore.GetComponent<Text> ().text = score.ToString ();

            //Debug.Log("SmallStarTag" + other.gameObject.name);
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 100;
            TextScore.GetComponent<Text>().text = score.ToString();
            Debug.Log("LargeStarTag" + other.gameObject.name);
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            score += 50;
            TextScore.GetComponent<Text>().text = score.ToString();
           // Debug.Log("SmallCloudTag" + other.gameObject.name);
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            score += 1000;
            TextScore.GetComponent<Text>().text = score.ToString();
            //Debug.Log("LargeCloudTag" + other.gameObject.name);
            //Debug.Log("Hit" + other.gameObject.name);
        }

       
    }
}
