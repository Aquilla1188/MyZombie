using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]    private List<string> DamageSources;
    [SerializeField]    private EdgeCollider2D AttackCol;
    [SerializeField]    protected float Speed = 10;
    [SerializeField]    protected Stat healthBar;
    [SerializeField]    private GameObject KnifePrefab;

    public bool Attack { get; set; }
    public bool TakingDamage { get; set; }
    public Animator MyAnimator { get; private set; }
    
   
    [SerializeField]    public abstract bool IsDead { get; }

    protected bool FacingRight = true;
    public abstract void Death();
    public abstract IEnumerator TakeDamage();
    // Start is called before the first frame update
    public virtual void Start()
    {
        MyAnimator = GetComponent<Animator>();
        healthBar.Initialize();
        
    }


    public void ChangeDir()
    {
        FacingRight = !FacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
    }

    public void ThrowKnifes()
    {
        if (FacingRight)
        {
            GameObject tmp = (GameObject)Instantiate(KnifePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            tmp.GetComponent<Knife>().Initialize(Vector2.right);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(KnifePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            tmp.GetComponent<Knife>().Initialize(Vector2.left);
        }

    }

    public void MeleeAttack()
    {
        AttackCol.enabled = true;
        AttackCol.isTrigger = true;
    }

    public void MeleeAttack_Disable()
    {
        AttackCol.enabled = false;
        AttackCol.isTrigger = false;
    }


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (DamageSources.Contains( collision.tag ))
        {
            StartCoroutine(TakeDamage());
        }
    }
}
