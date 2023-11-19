using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //private Item[] itemsList;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;

    [Range(5, 30)]
    public int showTime = 10;
    //protected float activeTimer = 5;

    //public bool isVisible;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        Destroy(this.gameObject, showTime);     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //gives time to deactivate item
            
            activateItem();
            gameObject.GetComponent<Renderer>().enabled = false;
            //gameObject.SetActive(false);
            //gameObject.GetComponent<Collider>().enabled = false;
            //Destroy(this.gameObject);

        }
    }

    public virtual void activateItem() {
        //Invoke("deactivateItem", 3);
        //Invoke("deactivateItem", 5);
        Debug.Log("activate");
    }

    public virtual void deactivateItem() {


    }

    //protected IEnumerator deactivateItem() {
    //    Debug.Log("deactivate");
    //    //FindObjectOfType<Shooter>().setWeapon(0);
    //    yield return new WaitForSeconds(activeTimer);
    //    if (!Player.isDead)
    //    {
    //        //FindObjectOfType<Shooter>().setWeapon(0);
    //        Shooter.currentWeapon = 0;

    //        Debug.Log("RapidDeactivate2");
    //    }
    //}

}

