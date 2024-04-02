using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public float upwardFlap;
    public Rigidbody2D rigidBody;
    private LogicScript logic;
    public bool BirdIsAlive = true;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    public GameObject spaceText;
    private AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //idleFlappingStart();
        if (Input.GetKeyDown(KeyCode.Space) && BirdIsAlive && (Time.timeScale == 1))
        {
            //Add velocity to bird when space is pressed
            rigidBody.velocity = Vector2.up * upwardFlap;
            animator.SetTrigger("spaceButton");
            audioManager.playSound(audioManager.birdFlap);

        }
        //Pulls up game over screen if bird dies
        if (BirdIsAlive == false)
        {
            logic.gameOver();
        }
        //Sets the climb speed to use for animations
        animator.SetFloat("climbSpeed", rigidBody.velocity.y);



    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rigidBody.velocity.y);
    }
    // Kills Bird On collision 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BirdIsAlive = false;
        audioManager.playSound(audioManager.birdCrash);
        audioManager.stopSound();
    }

}
