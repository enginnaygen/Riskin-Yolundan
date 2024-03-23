using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Stone : MonoBehaviour
{

    int collisionn;

    static int gameLimit;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<Enemy>().endGameText.gameObject.SetActive(true);
            FindObjectOfType<Enemy>().endGameText.text = "Serseriler seni taþladý";
            FindObjectOfType<Enemy>().button.gameObject.SetActive(true);
            FindObjectOfType<Health>().Healthh--;
            FindObjectOfType<Health>().healthImage.fillAmount -= 0.1f;
            Destroy(gameObject);
            Time.timeScale = 0;

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Area")
        {
            collisionn++;

            if (collisionn == 2)
            {
                gameLimit++;
                Destroy(gameObject);

            }

        }

        if(gameLimit>=20)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            FindObjectOfType<Enemy>().endGameText.gameObject.SetActive(true);
            FindObjectOfType<Enemy>().endGameText.text = "Serserilerden kaçmayý baþardýn";
            FindObjectOfType<Enemy>().button.gameObject.SetActive(true);
        }
       
    }

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            Destroy(gameObject);
        }
    }

}
