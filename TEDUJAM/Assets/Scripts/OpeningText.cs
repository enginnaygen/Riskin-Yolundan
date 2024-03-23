using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpeningText : MonoBehaviour
{
    [SerializeField] string openingText, openingText1;
    [SerializeField] TextMeshProUGUI explanationText;
    [SerializeField] GameObject Button;
    private void Start()
    {
        StartCoroutine(TypeWrite());
    }
    IEnumerator TypeWrite()
    {
        yield return new WaitForSeconds(0.5f);

        foreach (char i in openingText)
        {
            explanationText.text += i.ToString();

            if (i.ToString() == "." || i.ToString() == "?")
            {
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);

            }
        }
        yield return new WaitForSeconds(2f);
        explanationText.text = "";

        yield return new WaitForSeconds(1f);

        foreach (char i in openingText1)
        {
            explanationText.text += i.ToString();

            if (i.ToString() == "." || i.ToString() == "?")
            {
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);

            }
        }

        yield return new WaitForSeconds(2f);
        explanationText.text = "";
        yield return new WaitForSeconds(1f);




        explanationText.text = "Riskin Yolundan";
        explanationText.fontSize =250;
        explanationText.color = Color.red;

        Button.SetActive(true);
    }
}
