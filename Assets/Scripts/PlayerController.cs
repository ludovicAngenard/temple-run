using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int _score;
    private Vector3 jump;
    public float jumpForce;
    private TextMeshProUGUI scoreText;
    Manager manager;
    private int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        speed = 6;
        jump = new Vector3(0,4,0);
        jumpForce = 2.0f;
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();

        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(jump * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localScale = new Vector3 (1, 0.5f, 1);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = new Vector3(transform.position.x - 4.5f, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 4.5f, transform.position.y, transform.position.z);
        }

        scoreText.text = score.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            //manager.SaveData(score);
            SceneManager.LoadScene("Menu");
        }
    }

}
