using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    private Dictionary<int, Action> actions = new Dictionary<int, Action>();
    private List<Action> waitingAdd = new List<Action>();
    private List<int> waitingDelete = new List<int>();

    protected void Start() { }
    protected void Update()
    {
        foreach (Action action in waitingAdd)
            actions[action.GetInstanceID()] = action;
        waitingAdd.Clear();

        foreach (KeyValuePair<int, Action> kv in actions)
        {
            Action action = kv.Value;
            if (action.destroy)
                waitingDelete.Add(action.GetInstanceID());
            else if (action.enable)
                action.Update();
        }

        foreach (int key in waitingDelete)
        {
            Action action = actions[key];
            actions.Remove(key);
            DestroyObject(action);
        }
        waitingDelete.Clear();
    }

    public void RunAction(GameObject gameObject, Action action, ActionCallback callback)
    {
        action.GameObject = gameObject;
        action.Callback = callback;
        waitingAdd.Add(action);
        action.Start();
    }


}
