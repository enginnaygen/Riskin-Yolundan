using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mercy : MonoBehaviour
{
    [field: SerializeField] public int Mercyy { get;  set; }
    [SerializeField] public Image mercyImage;
    [SerializeField] QuestionController questionController;

    private void Start()
    {
        mercyImage.fillAmount = Mercyy/10f;
    }
    public void SetMercy(int call) //1 ise
    {
        //questionController = FindObjectOfType<QuestionController>();

        if (call == 1)
        {
            Mercyy++;
            mercyImage.fillAmount += 0.1f;


        }
        else if (call == 2)
        {
            Mercyy--;
            mercyImage.fillAmount -= 0.1f;

        }
    }

    /*public void DecreaseHealth()
    {
        mercy--;
    }*/
}
