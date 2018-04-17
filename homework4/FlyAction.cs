using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAction : Action
{
    public Vector3 direction;
    public float speed;

    public static FlyAction getAction(Vector3 direction, float speed)
    {
        FlyAction action = CreateInstance<FlyAction>();
        action.direction = direction;
        action.speed = speed;
        return action;
    }

    public override void Start() { }
    
    public override void Update()
    {
        this.GameObject.transform.position += direction * speed * Time.deltaTime;
        if (this.GameObject.transform.position.y > 10 || this.GameObject.transform.position.y < -10)
        {
            this.destroy = true;
            this.Callback.ActionEvent(this, this.GameObject, ActionEventType.Compeleted);
        }

    }

}