using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [field:SerializeField]public int Healthh { get;  set; }
    [SerializeField] public Image healthImage;
    [SerializeField] QuestionController questionController;


    private void Start()
    {

        healthImage.fillAmount = Healthh/10f;
    }
    public void SetHealth(int call) //1 ise
    {
        //questionController = FindObjectOfType<QuestionController>();

        if (call == 1)
        {
            Healthh++;
            healthImage.fillAmount += 0.1f;

        }
        else if (call == 2)
        {
            Healthh--;
            healthImage.fillAmount -= 0.1f;

        }
    }

    /*public void DecreaseHealth()
    {
        health--;
    }*/
}
