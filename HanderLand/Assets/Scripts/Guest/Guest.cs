using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
    public List<Behavior> behaviors = new List<Behavior>();
    public int total = 0;
    public Behavior behavior;
    public List<Node> Path;
    PathFinding pf;
    public GameObject gm;
    public bool IsFindPath, IsRiding;

    public float speed;
    public int direction;
    public string Guest_Name, Guest_Think, Guest_Behavior;
    public float Gauge_Happy_Max, Gauge_Happy, Gauge_Energy_Max, Gauge_Energy, Gauge_Hungry_Max, Gauge_Hungry, Gauge_Thirst_Max, Gauge_Thirst, Gauge_Sick_Max, Gauge_Sick, Gauge_Toilet_Max, Gauge_Toilet, Gauge_Intensity, Gauge_Tolerance;
    public int Record_Ride, Record_Food, Record_Drink, Record_Souvenir;
    public float TimeRecord, Money_InHand, Money_Spent, Money_AdmissionFees, Money_Ride, Money_FoodNDrink, Money_Souvenir;

    void Start()
    {
        Physics.IgnoreLayerCollision(9, 9);
        gm = GameObject.Find("GameManager");
        pf = this.gameObject.GetComponent<PathFinding>();
        this.transform.GetComponent<Grids>().CreateGrid();
        //decide_target();
        //Next_Behavior();
    }

    void Update()
    {
        decide_Behavior();
    }

    public Behavior Next_Behavior()
    {
        int weight = 0;
        int selectNum = 0;
        total = 0;
        for (int i = 0; i < behaviors.Count; i++)
        {
            total += behaviors[i].weight;
        }

        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));

        for(int i = 0; i < behaviors.Count; i++)
        {
            weight += behaviors[i].weight;
            if(selectNum <= weight)
            {
                behavior = new Behavior(behaviors[i]);
                return behavior;
            }
        }

        return null;
    }

    void decide_Behavior()
    {
        switch (behavior.Behavior_name)
        {
            case "Move":
                Move();
                Guest_Behavior = "Moving";
                break;

            case "Navigater":
                Navigater();
                Guest_Behavior = "Moving";
                break;

            case "Leave":
                Leave();
                Guest_Behavior = "Leaving the park";
                break;

            case "Stay":
                Stay();
                Guest_Behavior = "Waiting";
                break;

            case "Board_Ride":
                Board_Ride();
                Guest_Behavior = "Riding ride";
                break;

            case "GoToSeat":
                GoToSeat();
                Guest_Behavior = "Walking";
                break;

            case "GoToExit":
                GoToExit();
                Guest_Behavior = "Moving to seat";
                break;

            case "Use_Shop":
                Use_Shop();
                Guest_Behavior = "Using a Shop";
                break;

            case "SightSeeing_Ride":
                SightSeeing_Ride();
                Guest_Behavior = "Sigh Seeing a Ride";
                break;

            case "TakePicture_Ride":
                TakePicture_Ride();
                Guest_Behavior = "Taking a picture of the ride";
                break;

            case "ThrowUp":
                ThrowUp();
                Guest_Behavior = "Throwing Up";
                break;
        }
    }

    void decide_target()
    {
        int i = Random.Range(0, gm.transform.GetComponent<GameManager>().Target.Count);
        IsFindPath = true;
        this.transform.GetComponent<PathFinding>().TargetNode_ = gm.transform.GetComponent<GameManager>().Target[i];
        pf.pathfinding(pf.posStart(this.gameObject), pf.posTarget(pf.TargetNode_));

        Gage_Update();
    }

    void Move()
    {
        if (this.transform.GetComponent<PathFinding>().TargetNode_ == null)
        {
            decide_target();
        }
        else if (this.transform.GetComponent<PathFinding>().TargetNode_ != null)
        {
            if (Path.Count != 0)
            {
                IsFindPath = true;

                transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(Path[0].NodePosition.x, this.transform.position.y, Path[0].NodePosition.z), Time.deltaTime * speed);
                if (this.transform.position == new Vector3(Path[0].NodePosition.x, this.transform.position.y, Path[0].NodePosition.z))
                {
                    Path.Remove(Path[0]);
                }
            }
            else if (Path.Count == 0)
            {
                IsFindPath = false;

                if (IsFindPath == false && this.transform.position != new Vector3(pf.TargetNode_.transform.position.x, this.transform.position.y, pf.TargetNode_.transform.position.z))
                {
                    pf.pathfinding(pf.posStart(this.gameObject), pf.posTarget(pf.TargetNode_));
                    pf.CloseNode.Add(pf.CurrentNode.ParentNode);

                    Gage_Update();
                }
                if (IsFindPath == false && this.transform.position == new Vector3(pf.TargetNode_.transform.position.x, this.transform.position.y, pf.TargetNode_.transform.position.z))
                {
                    pf.TargetNode_ = null;
                    pf.DeleteParents();
                    decide_target();
                }
            }
        }
    }

    void Navigater()
    {
        if (this.transform.GetComponent<PathFinding>().TargetNode_ == null)
        {
            decide_target();
        }
        else if (this.transform.GetComponent<PathFinding>().TargetNode_ != null)
        {
            if (Path.Count != 0)
            {
                IsFindPath = true;

                transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(Path[0].NodePosition.x, this.transform.position.y, Path[0].NodePosition.z), Time.deltaTime * speed);
                if (this.transform.position == new Vector3(Path[0].NodePosition.x, this.transform.position.y, Path[0].NodePosition.z))
                {
                    Path.Remove(Path[0]);
                }
            }
            else if (Path.Count == 0)
            {
                IsFindPath = false;

                if (IsFindPath == false && this.transform.position != new Vector3(pf.TargetNode_.transform.position.x, this.transform.position.y, pf.TargetNode_.transform.position.z))
                {
                    pf.pathfinding(pf.posStart(this.gameObject), pf.posTarget(pf.TargetNode_));
                    pf.CloseNode.Add(pf.CurrentNode.ParentNode);

                    Gage_Update();
                }
                if (IsFindPath == false && this.transform.position == new Vector3(pf.TargetNode_.transform.position.x, this.transform.position.y, pf.TargetNode_.transform.position.z))
                {
                    pf.TargetNode_ = null;
                    pf.DeleteParents();
                    decide_target();
                }
            }
        }
    }

    void Leave()
    {
        Debug.Log("공원 떠나는 중");
    }

    void Stay()
    {
        Debug.Log("대기열에서 대기 중");
    }

    void Board_Ride()
    {
        Debug.Log("놀이기구 타는 중");
    }

    void GoToSeat()
    {
        Debug.Log("좌석으로 가는 중");
    }

    void GoToExit()
    {
        Debug.Log("출구로 가는 중");
    }

    void Use_Shop()
    {
        Debug.Log("상점 이용 중");
    }

    void SightSeeing_Ride()
    {
        Debug.Log("놀이기구 구경 중");
    }

    void TakePicture_Ride()
    {
        Debug.Log("놀이기구 사진 찍는 중");
    }

    void ThrowUp()
    {
        Debug.Log("토하는 중");
    }

    void Gage_Update()
    {
        Gauge_Happy -= 1;
        Gauge_Energy -= 1;
        Gauge_Hungry += 1;
        Gauge_Thirst += 1;
        Gauge_Toilet += 1;

        if(Gauge_Hungry < 30) { Gauge_Energy += 2; }
        if(Gauge_Hungry > 75) { Gauge_Happy -= 1; }

        if (Gauge_Thirst < 30) { Gauge_Energy += 2; }
        if (Gauge_Thirst > 75) { Gauge_Happy -= 1; }

        if (Gauge_Toilet > 75) { Gauge_Happy -= 1; }

        if (IsRiding) { Gauge_Sick += 1; }
    }
}
