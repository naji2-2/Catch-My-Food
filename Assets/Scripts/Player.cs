using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0;

    public AudioSource audioSource;
    public AudioClip EatClip;
    public AudioClip AttackClip;
    public AudioClip CoinClip;

    void Start()
    {


    }

    void Update()
    {
        Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= moveTo;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += moveTo;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Food")
        {
            audioSource.clip = EatClip;
            audioSource.Play();
            GameManager.instance.IncreaseFood();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Coin")
        {
            audioSource.clip = CoinClip;
            audioSource.Play();
            GameManager.instance.IncreaseCoin();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Attack")
        {
            audioSource.clip = AttackClip;
            audioSource.Play();
            GameManager.instance.DecreaseAttack();
            GameManager.instance.GotAttackPanel();
            Destroy(collision.gameObject);
        }
    }
}
