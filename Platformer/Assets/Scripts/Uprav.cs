using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;
using System.Threading;
using UnityEngine.Advertisements;

public class Uprav : MonoBehaviour 
{
    bool TestMide = false;
    string GooglePlay_Id = "";
    string PlacementID = "video";

    public float speed;
    public float horizontalSpeed;
    float speedX;
    public float verticalImpuls;
    Rigidbody2D rb;
    private Animator anim;
    bool FacingRight;
    private static float Zdoh = 0;

    public LayerMask ground;
    private bool isGraund;
    public Transform graundChek;
    public float chekRadius;
    private int extraJumps;
    public int extraJumpsV;

    private void FixedUpdate()
    {
        isGraund = Physics2D.OverlapCircle(graundChek.position, chekRadius, ground);
    }

    void Start()
    {
        extraJumps = extraJumpsV;
        anim = GetComponent<Animator>();
        Advertisement.Initialize(GooglePlay_Id, TestMide);
        rb = GetComponent<Rigidbody2D>();
    }

    public void LeftButtonDown()
    {
        if (FacingRight == false)
        {
            Flip();
        }
        speedX = -horizontalSpeed;
        anim.SetBool("IsRuning", true);
    }

    public void RightButtonDown()
    {
        if (FacingRight == true)
        {
            Flip();
        }
        speedX = horizontalSpeed;
        anim.SetBool("IsRuning", true);
    }

    public void Stop()
    {
        speedX = 0;
        anim.SetBool("IsRuning", false);
    }

    public void Jump1()
    {
        if (isGraund == true)
        {
            extraJumps = extraJumpsV;
        }

        if (extraJumps > 0)
        {
            rb.velocity = Vector2.up * verticalImpuls;
            extraJumps--;
        }
        
        
        //if (isGraund == true)
        //{
            //rb.AddForce(new Vector2(0, verticalImpuls), ForceMode2D.Impulse);
        //}
       
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Update()
    {

        // if (Input.GetKey(KeyCode.A))
        // {
          // speedX = -horizontalSpeed;
         //}
         //else if (Input.GetKey(KeyCode.D))
       // {
         // speedX = horizontalSpeed;
        // }
        
        //if (Input.GetKeyDown(KeyCode.Space)&& isGraund)
        //{
            //rb.AddForce(new Vector2(0, verticalImpuls), ForceMode2D.Impulse);
        //}
        transform.Translate(speedX, 0, 0);
        //speedX = 0;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Enemy")
        {
            Zdoh++;
            if (Zdoh >= 5)
            {
                {
                    Zdoh = 0;
                    Advertisement.Show(PlacementID);
                    Debug.LogWarning("Stonks!");
                }
            }
            Thread.Sleep(500);
            SceneManager.LoadScene(0);

        }
        //if (collision.gameObject.tag == "Platform")
        //{
            //isGraund = true;
        //}
    }

   
    //private void OnCollisionExit2D(Collision2D collision)
    //{
        //if (collision.gameObject.tag == "Platform")
        //{
            //isGraund = false;
        //}
    //}
}
