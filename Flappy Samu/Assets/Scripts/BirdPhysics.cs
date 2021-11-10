using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdPhysics : MonoBehaviour
{
    private void flap()
    {
        Rigidbody2D birdBody = GetComponent<Rigidbody2D>();
        birdBody.AddForce(Vector2.up * force);
        wing_source.Play(); //faig un play al sorrol de les ales
    }
    public float speed = 2;
    private Vector3 respawnPoint;
    public float force = 200;
    [SerializeField]
    Text CountText;   //declaro el text que contara les monedes
    int count;
    [SerializeField]
    Text CounText; //declaro el text que contara les barreres superades
    int count1;
    [SerializeField]
    public AudioSource wing_source; //declaro audio de volar de l'ocell
    [SerializeField]
    public AudioSource point_source;

    [SerializeField] //declaro el "timer"
    Text timertext;
    double t = 0;
    public float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
       
        count = 0;
        CountText.text = "Monedes: " + count.ToString();
        
        Rigidbody2D birdBody = GetComponent<Rigidbody2D>();
        birdBody.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))   //fisiques de l'ocell
        {
            flap();
        }
        timer += Time.deltaTime;  //faig el timer, que cada cop sumi
        t = System.Math.Round(timer, 1);
        timertext.text = t.ToString();

    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))  //si es passa una barrera que conti
        {
            count1++;
            CounText.text = "Barreres: " + count1.ToString();
        }
       if  (collision.gameObject.CompareTag("CoinBird")) //si toca un coin que el sumi
        {
            point_source.Play(); //soroll del coin
            collision.gameObject.SetActive(false);
            count++;
            CountText.text = "Monedes: " + count.ToString();
            
        }
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
        else if (collision.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // Can also use SceneManager.LoadScene(1); to load a specific scene
            respawnPoint = transform.position;
        }
        else if (collision.tag == "PreviousLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawnPoint = transform.position;
        }
        
    }
}