using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{    
    public static GameManager instance;
    public GameObject[] playingObjectPrefabs;
    public GameObject[] horizontalPrefabs;
    public GameObject[] verticalPrefabs;
    public GameObject universalPlayingObjectPrefab;
    public GameObject []jellyPrefab;

    internal int numberOfColumns;
    internal int numberOfRows;
    public float gapBetweenObjects = .7f;
    public float swappingTime = .8f;
    public float objectFallingDuration = .5f;
    internal float initialObjectFallingDuration;
    internal bool isBusy = false;
    public int totalNoOfJellies = 0;

    public iTween.EaseType objectfallingEase;

    internal TextMesh scoreText;
    internal TextMesh jellyText;
    int score;

    internal static int numberOfItemsPoppedInaRow = 0;
    

    void Awake()
    {
        instance = this;
    }

	void Start () 
    {
        //permulaan game
        scoreText = GameObject.Find("Score Text").GetComponent<TextMesh>();
        jellyText = GameObject.Find("Jelly Text").GetComponent<TextMesh>();
        initialObjectFallingDuration = objectFallingDuration;
        numberOfColumns = LevelStructure.instance.numberOfColumns;
        numberOfRows = LevelStructure.instance.numberOfRows;
        numberOfItemsPoppedInaRow = 0;
        zeroStringMaker(scoreText, score, 6);
        scoreText.text += score.ToString();
        jellyText.text = "Jelly : " + totalNoOfJellies.ToString();
	}

    void zeroStringMaker(TextMesh sText, int value, int countMax)
    {
        sText.text = "";
        Debug.Log((countMax - (value.ToString().Length)));
        for (int i = 0; i < countMax - (value.ToString().Length); i++)
        {
            sText.text += "0";
        }
    }

    internal void AddScore()
    {
        //saat proses matching berhasil
        int temp = 10 * numberOfItemsPoppedInaRow * (numberOfItemsPoppedInaRow / 5 + 1);
      //  print(temp);
        score += temp;
        zeroStringMaker(scoreText, score, 6);
        scoreText.text += score.ToString();
    }



   
}
