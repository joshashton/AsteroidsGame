using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInsta : Item
{

    public float activeTimer = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void activateItem()
    {

        Shooter.currentWeapon = 2;
        //FindObjectOfType<Shooter>().setWeapon(1);
        Invoke("deactivateItem", activeTimer);
        //StartCoroutine(deactivateGun());
        StartCoroutine(deactivateGun());
        //base.activateItem();
        Debug.Log("InstaActivate");
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

            Debug.Log("InstaDeactivate");
        }

        base.deactivateItem();
    }
    IEnumerator deactivateGun()
    {
        Debug.Log("coroutine");
        yield return new WaitForSeconds(activeTimer);
        Debug.Log("after wait coroutine");
        if (!Player.isDead)
        {
            //FindObjectOfType<Shooter>().setWeapon(0);
            Shooter.currentWeapon = 0;

            Debug.Log("InstaDeactivate2");
        }
    }
}
