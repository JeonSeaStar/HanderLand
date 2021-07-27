using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Behavior
{
    public string Behavior_name;
    public int weight;

    public Behavior(Behavior behavior)
    {
        this.weight = behavior.weight;
        this.Behavior_name = behavior.Behavior_name;
    }
}
