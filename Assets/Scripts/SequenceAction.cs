using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceAction : Action, ActionCallback
{
    public List<Action> sequence;
    public int repeat = -1;
    public int start = 0;

    public static SequenceAction GetAction(int repeat, int start, List<Action> sequence)
    {
        SequenceAction action = ScriptableObject.CreateInstance<SequenceAction>();
        action.sequence = sequence;
        action.repeat = repeat;
        action.start = start;
        return action;
    }

    public override void Start()
    {
        foreach (Action action in sequence)
        {
            action.GameObject = this.GameObject;
            action.Callback = this;
            action.Start();
        }

    }

    public override void Update()
    {
        if (sequence.Count == 0) return;
        if (start < sequence.Count)
            sequence[start].Update();
    }

    public void ActionEvent(Action source, GameObject gameObjectParam = null, ActionEventType events = ActionEventType.Compeleted,
                            int intParam = 0, string strParam = null)
    {
        source.destroy = false;
        this.start++;
        if (start >= sequence.Count)
        {
            this.start = 0;
            if (repeat > 0) repeat--;
            if (repeat == 0)
            {
                this.destroy = true;
                Callback.ActionEvent(this);
            }
        }
    }

    void OnDestroy()
    {
        foreach (Action action in sequence)
        {
            DestroyObject(action);
        }
    }
}
