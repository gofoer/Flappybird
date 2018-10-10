using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public float jump = 4;
    public Text scoreText;
    Rigidbody2D rb2d;
    bool isDead = false;
    int score = 0;

	public AudioClip jumpClip;
	public AudioClip deadClip;
	public AudioClip scoreClip;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isDead)
        {
            rb2d.velocity = new Vector2(0, jump);
			AudioManager.instance.PlaySfx(jumpClip);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && isDead)
            SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        GetComponent<Animator>().SetTrigger("dead");
		AudioManager.instance.PlaySfx(deadClip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ScoreTrigger"){
            score += 1;
            scoreText.text = "Score : " + score;
        }
    }
}