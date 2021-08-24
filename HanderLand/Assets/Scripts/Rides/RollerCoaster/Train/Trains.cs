using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trains : MonoBehaviour
{
    public GameObject[] train;
    public int trainInt;
    public GameObject trainObject;
    public GameObject rc;
    public List<Point> path = new List<Point>();
    public List<Point> path_Roatation = new List<Point>();
    RollerCoaster r;
    public bool drive;
    public int[] target;
    public float speed;

    void Start()
    {
        r = rc.GetComponent<RollerCoaster>();
    }

    void Update()
    {
        Drive();
    }

    public void trainManager()
    {
        for (int i = 0; i < train.Length; i++)
        {
            Destroy(train[i]);
        }
        train = new GameObject[trainInt];
        target = new int[trainInt];
        for (int i = 0; i < train.Length; i++)
        {
            GameObject t = Instantiate(trainObject, new Vector3(0, 0, 0), Quaternion.identity);
            t.gameObject.name = "train[" + i + "]";
            t.transform.parent = transform;
            train[i] = t;
        }
    }

    public void UpdatePath()
    {
        path = new List<Point>();
        for (int i = 0; i < r.track.Count; i++)
        {
            for (int j = 0; j < r.track[i].Count; j++)
            {
                path.Add(r.track[i][j]);
            }
        }
    }

    void Drive()
    {
        if (drive == true)
        {
            for (int i = 0; i < train.Length; i++)
            {
                train[0].transform.position = Vector3.MoveTowards(train[0].transform.position, path[target[0]].position, Time.deltaTime * speed);

                if (i != 0)
                {
                    train[i].transform.position = (train[i].transform.position - train[i - 1].transform.position).normalized * 0.6f + train[i - 1].transform.position;
                    if (target[i - 1] - 1 >= 0)
                    {
                        target[i] = target[i - 1] - 1;
                    }
                }

                train[i].transform.eulerAngles = path[target[i]].rotation;

                if (train[i].transform.position == path[target[i]].position && target[i] < path.Count - 1)
                {
                    target[i]++;
                }

                if (path[target[i]].type == 1)
                {
                    speed -= 0.0038f;
                }
                else if (path[target[i]].type == 2 && speed < 50)
                {
                    speed += 0.005f;
                }
            }
        }
        else if(drive == false)
        {
            for (int i = 0; i < train.Length; i++)
            {
                if (i != 0)
                {
                    train[i].transform.position = (train[i].transform.position - train[i - 1].transform.position).normalized * 0.6f + train[i - 1].transform.position;
                    if (target[i - 1] - 1 >= 0)
                    {
                        target[i] = target[i - 1] - 1;
                    }
                }
            }
        }
    }
}
