using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class PlayerCigController : MonoBehaviour
{
    public GameObject UIDeadGameObject;
    public RectTransform UIDeadRect;

    public float Health;
    public float MaxHealth = 100;

    public int startAge;
    private int currentAge;
    public int MaxAge = 100;
    public int DelayAmountAge = 1; // Second count
    protected float Timer;


    [SerializeField]
    private int cigCount = 0;
    [SerializeField]
    private int vegCount = 0;

    public bool isDead = false;
    public bool isDeadUI = false;

    public float healthDecresedSpeed = 0.01f;

    public HealthBar healthbar;
    public Text AgeText;

    public GameObject CigParticle;
    public GameObject VegParticle;

    public AudioSource soundEffect;
    public GameObject Hitbox;

    public Text AgeUIdead;
    public Text VegCountUIdead;
    public Text CigCountUIdead;
    public GameObject healthyLungsImage;
    public GameObject ToxicLungsImage;

    public GameObject HealthyLungIngame;
    public GameObject ToxicLungInGame;

    public bool isStart;

    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        Health = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
        currentAge = 16;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Health : " + Health + " Age :" + currentAge + " cigCount : " + cigCount + " VegCount : " + vegCount);
        Debug.Log(isStart);
        healthbar.SetHealth(Health);
        AgeText.text = currentAge.ToString();
        AgeUIdead.text = currentAge.ToString();
        VegCountUIdead.text = vegCount.ToString();
        CigCountUIdead.text = cigCount.ToString();

        if (isStart)
        {
         


            if (Health <= 5)
            {
                isDead = true;
                Health = 0;

            }

            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }

            Timer += Time.deltaTime;

            if (Timer >= DelayAmountAge)
            {
                Timer = 0f;
                currentAge++;
                this.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                // Health -= 0.5f;// For every DelayAmount or "second" it will add one to the GoldValue

            }

            if (cigCount > vegCount)
            {
                ToxicLungInGame.SetActive(true);
            }

            if (vegCount > cigCount)
            {
                ToxicLungInGame.SetActive(false);
            }


            //Dead UI
            if (vegCount >= cigCount)
            {
                healthyLungsImage.SetActive(true);
                ToxicLungsImage.SetActive(false);
            }
            else
            {
                ToxicLungsImage.SetActive(true);
                healthyLungsImage.SetActive(false);
            }

            if (isDead)
            {
                Hitbox.SetActive(true);



                // UIDeadGameObject.SetActive(true);

                //    UIDeadRect.transform.position = new Vector3(0, Mathf.Lerp(UIDeadRect.position.y, 0, 100 * Time.deltaTime), 0); //Move Up

            }

            Health = Mathf.Lerp(Health, 0f, healthDecresedSpeed * Time.deltaTime);

            // UIDeadRect.transform.position = new Vector3(0, 0, 0); //Move Up
        }


    }

    private void OnTriggerEnter(Collider other)
    {
     


        if(other.gameObject.tag == "Cig")
        {
            soundEffect.Play();
            Instantiate(CigParticle, this.transform.position, this.transform.rotation);
            Instantiate(CigParticle, this.transform.position, this.transform.rotation);
            Instantiate(CigParticle, this.transform.position, this.transform.rotation);
            cigCount++;
            Health -= 10;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Veg")
        {
            soundEffect.Play();
            Instantiate(VegParticle,this.transform.position,this.transform.rotation);
            vegCount++;
            Health += 5;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "StartTriger")
        {
            soundEffect.Play();
            isStart = true;
          Destroy(other.gameObject);
        }




    }

    public void RestartScene()
    {
        SceneManager.LoadScene("Battle Arena Main 1");
        Time.timeScale= 1.0f;
        //UIDeadGameObject.SetActive(false);
    }
    public void ExistGame()
    {
        Application.Quit(); 
        Debug.Log("Exited");
    }



}
