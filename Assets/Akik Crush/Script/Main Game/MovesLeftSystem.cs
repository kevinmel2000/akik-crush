using UnityEngine;
using System.Collections;

public class MovesLeftSystem : MonoBehaviour
{
    public int movesLeft;

    void Start()
    {
    }

    public void movesLeftMinusOne()
    {
        movesLeft -= 1;
    }

    public bool movesLeftIsEmpty()
    {
        if (movesLeft <= 0)
            return true;

        return false;
    }
}
