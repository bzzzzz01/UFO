using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOActionManager : ActionManager, ActionCallback
{
    public float slowSpeed = 3;
    public float middleSpeed = 5;
    public float fastSpeed = 10;
    public FirstSceneController sceneController;
    public FlyAction slowFlyAction, middleFlyAction, fastFlyAction;

    protected new void Start()
    {
        sceneController = Director.getInstance().currentSceneController as FirstSceneController;
        sceneController.ufoActionManager = this;
        slowFlyAction = FlyAction.getAction(new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), slowSpeed);
        middleFlyAction = FlyAction.getAction(new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), middleSpeed);
        fastFlyAction = FlyAction.getAction(new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), fastSpeed);

    }

    protected new void Update()
    {
        base.Update();
    }

    public void ActionEvent(Action source, GameObject gameObjectParam = null, ActionEventType events = ActionEventType.Compeleted,
                            int intParam = 0, string strParam = null)
    {
        if (events == ActionEventType.Started)
        {
            slowFlyAction = FlyAction.getAction(new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), slowSpeed);
            middleFlyAction = FlyAction.getAction(new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), middleSpeed);
            fastFlyAction = FlyAction.getAction(new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), fastSpeed);
            this.RunAction(gameObjectParam, source, this);
        }
        else if(events == ActionEventType.Compeleted)
        {
            UFOFactory ufofactory = Singleton<UFOFactory>.Instance;
            ufofactory.freeUFO(gameObjectParam);
        }

    }

}