using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class QuestionController : MonoBehaviour
{
    //Button yesButton, noButton;

    [SerializeField] List<Questions> questions = new List<Questions>();
    [SerializeField] Questions currentQuestion;

    //[SerializeField] public List<Sprite> Sprites = new List<Sprite>();
    [SerializeField] Image mainImage;

    [SerializeField] Health healthh;
    [SerializeField] Mercy mercyy;
    [SerializeField] Money moneyy;

    [SerializeField] int questionNumber = 0;

    [SerializeField] float delay = 0.1f;

    [SerializeField] TextMeshProUGUI questionText, gameOverText;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Sprite deathPanel, crualPanel, poorPanel, goodEndingPanel;
    [SerializeField] AudioClip continuee, goodEnding;


    private void Awake()
    {
        healthh = FindObjectOfType<Health>();
        mercyy = FindObjectOfType<Mercy>();
        moneyy = FindObjectOfType<Money>();

        //moneyy.moneyImage.sprite = Sprites[0];
        //healthh.healthImage.sprite = Sprites[1];
        //mercyy.mercyImage.sprite = Sprites[2];

    }
    private void Start()
    {
        //if(PlayerPrefs.HasKey("KalanYer"))
        //{
        //    soru = PlayerPrefs.GetInt("KalanYer");
        //    YaziDondur(questions[soru].Question);

        //}
        //YaziDondur(questions[0].Question);
        questionText.text = "";
        StartCoroutine(TypeWrite(questions[0].Question));


    }

    private void Update()
    {
        if (healthh.Healthh <= 0)
        {
            gameOverText.text = "Bu riskli yolun sonuna gelemedim. Öldüm.";
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponent<Image>().sprite = deathPanel;
        }
        if (moneyy.Moneyy <= 0)
        {
            gameOverText.text = "Bu riskli yolun sonuna gelemedim. Tüm param bitti. Artýk bu þehir yeni bir dilenci kazandý.";
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponent<Image>().sprite = poorPanel;


        }
        if (mercyy.Mercyy <= 0)
        {
            gameOverText.text = "Bu riskli yolun sonuna gelemedim. Gaddar bir insana dönüþtüm ve insanlýðýmý yitirdim.";
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponent<Image>().sprite = crualPanel;

        }
        if (healthh.Healthh >= 10)
        {
            gameOverText.text = "Bu çöplüðün içinde çok saðlýklý duruyordum. Bir eþkiyanýn dikkatini çekti bu durum. Üzerime kurþun yaðdýrdý ve öldüm.";
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponent<Image>().sprite = deathPanel;
        }
        if (moneyy.Moneyy >= 10)
        {
            gameOverText.text = "Çok zengindim. Bir hýrsýz býçaðý taktý ve tüm paramý aldý. Öldürüldüm";
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponent<Image>().sprite = deathPanel;


        }
        if (mercyy.Mercyy >= 10)
        {
            gameOverText.text = "Herkese yardýmcý olmaya çalýþmaktan yýllar geçti. Bir gün bir kadýn önümde düþtü ona yardýmcý oldum ve evine kadar býraktým. Fakat bana pusu kurmuþlar. Beni öldürüp tüm paramý çaldýlar. Bu kadar saf olmamalýydým.";
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponent<Image>().sprite = deathPanel;

        }
    }
    public void ConditionCall(bool condition)
    {
        
        //GetComponent<AudioSource>().PlayOneShot(gec);
        if(questionNumber >=45)
        {
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponent<Image>().sprite = goodEndingPanel;
            gameOverText.text = "Tüm elimdekileri ve kendimi riske atarak kardeþimi buldum, artýk bu dünyada kimse benden daha mutlu olamaz.";
            AudioSource music;
            music = FindObjectOfType<AudioSource>();
            music.clip = goodEnding;
            music.Play();
            return;
        }
        StopAllCoroutines();       
        questionNumber++;
        questionText.text = "";
        currentQuestion.StateUpdate(condition,moneyy,mercyy,healthh);
        currentQuestion = questions[questionNumber]; //Random.Range(0, questions.Count - 1)
        //mainImage.sprite = Images[soru].s
        mainImage.sprite = currentQuestion.stateImage;
        //centerImageAnim.Play();
        //YaziDondur(currentQuestion.Question);
        StartCoroutine(TypeWrite(currentQuestion.Question));
            
    }


    public string PutWriting(string question)
    {
        questionText.text = question;
        return questionText.text;
    }

    IEnumerator TypeWrite(string question)
    {
        foreach(char i in question)
        {
            questionText.text += i.ToString();

            if(i.ToString() == ".")
            {
                yield return new WaitForSeconds(0.15f);
            }
            else
            {
                yield return new WaitForSeconds(delay);

            }
        }
    }

    public void RePlay()
    {
        SceneManager.LoadScene("MainGame");
    }

    

}
