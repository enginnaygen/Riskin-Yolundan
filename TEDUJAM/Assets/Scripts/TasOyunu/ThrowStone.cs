using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStone : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] float maxTime;
    float Timee;
    [SerializeField] GameObject stone;
    //[SerializeField] float stoneSpeed;



    private void Update()
    {
        Timee += Time.deltaTime;

        if(Timee > maxTime)
        {
            GameObject stonee;
            Timee = 0;
            stonee = Instantiate(stone,  transform.position,Quaternion.identity);
            stonee.GetComponent<Rigidbody2D>().velocity = direction * Random.Range(2f,4f);
            maxTime = Random.Range(2.5f, 5f);
        }
        
    }

    public Vector2 GetDirection()
    {
        return direction;
    }
}
