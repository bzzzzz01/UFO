using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFactory : MonoBehaviour
{

    public GameObject UFOPrefab = null;

    private List<UFO> used = new List<UFO>();
    private List<UFO> free = new List<UFO>();

    private void Awake()
    {
        UFOPrefab = Instantiate(Resources.Load("UFO") as GameObject);
        UFOPrefab.SetActive(false);
    }

    public GameObject getUFO(int round)
    {
        GameObject newUFO = null;
        if (free.Count > 0)
        {
            newUFO = free[0].gameObject;
            newUFO.SetActive(true);
            free.Remove(free[0]);
        }
        else
        {
            newUFO = Instantiate(UFOPrefab);
            newUFO.SetActive(true);
            newUFO.AddComponent<UFO>();
        }
        used.Add(newUFO.GetComponent<UFO>());

        if (round == 1)
        {
            newUFO.GetComponent<UFO>().size = new Vector3(1.5f, 1.5f, 1.5f);
            newUFO.GetComponent<UFO>().color = Color.red;
            newUFO.GetComponent<Transform>().localScale= new Vector3(1.5f, 1.5f * 0.5f, 1.5f);
            newUFO.GetComponent<Renderer>().material.color = Color.red;
        }
        if (round == 2)
        {
            newUFO.GetComponent<UFO>().size = new Vector3(1, 1, 1);
            newUFO.GetComponent<UFO>().color = Color.green;
            newUFO.GetComponent<Renderer>().material.color = Color.green;
        }
        if (round == 3)
        {
            newUFO.GetComponent<UFO>().size = new Vector3(0.8f, 0.8f, 0.8f);
            newUFO.GetComponent<UFO>().color = Color.blue;
            newUFO.GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f * 0.5f, 0.8f);
            newUFO.GetComponent<Renderer>().material.color = Color.blue;
        }
        return newUFO;
    }

    public void freeUFO(GameObject theUFO)
    {
        UFO tmp = null;
        foreach (UFO ufo in used)
        {
            if (ufo.gameObject.GetInstanceID() == theUFO.GetInstanceID() )
            {
                tmp = ufo;
            }
        }
        if (tmp != null)
        {
            tmp.gameObject.SetActive(false);
            free.Add(tmp);
            used.Remove(tmp);
        }
    }

}