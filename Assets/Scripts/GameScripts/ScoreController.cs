using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    MyLabel score;
    public static int currentScore=0;
    void Start()
    {
        score = new MyLabel("Score");
        score.SetText("");
        PickUpController.ObjectIsPickedUp += PointIsGained;
    }

    private void PointIsGained()
    {
        StoreSaver.currency += 10;
        currentScore +=10;
    }

    void Update()
    {
        score.SetText(currentScore.ToString());
    }

    private void OnDestroy()
    {
        PickUpController.ObjectIsPickedUp -= PointIsGained;
    }
}
