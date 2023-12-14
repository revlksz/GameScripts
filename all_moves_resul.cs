using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class all_moves_resul : MonoBehaviour
{
    public static bool canDash = true;
    public static bool isDashing;

    //  lvl des.  için deðiþtirilebilir dash özellikleri
    [SerializeField] public float DashAmount;
    [SerializeField] public float DashTime;
    [SerializeField] public float DashCooldown;
    [SerializeField] public float RetakeTime;
    
    // bomba düþürme geri alma deðiþkenleri
    public GameObject Child;    
    public Transform Parent;

    public float RandNum = 0f;
    private static int dashCount=0;
    public float CharSpeed;
    Vector2 direction;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //private bool isRetaking = false;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bomb"))
        {
            //isRetaking = true;
            //StartCoroutine(Retaking());
            Child.transform.SetParent(Parent);          
        }
    }
    /*
    IEnumerator Retaking()               //  bekletme
    {
        if(isRetaking==true) 
        {
            Debug.Log("corotin baþladý ");
            Time.timeScale = 0f;
            yield return new WaitForSeconds(RetakeTime);
            Time.timeScale = 1f;
            Debug.Log("corotin bitti ");

            isRetaking = false;
        }
        
    } */

    void Update()
    {
        InputManager();

        if (Input.GetKey(KeyCode.Space) && canDash && direction.x != 0 && direction.y == 0)  
        {
            StartCoroutine(dash());
        }
        else if (Input.GetKey(KeyCode.Space) && canDash && direction.y != 0 && direction.x == 0)
        {
            StartCoroutine(dash());
        }
        else if(Input.GetKey(KeyCode.Space) && canDash && direction.x != 0 && direction.y!=0)
        {
            StartCoroutine(dash());
        }
    }
    void FixedUpdate()
    {
        Action();
    }

    private void InputManager()
    {
        float xaxsis = Input.GetAxisRaw("Horizontal");
        float yaxsis = Input.GetAxisRaw("Vertical");
        direction = new Vector2(xaxsis, yaxsis);
    }
    private void Action()
    {
        if (isDashing)                          // dash atýyorsa diðer hareketleri yapamaz
        {
            return;
        }

        rb.velocity = new Vector2(direction.x * CharSpeed, direction.y * CharSpeed);
    }

    /*          OnCollisionEnter'da BOMBAYI GERI ALDI
    public void parenting(Transform newParent)             // bombayý geri alma
    {
        Child.transform.SetParent(newParent);
    } */

    public void unparenting(Transform newParent)            // bombayý düþürme
    {
        Child.transform.SetParent(null);
        StartCoroutine(DisableCollider(0.5f));
    } 
    
    IEnumerator DisableCollider(float duration)
    {
        Collider2D childCollider = Child.GetComponent<Collider2D>();
        if (childCollider != null)
        {
            childCollider.enabled = false;
            yield return new WaitForSeconds(duration);
            childCollider.enabled = true;
        }
    }

    IEnumerator dash()
    {
        dashCount++;                                    // toplam dash sayýsý
        Debug.Log("Dash atýyoruzzz");
        canDash = false;
        isDashing = true;

        if(direction.x != 0 && direction.y == 0)        // x doðrultusunda dash
        {
            rb.velocity = new Vector2(direction.x * DashAmount, 0f);
        }
        else if(direction.y != 0 && direction.x == 0)       // y doðrultusunda dash
        {
            rb.velocity = new Vector2(0f, direction.y * DashAmount );
        }
        else if(direction.x != 0 && direction.y != 0)       // çapraz yönde dash
        {
            rb.velocity = new Vector2(direction.x * DashAmount, direction.y * DashAmount);
        }

        yield return new WaitForSeconds(DashTime);      // dash atým süresi

        RandNum = Random.Range(0, 101);                 // bomba düþürme þansý
        Debug.Log(RandNum);
        
        if(RandNum<=10 || dashCount==3 )                // bomba düþürme durumu
        {
            unparenting(Parent);
            dashCount = 0;
        } 

        isDashing = false;
        yield return new WaitForSeconds(DashCooldown);      // dash atým bekleme süresi
        Debug.Log("U can dash cnm");
        canDash = true;
    }
}
