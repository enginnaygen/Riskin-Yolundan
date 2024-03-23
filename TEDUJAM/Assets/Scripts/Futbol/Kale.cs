using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Kale : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI explanationText;
    [SerializeField] GameObject continueButton;
    string explanationTextWriting;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            explanationText.text = "";
            explanationText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
            continueButton.SetActive(true);
            explanationTextWriting = "Çok güzel gol attýn, çocuklar coþtu";
            StartCoroutine(TypeWrite());
        }
    }

    IEnumerator TypeWrite()
    {
        foreach (char i in explanationTextWriting)
        {
            explanationText.text += i.ToString();

            if (i.ToString() == ".")
            {
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                yield return new WaitForSeconds(0.05f);

            }
        }
    }


}
