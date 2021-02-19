using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using UnityEngine.SceneManagement;
using System.Numerics;

public class Player : MonoBehaviour, IDamagable
{
    #region Variables
    int score;
    public UnityEngine.Vector2 basePos;

    [Header("Health & Death")]
    [SerializeField] float health = 0f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float yOffset = .5f;
    public bool damagable { get; set; }

    [Header("Projectiles")]
    [SerializeField] float amountOfProjectiles = 100f;
    [SerializeField] float waterUsage = 20f;
    [SerializeField] float rewardWater = 10f;
    [SerializeField] bool outOfAmmo = false;
    public bool ableToShoot { get; set; }

    [Space]
    [SerializeField] int damage = 1;
    [SerializeReference] int damageFromDeathParticles = 2;
    
    [Space]
    [SerializeField] ParticleSystem water;
    [SerializeField] GameObject gun;

    [Header("Respawn")]
    [SerializeField] float respawnTime;
    [SerializeField] Transform[] spawnPoints;

    [Header("Sliders")]
    [SerializeField] Slider fillIndicator;
    [SerializeField] Slider ammoSlider;

    public GameObject Gun { get { return gun; } }

    public int Score { get { return score; } set { score = value; } }
    public bool OutOFAmmo { get { return outOfAmmo; } }

    PlayerAudio playerAudio;
    AudioSource playerAudioSource;

    #endregion

    #region Start&Update
    private void Start()
    {
        basePos = transform.position;
        playerAudio = GetComponent<PlayerAudio>();
        playerAudioSource = GetComponent<AudioSource>();

        if(gameObject.CompareTag("Player 1"))
        {
            PlayerManager.Instance.Player1Died += Die;
        }
        else
        {
            PlayerManager.Instance.Player2Died += Die;
        }
    }

    private void Update()
    {
        if(gameObject.CompareTag("Player 1"))
        {
            if (Input.GetButton("Player 1 Fire") && ableToShoot)
            {
                if (amountOfProjectiles <= 0)
                {
                    water.enableEmission = false;
                    playerAudio.StopPlayerShootSFX();
                    outOfAmmo = true;
                    return;
                }

                outOfAmmo = false;
                water.enableEmission = true;
                UseWater();
            }
            if(Input.GetButtonUp("Player 1 Fire"))
            {
                water.enableEmission = false;
            }


            if (Input.GetButtonDown("Player 1 Fire") && !outOfAmmo && ableToShoot)
            {
                playerAudio.PlayPlayerShootSFX();
            }
            if (Input.GetButtonUp("Player 1 Fire") || outOfAmmo || SceneManager.GetActiveScene().name == "Scoreboard" || !ableToShoot)
            {
                playerAudio.StopPlayerShootSFX();
            }

        }
        else if(gameObject.CompareTag("Player 2"))
        {
            if (Input.GetButton("Player 2 Fire") && ableToShoot)
            {
                if (amountOfProjectiles <= 0)
                {
                    water.enableEmission = false;
                    playerAudio.StopPlayerShootSFX();
                    outOfAmmo = true;
                    return;
                }

                outOfAmmo = false;
                water.enableEmission = true;
                UseWater();
            }
            if(Input.GetButtonUp("Player 2 Fire"))
            {
                water.enableEmission = false;
            }

            if (Input.GetButtonDown("Player 2 Fire") && !outOfAmmo && ableToShoot)
            {
                playerAudio.PlayPlayerShootSFX();
            }
            if (Input.GetButtonUp("Player 2 Fire") || outOfAmmo || SceneManager.GetActiveScene().name == "Scoreboard" || !ableToShoot)
            {
                playerAudio.StopPlayerShootSFX();
            }
        }
    }
    #endregion

    private void OnParticleCollision(GameObject other)
    {
        if(!other.gameObject.CompareTag("Player 1 Death Particles") && !other.gameObject.CompareTag("Player 2 Death Particles"))
            Damage(other.gameObject.GetComponentInParent<Player>().damage);
        else
        {
            //Debug.Log(gameObject.name + " got hit for " + damageFromDeathParticles + " dmg");
            Damage(damageFromDeathParticles);
        }
    }

    public void Damage(int damage)
    {
        if (health + damage < 100f)
        {
            health += damage;
            //Debug.Log("[Player] name: " + gameObject.name + " now has " + health + " health");
            UpdateFillIndicator();
        } else if (health + damage >= 100f)
        {
            if (gameObject.CompareTag("Player 1"))
                PlayerManager.Instance.TriggerPlayer1Died();
            else if (gameObject.CompareTag("Player 2"))
                PlayerManager.Instance.TriggerPlayer2Died();
        }
    }

    public void Die()
    {
        GameObject death = Instantiate(deathVFX, transform.position, UnityEngine.Quaternion.identity);
        StartCoroutine(WaitAndDestroy(death));

        CameraShaker.Instance.ShakeOnce(4f, 2f,.1f, 1f);

        playerAudio.PlayPlayerDeathSFX();

        //Debug.Log(gameObject.name + " has died!");
        Respawn();

        if (gameObject.CompareTag("Player 1"))
        {
            PlayerManager.Instance.Player2AddPoint();
            PlayerManager.Instance.Player2AddWater();

            PlayerManager.Instance.IncreasePlayer2Combo();
        }else if (gameObject.CompareTag("Player 2"))
        {
            PlayerManager.Instance.Player1AddPoint();
            PlayerManager.Instance.Player1AddWater();

            PlayerManager.Instance.IncreasePlayer1Combo();
        }
           
    }

    IEnumerator WaitAndDestroy(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        Destroy(obj);
    }

    void Respawn()
    {
        health = 0f;
        amountOfProjectiles = 100f;
        outOfAmmo = false;

        UpdateFillIndicator();
        UpdateAmmoCount();
        transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
    }

    public void ResetPlayer()
    {
        health = 0f;
        amountOfProjectiles = 100f;
        outOfAmmo = false;

        UpdateFillIndicator();
        UpdateAmmoCount();
        transform.position = basePos;
    }

    public void UpdateFillIndicator()
    {
        fillIndicator.value = health;
    }
    public void UpdateAmmoCount()
    {
        ammoSlider.value = amountOfProjectiles;
    }

    void UseWater()
    {
        amountOfProjectiles -= Time.deltaTime * waterUsage;
        UpdateAmmoCount();
    }
    public void AddWater()
    {
        if(gameObject.CompareTag("Player 1"))
        {
            amountOfProjectiles = (amountOfProjectiles + rewardWater > 100f) ? 100f : amountOfProjectiles + rewardWater + 
                (PlayerManager.Instance.Player1Combo - 1) * rewardWater * .3f;
        }
        else
        {
            amountOfProjectiles = (amountOfProjectiles + rewardWater > 100f) ? 100f : amountOfProjectiles + rewardWater +
                (PlayerManager.Instance.Player2Combo - 1) * rewardWater * .3f;
        }
        UpdateAmmoCount();
    }
}
