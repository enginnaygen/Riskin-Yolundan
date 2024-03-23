using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //Vector2 moveRestiriction;
    [SerializeField] float speedX, speedY;
    [SerializeField] bool horizontal, vertical;

    [SerializeField] public TextMeshProUGUI endGameText;
    [SerializeField] public Button button;



    private void Update()
    {
        transform.Translate(new Vector3(speedX,speedY) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Corner")
        {
            if (horizontal)
            {
                speedX *= -1;
            }
            if (vertical)
            {
                speedY *= -1;
            }
        }

    }
   
}
