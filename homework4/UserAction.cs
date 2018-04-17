using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UserAction
{
    void hit(GameObject gameObject);
    int getScore();
    int getRound();
    void reset();
}

