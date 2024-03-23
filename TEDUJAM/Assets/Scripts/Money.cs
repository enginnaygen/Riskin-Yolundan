using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static Money instance;
    [field: SerializeField] public int Moneyy { get; set; }
    [SerializeField] public Image moneyImage;
    [SerializeField] QuestionController questionController;


    private void Awake()
    {
        //Singelton();
    }
    private void Start()
    {
        moneyImage.fillAmount = Moneyy/10f;

    }

    private void Update()
    {
        //moneyImage.sprite = FindObjectOfType<QuestionController>().Sprites[0];
    }


    public void SetMoney(int call) //1 ise
    {


        if (call ==1)
        {
            Moneyy++;
            moneyImage.fillAmount += 0.1f;


        }
        else if(call==2)
        {
            Moneyy--;
            moneyImage.fillAmount -= 0.1f;

        }
    }

    void Singelton()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*public void DecreaseHealth()
    {
        money--;
    }*/
}
