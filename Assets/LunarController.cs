using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LunarController : MonoBehaviour {



    private Rigidbody rigidBody;
    public GameObject shipFlame;
    public GameObject shipLeftFlame;
    public GameObject shipRightFlame;
    public AudioClip audio;
    public AudioSource audioSource;
    int side =0 ; // 1 left 2 right
    Vector3 m_EulerAngleVelocity;

    public float maxFuel = 100;
    public float currentFuel = 100;


    public Image fuelBar;
    public TextMeshProUGUI fuelText;

    public Image speedBar;
    public TextMeshProUGUI speedText;
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        shipFlame.SetActive(false);
        shipLeftFlame.SetActive(false);
        shipRightFlame.SetActive(false);
        audioSource.clip = audio;
        
    }
	void Update () {
        float speed = rigidBody.velocity.magnitude;
        Debug.Log((int)(speed / 25));
        speedBar.fillAmount = speed / 25;
        speedText.text = ((int)speed).ToString();
        Debug.Log(rigidBody.velocity.magnitude);
        Debug.Log(gameObject.transform.eulerAngles.z);
        UpdateUI();
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("up"))
        {
            Debug.Log("Fire açıldı");
            shipFlame.SetActive(true);
            audioSource.Play();

        }
        if (Input.GetAxis("Vertical") > 0.01f)
        {
            if (currentFuel > 0)
            {
                rigidBody.AddForce(transform.up * -6.0f);
                currentFuel -= 0.25f;
            }
        }
        if (Input.GetKey("right"))
        {

            if (gameObject.transform.eulerAngles.z > 90 && gameObject.transform.eulerAngles.z < 270 || side == 2)
            {
                if (currentFuel > 0)
                {
                    m_EulerAngleVelocity = new Vector3(0, 0, 50);
                    Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                    rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
                    shipRightFlame.SetActive(true);
                    side = 1;
                    currentFuel -= 0.125f;
                }
            }
            //audioSource.Play();
        }
        if (Input.GetKey("left"))
        {
            if (gameObject.transform.eulerAngles.z > 90 && gameObject.transform.eulerAngles.z < 270 ||side == 1)
            {
                if (currentFuel > 0)
                {
                    m_EulerAngleVelocity = new Vector3(0, 0, -50);
                    Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                    rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
                    shipLeftFlame.SetActive(true);
                    side = 2;
                    currentFuel -= 0.125f;
                }
            }

            //audioSource.Play();
        }

        if (Input.GetKeyUp("up"))
        {
            Debug.Log("Fire kapatıldı");
            shipFlame.SetActive(false);
            audioSource.Stop();
        }
        if (Input.GetKeyUp("right"))
        {
            Debug.Log("Fire kapatıldı");
            shipRightFlame.SetActive(false);
            audioSource.Stop();
        }
        if (Input.GetKeyUp("left"))
        {
            Debug.Log("Fire kapatıldı");
            shipLeftFlame.SetActive(false);
            audioSource.Stop();
        }
    }
    public void UpdateUI()
    {
        fuelBar.fillAmount = currentFuel / maxFuel;
        float fuelRate = ((currentFuel / maxFuel) * 100);
        fuelText.text = ((int)fuelRate).ToString();
    }
}
