using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Environment : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI explanationText;
    [SerializeField] GameObject countinueButton;
    [SerializeField] bool football;
    [SerializeField] string explanationTextWriting;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            collision.gameObject.SetActive(false);
            explanationText.gameObject.SetActive(true);
            countinueButton.SetActive(true);
            if (football)
            {
                explanationText.text = "";
                explanationTextWriting = "Top yolda yürüyen bir mafyaya çartptý. 15 kiþiden dayak yedin.";
                StartCoroutine(TypeWrite());
                //explanationText.text = "Top yolda yürüyen bir mafyaya çartptý. 15 kiþiden dayak yedin.";

            }
            else if(!football)
            {
                explanationText.text = "";
                //explanationText.text = "Top cama çarpýp patladý. Çocuklar çok sinirlenip seni dövdüler.";
                explanationTextWriting = "Top cama çarpýp patladý. Çocuklar çok sinirlenip seni dövdüler.";
                StartCoroutine(TypeWrite());


            }
            FindObjectOfType<Health>().Healthh--;
            FindObjectOfType<Health>().healthImage.fillAmount-=0.1f;


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
