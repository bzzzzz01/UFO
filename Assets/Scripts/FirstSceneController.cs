using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneController : MonoBehaviour, SceneController, UserAction
{

    public UFOActionManager ufoActionManager;
    public ScoreRecorder scoreRecorder;
    public UFOFactory ufoFactory;

    private int round;
    private float time = 0;

    void Awake()
    {
        Director director = Director.getInstance();
        director.currentSceneController = this;
        director.currentSceneController.LoadResources();
        round = 1;
    }

    public void LoadResources() { }

    void Start()
    {
        ufoFactory = Singleton<UFOFactory>.Instance;
        scoreRecorder = Singleton<ScoreRecorder>.Instance;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            flyUFO();
            time = 0;
        }
        if (scoreRecorder.getScore() >= 10)
        {
            round = 2;
        }
        if (scoreRecorder.getScore() >= 30)
        {
            round = 3;
        }

    }



    public void flyUFO()
    {
        GameObject theUFO = ufoFactory.getUFO(round);
        theUFO.transform.position = Vector3.zero;
        if (round == 1)
        {
            ufoActionManager.ActionEvent(ufoActionManager.slowFlyAction, theUFO, ActionEventType.Started);
        }
        else if (round == 2)
        {
            ufoActionManager.ActionEvent(ufoActionManager.middleFlyAction, theUFO, ActionEventType.Started);
        }
        else if (round == 3)
        {
            ufoActionManager.ActionEvent(ufoActionManager.fastFlyAction, theUFO, ActionEventType.Started);
        }
    }


    //move gameObject
    public void hit(GameObject gameObject)
    {
        ufoFactory.freeUFO(gameObject);
        scoreRecorder.addScore(round);
    }

    public int getScore()
    {
        return scoreRecorder.getScore();
    }

    public int getRound()
    {
        return round;
    }

    public void reset()
    {
        round = 1;
        scoreRecorder.reset();
    }

}
