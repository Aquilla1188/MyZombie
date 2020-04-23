using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    protected Joystick joystick;



    private static Player instance;
    public static Player Instance 
    {
        get 
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }

            return instance;
                
        }  
    }

    public Rigidbody2D MyRigidBody { get; set; }
    
    public bool Slide { get; set; }



    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        MyRigidBody = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        healthBar.MaxValue = 100f;


    }

    // Update is called once per frame

    void Update()
    {
        HandleInput();
    }
    void FixedUpdate()
    {
        if (!IsDead)
        {
            HandleMove(Input.GetAxis("Horizontal")+ joystick.Horizontal, Input.GetAxis("Vertical") + joystick.Vertical);
            
        }

       

    }

    private void HandleMove(float H, float V)
    {
      transform.position = new Vector3(
      Mathf.Clamp(transform.position.x, -18f, 18f),
      Mathf.Clamp(transform.position.y, -8f, 2.5f),
      transform.position.z
      );
 
        if (!Attack && !Slide){
            MyRigidBody.velocity = new Vector2(H * Speed, V * Speed);
        }
        MyAnimator.SetFloat("speed", Mathf.Max(Mathf.Abs(H), Mathf.Abs(V)));
        Flip(H);
    }

 
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Btn_Sword();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Btn_Slide();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Btn_throw();
            
        }
    }

    private void Flip(float H)
    {
        if(H>0 && !FacingRight || H < 0 && FacingRight)
        {
            ChangeDir();
        }
    }

    public void ThrowKnife()
    {
        ThrowKnifes();

    }

    public override IEnumerator TakeDamage()
    {
        healthBar.CurrentValue -= 1;
        if (!IsDead)
        {
         //   MyAnimator.SetTrigger("Hit");
        }
        else
        {
            MyAnimator.SetTrigger("Death");
            yield return null;
        }
    }
    public override bool IsDead
    {
        get
        {
            if (healthBar.CurrentValue <= 0)
            {
                Death();
            }
            return healthBar.CurrentValue <= 0;
        }
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag == "Coin")
        {
            BtnsScript.Instance.CollectedCoins++;
            Destroy(collision.gameObject);
        }
       
    }

    public override void Death()
    {
        
    }

    public void Btn_Sword()
    {
        MyAnimator.SetTrigger("attack");
    }
    public void Btn_Slide()
    {
        MyAnimator.SetTrigger("Slide");


        MyRigidBody.velocity *= 1.5f ;
    }
    public void Btn_throw()
    {
        
        MyAnimator.SetTrigger("Throw");
    }

}
