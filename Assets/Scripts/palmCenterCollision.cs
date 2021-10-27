using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.Toast;
using System;

public class palmCenterCollision : MonoBehaviour
{
    const int CONTOUR = 150;

    [SerializeField]
    private Text azulColisionMano; // delete
    [SerializeField]
    private Text rojoColisionMano; // delete
    [SerializeField]
    private GameObject prefabBlueDiamond;

    public double maximum_response = 1000;
    public double minimum_response = 1000;
    public float currentTime = 0;
    TimeSpan time;

    public AudioSource audioSource_collision;
    public AudioClip music_collision;

    public int numberOfDiamondBlueCollisionsWithTheHand = 0;
    public int numberOfDiamondRedCollisionsWithTheHand = 0;

    private void Start()
    {
        audioSource_collision.clip = music_collision;
    }

    void Update()
    {
        time = TimeSpan.FromSeconds(currentTime);
        currentTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D diamond)
    {
        

        if (diamond.gameObject.CompareTag("blueDiamond") || diamond.gameObject.CompareTag("redDiamond")) {

            audioSource_collision.Play();

            double currentTimeMiliseconds = 0;

            currentTimeMiliseconds = time.TotalMilliseconds;

            if (currentTimeMiliseconds > maximum_response){
                maximum_response = currentTimeMiliseconds;
            }

            if (currentTimeMiliseconds < minimum_response)
            {
                minimum_response = currentTimeMiliseconds;
            }

            currentTime = 0;
        }

            if (diamond.gameObject.CompareTag("blueDiamond")) {
            numberOfDiamondBlueCollisionsWithTheHand++;
            //azulColisionMano.text = "___ : " + numberOfDiamondBlueCollisionsWithTheHand.ToString();

            int randomAddress = UnityEngine.Random.Range(0, 2); // 0: down  1: up
            float positionX = UnityEngine.Random.Range(CONTOUR, (Screen.width*0.5f) - CONTOUR);
            Vector3 positionblueDiamond;


            if (randomAddress != 1)
            {
                // cuadrante IV
                float positionY = UnityEngine.Random.Range((Screen.height*0.5f) + CONTOUR, (Screen.height - CONTOUR));
                positionblueDiamond = new Vector3(positionX, positionY, 0f);

                if (diamond.attachedRigidbody.velocity.y > 0f)
                    diamond.attachedRigidbody.velocity = new Vector2(diamond.attachedRigidbody.velocity.x, diamond.attachedRigidbody.velocity.y * -1);
            }
            else
            {
                // cuadrante I
                float positionY = UnityEngine.Random.Range(CONTOUR, (Screen.height*0.5f) - CONTOUR);
                positionblueDiamond = new Vector3(positionX, positionY, 0f);

                if (diamond.attachedRigidbody.velocity.y < 0f)
                    diamond.attachedRigidbody.velocity = new Vector2(diamond.attachedRigidbody.velocity.x, diamond.attachedRigidbody.velocity.y * -1);
            }

            diamond.transform.position = positionblueDiamond;
        }

        if (diamond.gameObject.CompareTag("redDiamond"))
        {
            numberOfDiamondRedCollisionsWithTheHand++;
            //rojoColisionMano.text = "___ : " + numberOfDiamondRedCollisionsWithTheHand.ToString();

            int randomAddress = UnityEngine.Random.Range(0, 2); // 0: down  1: up
            float positionX = UnityEngine.Random.Range((Screen.width * 0.5f) + CONTOUR, (Screen.width - CONTOUR));
            Vector3 positionredDiamond;


            if (randomAddress != 1)
            {
                // cuadrante III
                float positionY = UnityEngine.Random.Range((Screen.height * 0.5f) + CONTOUR, (Screen.height - CONTOUR));
                positionredDiamond = new Vector3(positionX, positionY, 0f);

                if (diamond.attachedRigidbody.velocity.y > 0f)
                    diamond.attachedRigidbody.velocity = new Vector2(diamond.attachedRigidbody.velocity.x, diamond.attachedRigidbody.velocity.y * -1);
            }
            else
            {
                // cuadrante II
                float positionY = UnityEngine.Random.Range(CONTOUR, (Screen.height * 0.5f) - CONTOUR);
                positionredDiamond = new Vector3(positionX, positionY, 0f);

                if (diamond.attachedRigidbody.velocity.y < 0f)
                    diamond.attachedRigidbody.velocity = new Vector2(diamond.attachedRigidbody.velocity.x, diamond.attachedRigidbody.velocity.y * -1);
            }

            diamond.transform.position = positionredDiamond;
        }

    }
}
