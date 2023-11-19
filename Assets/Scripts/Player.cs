using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public ItemRapid item;

    //public Bullet bulletPrefab;
    //public float thrustSpeed = 1.0f;
    //public float turnSpeed = 0.2f;

    public static bool isDead = false;
    private Rigidbody2D _rigidbody;
    //private bool _thrusting;
    //private float _turnDirection;
    
    private void Awake()
    {
       
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        //_thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
        //    _turnDirection = 1.0f;

        //} else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
        //    _turnDirection = -1.0f;
        //} else {
        //    _turnDirection = 0.0f;
        //}


        //if item holding is ItemRapid fire do smething

        //else do normal shoot
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Shoot();
        //}



    }

    //private void FixedUpdate()
    //{
    //    if (_thrusting) {
    //        _rigidbody.AddForce(this.transform.up * this.thrustSpeed);
    //    }
    //    if (_turnDirection != 0.0f) {
    //        _rigidbody.AddTorque(_turnDirection * this.turnSpeed);
    //    }
    //}

    //private void Shoot()
    //{
    //    Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
    //    bullet.Project(this.transform.up);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            isDead = true;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;

            //FindObjectOfType<Item>().deactivateItem();
            //Item.deactivateItem();
            this.gameObject.SetActive(false);

            //bad way
            FindObjectOfType<GameManager>().PlayerDied();
            
              
        }
    }
}
