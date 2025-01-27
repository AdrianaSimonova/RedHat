using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemChecker : MonoBehaviour
{
    
    public int score;
    public GameObject ScoreObject;
    public GameObject TextObject;
    private bool isBasketFull = false;

    public TMP_Text scoreText;
    public TMP_Text playText;
    public AudioClip OkSound, BoomSound;

    void Start()
    {
        scoreText = ScoreObject.GetComponent<TMP_Text>();
        playText = TextObject.GetComponent<TMP_Text>();
    }

    void OnTriggerEnter2D (Collider2D other) {
        Debug.Log("Collision with: " + other.gameObject.name);
        if (other.gameObject.tag == "Good" && !isBasketFull) {
            Debug.Log("Collision with: " + other.gameObject.name);
            score = score + 10;
            AudioSource.PlayClipAtPoint(OkSound, other.transform.position);
            scoreText.text = score.ToString();
            Destroy (other.gameObject);
            LevelComplete();
        }

        if (other.gameObject.tag == "Bad" && !isBasketFull) {
            Debug.Log("Collision with: " + other.gameObject.name);
            score = score - 10;
            AudioSource.PlayClipAtPoint(BoomSound, other.transform.position);
            scoreText.text = score.ToString();
            Destroy (other.gameObject);
            LevelComplete();
        }
    }

    void LevelComplete()
    {
        if (score >= 100)
        {
            isBasketFull = true;
            playText.text = "Košík je plný: ";
        }
    }
}

