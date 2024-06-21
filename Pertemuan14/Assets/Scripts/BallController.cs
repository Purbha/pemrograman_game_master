using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    public int force;
    Rigidbody2D rigid;
    int score1;
    int score2;
    Text scoreUIP1;
    Text scoreUIP2;
    GameObject panelSelesai;
    Text txtPemenang;
    AudioSource audioSource;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2,0).normalized;
        rigid.AddForce(arah * force);
        score1 = 0;
        score2 = 0;   
        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();     
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();  
        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);   
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        audioSource.PlayOneShot(hitSound);
        if(coll.gameObject.name == "TepiKanan") 
        {
            Debug.Log("Tepi Kanan");
            score1 += 1;
            TampilkanScore();
            if (score1 == 5)
            {
                panelSelesai.SetActive(true);
                txtPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txtPemenang.text = "Player Biru Menang";
                Destroy(gameObject);
                return;
            }
            ResetBall();
            Vector2 arah = new Vector2(2,0).normalized;
            rigid.AddForce(arah * force);
        }
        if (coll.gameObject.name == "TepiKiri")
        {
            Debug.Log("Tepi Kiri");
            score2 += 1;
            TampilkanScore();
            if (score2 == 5)
            {
                panelSelesai.SetActive(true);
                txtPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txtPemenang.text = "Player Merah Menang";
                Destroy(gameObject);
                return;
            }
            ResetBall();
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);
        }
        if(coll.gameObject.name == "Pemukul1" || coll.gameObject.name == "Pemukul2") {
            Debug.Log("Pemukul");
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 2);
        }
    }

    void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }

    void TampilkanScore() {
        scoreUIP1.text = score1.ToString();
        scoreUIP2.text = score2.ToString();
    }


}
