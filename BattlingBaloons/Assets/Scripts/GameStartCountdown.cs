using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class GameStartCountdown : MonoBehaviour
{
    [SerializeField] Light2D light;
    [SerializeField] Text _countdownText;

    [Space]
    [SerializeField] int startTime = 5;
    
    float timeLeft;
    bool RoundStarted = false;

    [Space]
    [SerializeField] Player Player1;
    [SerializeField] Player Player2;

    RoundManager roundManager;

    // Start is called before the first frame update
    void Start()
    {
        roundManager = FindObjectOfType<RoundManager>();

        SetupRoundCountdown();

        roundManager.OnRoundEnded += SetupRoundCountdown;
    }

    // Update is called once per frame
    void Update()
    {
        if(!RoundStarted)
            CountDown();
    }

    void SetupRoundCountdown()
    {
        timeLeft = startTime;
        _countdownText.text = startTime.ToString();

        roundManager.timeRunning = false;

        Player1.ableToShoot = false;
        Player2.ableToShoot = false;

        Player1.damagable = false;
        Player2.damagable = false;

        if (RoundStarted)
        {
            RoundStarted = false;

            light.gameObject.SetActive(true);
            _countdownText.gameObject.SetActive(true);
        }
    }

    public void CountDown()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            _countdownText.text = Mathf.CeilToInt(timeLeft).ToString();
        }
        else if (timeLeft <= 0)
        {
            Player1.ableToShoot = true;
            Player2.ableToShoot = true;

            Player1.damagable = true;
            Player2.damagable = true;

            roundManager.timeRunning = true;
            RoundStarted = true;

            StartCoroutine(WaitAndDestroy());
        }
    }

    IEnumerator WaitAndDestroy()
    {
        _countdownText.text = "Start!";

        yield return new WaitForSeconds(1.2f);

        light.gameObject.SetActive(false);
        _countdownText.gameObject.SetActive(false);
    }
}
