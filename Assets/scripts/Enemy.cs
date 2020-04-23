using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private IenemyState CurrentState;

    [SerializeField]    public GameObject Target;//{ get; set; }
    [SerializeField]    private float MeleeRange = 1.5f;
    [SerializeField]    private float throwRange = 5f;

    private bool dropItem=true;

    public bool InMeleeRange 
    {
        get
        {
            if(Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= MeleeRange;
            }
            return false;
        }
        
    }

    public bool InThrowRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= throwRange;
            }
            return false;
        }

    }

    public override bool IsDead
    {
        get
            {
            return healthBar.CurrentValue <= 0;
            }
    }


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        ChangeState(new IdleState());
        Speed = 5;
        Target= Player.Instance.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsDead)
        {
            if (!TakingDamage)
            {
                CurrentState.Excute();
                LookAtTarget();
            }
            
        }
    }

    public void ChangeState(IenemyState newState)
    {
        if(CurrentState != null)
        {
            CurrentState.Exit();
        }

        CurrentState = newState;
        CurrentState.Enter(this);
    }

    public void Move()
    {
        MyAnimator.SetFloat("speed", 1);
       // transform.Translate(GetDirection() * Speed * Time.deltaTime);
       transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed*Time.deltaTime);
     
    }

    public Vector2 GetDirection()
    {
        return FacingRight ? Vector2.right : Vector2.left;
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        CurrentState.OnTriggerEnter(collision);
    }
 
    private void LookAtTarget()
    {
        if(Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;
            if(xDir<0 && FacingRight || xDir>0 && !FacingRight)
            {
                ChangeDir();
            }
        }
    }

    public override IEnumerator TakeDamage()
    {
        healthBar.CurrentValue -= 1;
        if (!IsDead)
        {
            MyAnimator.SetTrigger("Hit");
        }
        else
        {
            if (dropItem) 
            {
                GameObject Coin = (GameObject)Instantiate(BtnsScript.Instance.CoinPrefab, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
                Renderer CoinRenderer = Coin.GetComponent<Renderer>();
                CoinRenderer.sortingOrder += 100;
                dropItem = false;

            }

            MyAnimator.SetTrigger("Death");
       
            yield return null;
        }
        
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        // Debug-draw all contact points and normals
        //foreach (ContactPoint contact in collisionInfo.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //}


    }

    public override void Death()
    {
        Destroy(gameObject);
    }
}
