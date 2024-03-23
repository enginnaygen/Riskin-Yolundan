using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI explanationText;
    [SerializeField] GameObject continueButton;
    string explanationTexttWriting;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            explanationText.text = "";
            collision.gameObject.SetActive(false);
            explanationText.gameObject.SetActive(true);
            explanationTexttWriting = "Çocuklar atýþýna bayýldý, çok mutlu oldular.";
            StartCoroutine(TypeWrite());
            FindObjectOfType<Mercy>().Mercyy++;
            FindObjectOfType<Mercy>().mercyImage.fillAmount += 0.1f;
            continueButton.SetActive(true);
            //PlayerPrefs.SetInt("KalanYer", 9);
        }
        
    }

    IEnumerator TypeWrite()
    {
        foreach (char i in explanationTexttWriting)
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
