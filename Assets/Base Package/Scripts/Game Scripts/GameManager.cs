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

    //crushEffectCreator
    CrushEffectCreator cEC;
    public GameObject hugeStone;
    int timeDelayState;

    void Awake()
    {
        instance = this;
        timeDelayState = 0;
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

        StringPusher.addStringDependInt(scoreText, score, 6, "0");
        scoreText.text += score.ToString();
        jellyText.text = "Jelly : " + totalNoOfJellies.ToString();
        cEC = GetComponent<CrushEffectCreator>();
    }

    void Update()
    {
        if (!WinLoseSystem.gameStateIsWin() && !WinLoseSystem.gameStateIsLose())
        {
            if (!GameManager.instance.isBusy)
            {
                hugeStone.GetComponent<Animator>().SetBool("IsHit", false);
                WinLoseSystem.comparingScore(score); //membandingkan score dan maxScore jika score >= maxScore maka state jadi "IsWin"
                WinLoseSystem.checkingMovesLeft(); //mengecek sisa langkah jika 0 maka state menjadi "IsLose"
            }

            if (isTimeToPlusOne(24))
                hugeStone.GetComponent<Animator>().SetBool("IsHit", false);
        }

        if (WinLoseSystem.gameStateIsWin())
            Debug.Log("IsWin");
        if (WinLoseSystem.gameStateIsLose())
            Debug.Log("IsLose");
    }

    bool isTimeToPlusOne(int maxTime)
    {
        timeDelayState += 1;
        if (timeDelayState >= maxTime)
        {
            timeDelayState = 0;
            return true;
        }
        return false;
    }

    internal void AddScore()
    {
        //saat proses matching berhasil
        int temp = 10 * numberOfItemsPoppedInaRow * (numberOfItemsPoppedInaRow / 5 + 1);
        //  print(temp);
        score += temp;
        StringPusher.addStringDependInt(scoreText, score, 6, "0");
        scoreText.text += score.ToString();
        cEC.createCrushEffect();
        if (!WinLoseSystem.gameStateIsWin() && !WinLoseSystem.gameStateIsLose())
            hugeStone.GetComponent<Animator>().SetBool("IsHit", true);
    }
}