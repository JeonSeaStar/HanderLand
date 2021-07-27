using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Select_Popup : MonoBehaviour
{
    public GameObject GM;
    public GameObject RP;
    public GameObject Select_Camera_Btn;
    public GameObject Select_Camera;
    public GameObject Select_State_Btn;
    public GameObject Select_State;
    public GameObject Select_RideRecord_Btn;
    public GameObject Select_RideRecord;
    public GameObject Select_MoneyRecord_Btn;
    public GameObject Select_MoneyRecord;
    public GameObject Select_ThinkRecord_Btn;
    public GameObject Select_ThinkRecord;
    public GameObject Select_Belonging_Btn;
    public GameObject Select_Belonging;
    public GameObject Close_Btn;

    Vector3 StartPos;
    //Camera
    public TextMeshProUGUI Guest_Name, Think, Behaivior;
    //State
    public Slider Gauge_Happy, Gauge_Energy, Gauge_Hungry, Gauge_Thirst, Gauge_Sick, Gauge_Toilet;
    public Gradient Gradient_Happy, Gradient_Energy, Gradient_Hungry, Gradient_Thirst, Gradient_Sick, Gradient_Toilet;
    public RawImage Fill_Happy, Fill_Energy, Fill_Hungry, Fill_Thirst, Fill_Sick, Fill_Toilet;
    public TextMeshProUGUI Intensity, Tolerance;
    //Rid Record
    public TextMeshProUGUI Record_Ride, Record_Food, Record_Drink, Record_Souvenir, Record_Time;
    //Money Record
    public TextMeshProUGUI InHandMoney, Spent_Money, Spent_AdmissionFees, Spent_Ride, Spent_Food, Spent_Souvenir;

    void Start()
    {
        StartPos = transform.position;
        GM = GameObject.Find("GameManager").gameObject;


    }

    void Update()
    {
        State();
    }

    public void Select_Camera_Button()
    {
        Select_Camera_Btn.gameObject.SetActive(false);
        Select_Camera.gameObject.SetActive(true);

        Select_State_Btn.gameObject.SetActive(true);
        Select_RideRecord_Btn.gameObject.SetActive(true);
        Select_MoneyRecord_Btn.gameObject.SetActive(true);
        Select_ThinkRecord_Btn.gameObject.SetActive(true);
        Select_Belonging_Btn.gameObject.SetActive(true);

        Select_State.gameObject.SetActive(false);
        Select_RideRecord.gameObject.SetActive(false);
        Select_MoneyRecord.gameObject.SetActive(false);
        Select_ThinkRecord.gameObject.SetActive(false);
        Select_Belonging.gameObject.SetActive(false);
    }

    public void Select_State_Button()
    {
        Select_State_Btn.gameObject.SetActive(false);
        Select_State.gameObject.SetActive(true);

        Select_Camera_Btn.gameObject.SetActive(true);
        Select_RideRecord_Btn.gameObject.SetActive(true);
        Select_MoneyRecord_Btn.gameObject.SetActive(true);
        Select_ThinkRecord_Btn.gameObject.SetActive(true);
        Select_Belonging_Btn.gameObject.SetActive(true);

        Select_Camera.gameObject.SetActive(false);
        Select_RideRecord.gameObject.SetActive(false);
        Select_MoneyRecord.gameObject.SetActive(false);
        Select_ThinkRecord.gameObject.SetActive(false);
        Select_Belonging.gameObject.SetActive(false);
    }

    public void Select_RideRecord_Button()
    {
        Select_RideRecord_Btn.gameObject.SetActive(false);
        Select_RideRecord.gameObject.SetActive(true);

        Select_Camera_Btn.gameObject.SetActive(true);
        Select_State_Btn.gameObject.SetActive(true);
        Select_MoneyRecord_Btn.gameObject.SetActive(true);
        Select_ThinkRecord_Btn.gameObject.SetActive(true);
        Select_Belonging_Btn.gameObject.SetActive(true);

        Select_Camera.gameObject.SetActive(false);
        Select_State.gameObject.SetActive(false);
        Select_MoneyRecord.gameObject.SetActive(false);
        Select_ThinkRecord.gameObject.SetActive(false);
        Select_Belonging.gameObject.SetActive(false);
    }

    public void Select_MoneyRecord_Button()
    {
        Select_MoneyRecord_Btn.gameObject.SetActive(false);
        Select_MoneyRecord.gameObject.SetActive(true);

        Select_Camera_Btn.gameObject.SetActive(true);
        Select_State_Btn.gameObject.SetActive(true);
        Select_RideRecord_Btn.gameObject.SetActive(true);
        Select_ThinkRecord_Btn.gameObject.SetActive(true);
        Select_Belonging_Btn.gameObject.SetActive(true);

        Select_Camera.gameObject.SetActive(false);
        Select_State.gameObject.SetActive(false);
        Select_RideRecord.gameObject.SetActive(false);
        Select_ThinkRecord.gameObject.SetActive(false);
        Select_Belonging.gameObject.SetActive(false);
    }

    public void Select_ThinkRecord_Button()
    {
        Select_ThinkRecord_Btn.gameObject.SetActive(false);
        Select_ThinkRecord.gameObject.SetActive(true);

        Select_Camera_Btn.gameObject.SetActive(true);
        Select_State_Btn.gameObject.SetActive(true);
        Select_RideRecord_Btn.gameObject.SetActive(true);
        Select_MoneyRecord_Btn.gameObject.SetActive(true);
        Select_Belonging_Btn.gameObject.SetActive(true);

        Select_Camera.gameObject.SetActive(false);
        Select_State.gameObject.SetActive(false);
        Select_RideRecord.gameObject.SetActive(false);
        Select_MoneyRecord.gameObject.SetActive(false);
        Select_Belonging.gameObject.SetActive(false);
    }

    public void Select_Belonging_Button()
    {
        Select_Belonging_Btn.gameObject.SetActive(false);
        Select_Belonging.gameObject.SetActive(true);

        Select_Camera_Btn.gameObject.SetActive(true);
        Select_State_Btn.gameObject.SetActive(true);
        Select_RideRecord_Btn.gameObject.SetActive(true);
        Select_MoneyRecord_Btn.gameObject.SetActive(true);
        Select_ThinkRecord_Btn.gameObject.SetActive(true);

        Select_Camera.gameObject.SetActive(false);
        Select_State.gameObject.SetActive(false);
        Select_RideRecord.gameObject.SetActive(false);
        Select_MoneyRecord.gameObject.SetActive(false);
        Select_ThinkRecord.gameObject.SetActive(false);
    }

    public void Select_Popup_Close()
    {
        Select_Camera_Button();
        transform.position = StartPos;
        gameObject.SetActive(false);

        for(int i = 0; i < 6; i++)
        {
            if (GM.GetComponent<GameManager>().Guest_Select_Popup[i].activeSelf == false && GM.GetComponent<GameManager>().Guest_Select[i] == true)
            {
                GM.GetComponent<GameManager>().Guest_Select[i] = false;
                GM.GetComponent<GameManager>().Select_Guest[i] = null;

                break;
            }
        }
    }

    public void State()
    {
        for (int i = 0; i < 6; i++)
        {
            if (GM.GetComponent<GameManager>().Guest_Select_Popup[i] == this.gameObject)
            {
                for(int j = 0; j < 6; j++)
                {
                    if(i == j)
                    {
                        //Camera Scene
                        Guest_Name.text = GM.GetComponent<GameManager>().Select_Guest[i].gameObject.name;
                        Think.text = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Guest_Think;
                        Behaivior.text = "(" + GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Guest_Behavior + ")";

                        //State Scene
                        Gauge_Happy.maxValue = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Happy_Max;
                        Gauge_Happy.value = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Happy;
                        Fill_Happy.color = Gradient_Happy.Evaluate(Gauge_Happy.normalizedValue);

                        Gauge_Energy.maxValue = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Energy_Max;
                        Gauge_Energy.value = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Energy;
                        Fill_Energy.color = Gradient_Energy.Evaluate(Gauge_Energy.normalizedValue);

                        Gauge_Hungry.maxValue = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Hungry_Max;
                        Gauge_Hungry.value = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Hungry;
                        Fill_Hungry.color = Gradient_Hungry.Evaluate(Gauge_Hungry.normalizedValue);

                        Gauge_Thirst.maxValue = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Thirst_Max;
                        Gauge_Thirst.value = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Thirst;
                        Fill_Thirst.color = Gradient_Thirst.Evaluate(Gauge_Thirst.normalizedValue);

                        Gauge_Sick.maxValue = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Sick_Max;
                        Gauge_Sick.value = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Sick;
                        Fill_Sick.color = Gradient_Sick.Evaluate(Gauge_Sick.normalizedValue);

                        Gauge_Toilet.maxValue = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Toilet_Max;
                        Gauge_Toilet.value = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Toilet;
                        Fill_Toilet.color = Gradient_Toilet.Evaluate(Gauge_Toilet.normalizedValue);

                        Intensity.text = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Intensity.ToString();
                        Tolerance.text = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Gauge_Tolerance.ToString();

                        //RideRecord Scene
                        Record_Ride.text = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Record_Ride.ToString() + " times";
                        Record_Food.text = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Record_Food.ToString() + " times";
                        Record_Drink.text = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Record_Drink.ToString() + " times";
                        Record_Souvenir.text = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Record_Souvenir.ToString() + " times";
                        Record_Time.text = GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().TimeRecord.ToString();

                        //MoneyRecord Scene
                        InHandMoney.text = "$" + GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Money_InHand;
                        Spent_Money.text = "$" + GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Money_Spent;
                        Spent_AdmissionFees.text = "$" + GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Money_AdmissionFees;
                        Spent_Ride.text = "$" + GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Money_Ride;
                        Spent_Food.text = "$" + GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Money_FoodNDrink;
                        Spent_Souvenir.text = "$" + GM.GetComponent<GameManager>().Select_Guest[i].GetComponent<Guest>().Money_Souvenir;

                        break;
                    }
                }
            }
        }
    }

    public void Open_Rename_Popup()
    {
        if(RP.activeSelf == false)
        {
            RP.gameObject.SetActive(true);

            for (int i = 0; i < 6; i++)
            {
                if (GM.GetComponent<GameManager>().Guest_Select_Popup[i] == this.gameObject)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (i == j)
                        {
                            RP.gameObject.SetActive(true);
                            RP.GetComponent<Rename_Popup>().Rename_Guest = GM.GetComponent<GameManager>().Select_Guest[i];

                            break;
                        }
                    }
                }
            }
        }
    }

    public void PickUP_Guest()
    {
        //Áý°Ô·Î ¼Õ´Ô ÂóÀ½
    }
}
