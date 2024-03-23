using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float shootSpeed;
    Vector2 direction;
    [SerializeField] Transform directionTransform, ballTransform;
    bool shoot;
    [SerializeField] bool football;

    [SerializeField] GameObject explanationText;
    int atis = 0;

    void FixedUpdate()
    {
        DirectionCalculate();
        transform.Rotate(0, 0, speed);

        if(shoot)
        {
            shoot = false;
            GetComponent<Rigidbody2D>().AddForce(direction*shootSpeed, ForceMode2D.Impulse);
            directionTransform.gameObject.SetActive(false);
            explanationText.gameObject.SetActive(false);
            if (football) return;
            GetComponent<Rigidbody2D>().gravityScale = 1;


        }
    }

    private void DirectionCalculate()
    {
        direction = directionTransform.position - transform.position;
        //Debug.Log(distance);
    }

    private void Update()
    {
        if(Input.GetKeyDown("space") && atis ==0)
        {
            shoot = true;
            atis++;
        }
        if (Input.GetKeyUp("space"))
        {
            shoot = false;
        }
    }
}
