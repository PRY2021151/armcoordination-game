using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roofCollision : MonoBehaviour
{
    const int CONTOUR = 150;

    [SerializeField]
    private Text azulColisionTecho; // delete
    [SerializeField]
    private Text rojoColisionTecho; // delete

    public int numberOfDiamondBlueCollisionsWithTheRoof = 0;
    public int numberOfDiamondRedCollisionsWithTheRoof = 0;

    private void OnTriggerEnter2D(Collider2D diamond)
    {
        if (diamond.gameObject.CompareTag("blueDiamond"))
        {
            numberOfDiamondBlueCollisionsWithTheRoof++;
            //azulColisionMano.text = "___ : " + numberOfDiamondBlueCollisionsWithTheHand.ToString();

            int randomAddress = Random.Range(0, 2); // 0: down  1: up
            float positionX = Random.Range(CONTOUR, (Screen.width * 0.5f) - CONTOUR);
            Vector3 positionblueDiamond;


            if (randomAddress != 1)
            {
                // cuadrante IV
                float positionY = Random.Range((Screen.height * 0.5f) + CONTOUR, (Screen.height - CONTOUR));
                positionblueDiamond = new Vector3(positionX, positionY, 0f);

                if (diamond.attachedRigidbody.velocity.y > 0f)
                    diamond.attachedRigidbody.velocity = new Vector2(diamond.attachedRigidbody.velocity.x, diamond.attachedRigidbody.velocity.y * -1);
            }
            else
            {
                // cuadrante I
                float positionY = Random.Range(CONTOUR, (Screen.height * 0.5f) - CONTOUR);
                positionblueDiamond = new Vector3(positionX, positionY, 0f);

                if (diamond.attachedRigidbody.velocity.y < 0f)
                    diamond.attachedRigidbody.velocity = new Vector2(diamond.attachedRigidbody.velocity.x, diamond.attachedRigidbody.velocity.y * -1);
            }

            diamond.transform.position = positionblueDiamond;
        }

        if (diamond.gameObject.CompareTag("redDiamond"))
        {
            numberOfDiamondRedCollisionsWithTheRoof++;
            //rojoColisionMano.text = "___ : " + numberOfDiamondRedCollisionsWithTheHand.ToString();

            int randomAddress = Random.Range(0, 2); // 0: down  1: up
            float positionX = Random.Range((Screen.width * 0.5f) + CONTOUR, (Screen.width - CONTOUR));
            Vector3 positionredDiamond;


            if (randomAddress != 1)
            {
                // cuadrante III
                float positionY = Random.Range((Screen.height * 0.5f) + CONTOUR, (Screen.height - CONTOUR));
                positionredDiamond = new Vector3(positionX, positionY, 0f);

                if (diamond.attachedRigidbody.velocity.y > 0f)
                    diamond.attachedRigidbody.velocity = new Vector2(diamond.attachedRigidbody.velocity.x, diamond.attachedRigidbody.velocity.y * -1);
            }
            else
            {
                // cuadrante II
                float positionY = Random.Range(CONTOUR, (Screen.height * 0.5f) - CONTOUR);
                positionredDiamond = new Vector3(positionX, positionY, 0f);

                if (diamond.attachedRigidbody.velocity.y < 0f)
                    diamond.attachedRigidbody.velocity = new Vector2(diamond.attachedRigidbody.velocity.x, diamond.attachedRigidbody.velocity.y * -1);
            }

            diamond.transform.position = positionredDiamond;
        }

    }

}
