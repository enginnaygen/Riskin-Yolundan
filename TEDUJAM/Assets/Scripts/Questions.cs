using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Question/New Question")]

public class Questions : ScriptableObject
{
    [field: TextArea(2, 6)]
    [field: SerializeField] public string Question { get; set; }
    [field: SerializeField] public Sprite stateImage;
    [SerializeField] string gameName;
    [SerializeField] bool noAnswerGoMiniGame, yesAnswerGoMiniGame;
    [SerializeField] AudioClip battleSound, soundtrack, townSound, gameBackground;


    //[SerializeField] Health healthh;
    //[SerializeField] Mercy mercyy;
    //[SerializeField] Money moneyy;

    [SerializeField] int healthEvet,healthHayir; //bu durumun olup olamamsý olacak
    [SerializeField] int mercyEvet,mercyHayir;
    [SerializeField] int moneyEvet,moneyHayir;


    //private void Awake()
    //{
    //    healthh = FindObjectOfType<Health>();
    //    moneyy = FindObjectOfType<Money>();
    //    mercyy = FindObjectOfType<Mercy>();
    //}
    public void StateUpdate(bool Yes, Money moneyy, Mercy mercyy, Health healthh)
    {
        if (Yes) // evet ise burasi
        {
            if (yesAnswerGoMiniGame)
            {
                if(gameBackground != null)
                {
                    AudioSource music;
                    music = FindObjectOfType<AudioSource>();
                    music.clip = gameBackground;
                    music.Play();
                }
                GoMiniGame();
                return;
            }
            moneyy.SetMoney(moneyEvet); 
            mercyy.SetMercy(mercyEvet);
            healthh.SetHealth(healthEvet);

           
        }
        else if(!Yes) //hayirsa burasi
        {
            if (noAnswerGoMiniGame)
            {
                if(battleSound != null)
                {
                    AudioSource music;
                    music = FindObjectOfType<AudioSource>();
                    music.clip  = battleSound;
                    music.Play();

                }
                
                GoMiniGame();
                Time.timeScale = 0;
                return;
            }
            moneyy.SetMoney(moneyHayir); 
            mercyy.SetMercy(mercyHayir);
            healthh.SetHealth(healthHayir);

           
        }

        
       
        //FindObjectOfType<Mercy>().mercy += mercyy;
        //FindObjectOfType<Health>().health += healthh;
        //FindObjectOfType<Money>().money += moneyy;
    }

    protected void GoMiniGame()
    {
        SceneManager.LoadScene(gameName,LoadSceneMode.Additive);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(oyunAdi));


    }

    //Button yesButton, noButton;

   

}
