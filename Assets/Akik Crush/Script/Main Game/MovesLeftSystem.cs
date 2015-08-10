using UnityEngine;
using System.Collections;

public class MovesLeftSystem : MonoBehaviour
{
    public TextMesh textMovesLeft;
    public int movesLeft;

    void Start()
    {
        PlayerPrefs.SetInt("movesLeftAK", movesLeft);
    }

    void Update()
    {
        textMovesLeft.text = "";
        StringPusher.addStringDependInt(textMovesLeft, PlayerPrefs.GetInt("movesLeftAK"), 2, "0");
        textMovesLeft.text += (PlayerPrefs.GetInt("movesLeftAK") + " Left");
    }

    public static void movesLeftMinusOne()
    {
        PlayerPrefs.SetInt("movesLeftAK", PlayerPrefs.GetInt("movesLeftAK") - 1);
    }

    public static bool movesLeftIsEmpty()
    {
        if (PlayerPrefs.GetInt("movesLeftAK") <= 0)
            return true;

        return false;
    }
}