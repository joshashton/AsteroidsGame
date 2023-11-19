using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public Bullet bulletPrefab;
    private Rigidbody2D _rigidbody;

    public enum Items { Default, Rapid, Freeze}
    public static int currentWeapon = (int)Items.Default;

    public bool canShoot = true;
    public float delayInSeconds = 0.05f;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    public void Update()
    {
        //if (Player.isDead) {
        //    currentWeapon = (int)Items.Default;
        //    Debug.Log("reset weapon");
        //}
        //Slow down rapid fire
        if (canShoot == true && currentWeapon == 1 && Input.GetKey(KeyCode.Space)) {
            Shoot();
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void setWeapon(int num) {
        currentWeapon = num;
    }


    private void Shoot()
    {
        switch (currentWeapon)
        {
            case (int)Items.Default:
                ShootDefault();
                break;
            case (int)Items.Rapid:
                ShootRapid();
                break;
            case (int)Items.Freeze:
                ShootInsta();
                break;
        }
    }

    void ShootDefault() {
        //Debug.Log("defalut");
        

        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
        //canShoot = false;
        //StartCoroutine(ShootDelay());
        
        
    }

    //can hold down to shoot
    void ShootRapid() {
        //Debug.Log("rapid");
        if (Input.GetKey(KeyCode.Space))
        {
            ShootDefault();
        }
        
    }
    //Insta destroy all asteroids for a time 
    void ShootInsta() {

        ShootDefault();
        
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }

}
