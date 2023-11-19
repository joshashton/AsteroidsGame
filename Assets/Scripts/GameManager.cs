using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    //public Item itemPrefab;
    public Player player;
    public ParticleSystem explosion;
    public ItemManager itemManager;
    
   
    public float respawnTime = 3.0f;
   
    public string mainMenu;

    public int score;

    public TextMeshProUGUI scoreText;

    public int lives;

    public TextMeshProUGUI livesText;

    [SerializeField] private const float DROPRATE = 0.5f;


    private void Start()
    {
        SetScore(0);
        SetLives(3);
    }

    public void AsteroidDestroyed(Asteroid asteroid) {

        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        if (asteroid.size < 1.1f)
        {
            SetScore(score + 100);

        }
        else if (asteroid.size < 1.55f)
        {
            SetScore(score + 50);

            //send gameobject of player so that it knows the player its adding power to 
            //need the astroid location data to place item in that location

            //StartCoroutine(itemManager.SpawnPowerupsFor(player.gameObject));
            //StartCoroutine(powerupManager.SpawnPowerupsFor(ship.gameObject));
            //10% chance to drop item
            if (Random.Range(0f, 1f) <= DROPRATE)
            {

                Vector3 position = asteroid.transform.position;
                Quaternion rotation = transform.rotation;
                itemManager.SpawnItemAt(position, rotation);

                //Instantiate(itemPrefab, asteroid.transform.position, transform.rotation);
            }
        }
        else
        {
            SetScore(score + 25);

            if (Random.Range(0f, 1f) <= DROPRATE)
            {

                Vector3 position = asteroid.transform.position;
                Quaternion rotation = transform.rotation;
                itemManager.SpawnItemAt(position, rotation);

                //Instantiate(itemPrefab, asteroid.transform.position, transform.rotation);
            }
        }


    }

    public void PlayerDied() {

        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        SetLives(lives - 1);

        if (lives <= 0)
        {
            GameOver();
        }
        else {
            Invoke(nameof(Respawn), this.respawnTime);
        }

        
    }

    private void Respawn() {
        //reset weapon and reset player
        Player.isDead = false;
        Shooter.currentWeapon = 0;
        this.player.transform.position = Vector2.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collision");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), 3.0f);
    }

    private void TurnOnCollisions() {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver() {

        //Save score
        FindObjectOfType<GamePrefManager>().SavePrefs(this.score);
       
        SceneManager.LoadScene(mainMenu);
    }

    private void SetScore(int score)
    {
        //Debug.Log("setscore called");
        this.score = score;
        Achievements.ach1Count = score;
        scoreText.text = score.ToString();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = lives.ToString();
    }

    public int GetScore() {
        return score;
    }

    public int GetLives() {
        return lives;
    }
}
