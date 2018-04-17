using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{

    private UserAction action;

    void Start()
    {
        action = Director.getInstance().currentSceneController as UserAction;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                action.hit(hit.collider.gameObject);
            }
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, Screen.height - 60, 60, 30), "reset"))
        {
            action.reset();
        }
        GUI.Label(new Rect(10, 10, 60, 30), "Round: " + action.getRound());
        GUI.Label(new Rect(10, 30, 60, 30), "Score: " + action.getScore());
    }
}
