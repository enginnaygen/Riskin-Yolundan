using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI text;
    bool startGame =false;
    private void Start()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if(Time.timeScale==0 && !startGame && Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            Time.timeScale = 1;
            text.gameObject.SetActive(false);
            startGame = true;
        }
        
        float verticallMove = Input.GetAxisRaw("Vertical");
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector2(horizontalMove, verticallMove).normalized * Time.deltaTime * speed);

        if(transform.position.x>2.5f)
        {
            transform.position = new Vector2(2.5f, transform.position.y);
        }
        if (transform.position.x < -2.5f)
        {
            transform.position = new Vector2(-2.5f, transform.position.y);
        }
        if (transform.position.y > 2.4f)
        {
            transform.position = new Vector2(transform.position.x, 2.4f);
        }
        if (transform.position.y < -2.4f)
        {
            transform.position = new Vector2(transform.position.x, -2.4f);
        }
    }

   
}
