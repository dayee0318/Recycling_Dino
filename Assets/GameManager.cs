using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int stagePoint;
    public int health;
    public dino_move player;
    public int itemCount;

    public Image[] UIhealth;
    public TMP_Text UIPoint;
    public GameObject RestartBtn;


    void Update()
    {
        UIPoint.text = stagePoint.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0.4f);


            if (health > 0)
            {
                collision.attachedRigidbody.velocity = Vector2.zero;
                collision.transform.position = new Vector3(8.79f, 7.66f, -1);
            }
            
            else
            {
                collision.attachedRigidbody.velocity = Vector2.zero;
                player.OnDie();
                RestartBtn.SetActive(true);
            }
        }
    }


    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Clear()
    {
        player.OnClear();
        RestartBtn.SetActive(true);
        
    }

}
