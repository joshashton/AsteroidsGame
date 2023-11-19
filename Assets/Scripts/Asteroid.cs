using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 1.0f;
    public float maxSize = 2.0f;
    public float minSize = 0.75f;
    public float speed = 5.0f;
    public float maxLifeTime = 30.0f;


    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        _rigidbody.mass = this.size;

    }

    public void SetTrajectory(Vector2 direction) {

        _rigidbody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifeTime);
    }


    //split asteroid if its big enough or destroy if too small
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && Shooter.currentWeapon == 2) {

            FindObjectOfType<GameManager>().AsteroidDestroyed(this);

            Destroy(this.gameObject);
            

            
        } else if (collision.gameObject.tag == "Bullet") {
            if ((this.size / 1.5f) >= this.minSize){

                CreateSplit();
                CreateSplit();
            }
            FindObjectOfType<GameManager>().AsteroidDestroyed(this);

            Destroy(this.gameObject);
        }
           
    }

    private void CreateSplit() {

        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid split = Instantiate(this, position, this.transform.rotation);
        split.size = this.size * 0.5f;
        split.SetTrajectory(Random.insideUnitCircle.normalized * this.speed); 

    }

}
