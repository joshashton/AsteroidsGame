using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRapid : Item
{
    //public Bullet bulletPrefab;

    public float activeTimer = 5;
    

    private void Start()
    {
        
        //if (Input.GetKey(KeyCode.Space))
        //{
        //   //Shoot();
        //}
        //shooter.currentWeapon = 1;
        //FindObjectOfType<Shooter>().currentWeapon;
                    //FindObjectOfType<GameManager>().PlayerDied();
    }

    public override void activateItem() {

        Shooter.currentWeapon = 1;
        //FindObjectOfType<Shooter>().setWeapon(1);
        Invoke("deactivateItem", activeTimer);
        //StartCoroutine(deactivateGun());
        StartCoroutine(deactivateGun());
        //base.activateItem();
        Debug.Log("RapidActivate");
    }

    public override void deactivateItem()
    {
        //ShipShooter shooter = ship.GetComponent<ShipShooter>();
        //shooter.activeWeapon = (int)ShipShooter.Weapons.Default;
        //base.DenyPower();
        //Cant call fuction if players dead as theres no attached object
        if (!Player.isDead)
        {
            //FindObjectOfType<Shooter>().setWeapon(0);
            Shooter.currentWeapon = 0;

            Debug.Log("RapidDeactivate");
        }

        //base.deactivateItem();
    }

    IEnumerator deactivateGun() {

        Debug.Log("coroutine");
        yield return new WaitForSeconds(activeTimer);
        Debug.Log("after wait coroutine");
        if (!Player.isDead)
        {
            //FindObjectOfType<Shooter>().setWeapon(0);
            Shooter.currentWeapon = 0;

            Debug.Log("RapidDeactivate2");
        }
    }

    //private void Shoot()
    //{
    //    Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
    //    bullet.Project(this.transform.up);
    //}
}



