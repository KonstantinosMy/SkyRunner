using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour {

    bool alive = true;
    public int damageTaken;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 100f;
    public GameObject deathMenu;
    public AudioSource backroundMusic;

    public GameObject lifeX1;
    public GameObject lifeX2;
    public GameObject lifeX3;

    public CameraShake camera;
    public Timer gameTimer;
    public Image redImage;

    public AudioSource klonk;

    public float currentTime;
    public TextMeshProUGUI bestTime;
    public Timer clock;
    private void Start()
    {
        Time.timeScale = 1;
        deathMenu.SetActive(false);
        InvokeRepeating("IncreasePlayerSpeed", 5f, 10f);
        damageTaken = 0;

        bestTime.text = "Best Time Alive: " + PlayerPrefs.GetInt("BestTime", 0).ToString() + " seconds";

    }
    private void FixedUpdate ()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;// * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update () {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5) {
            Die();
        }

        currentTime = clock.GetComponent<Timer>().timer;
    }


    public void Die ()
    {
        alive = false;
        deathMenu.SetActive(true);
        gameTimer.timerIsActive = false;

        if (currentTime > PlayerPrefs.GetInt("BestTime", 0))
        {
            Debug.Log(Mathf.RoundToInt(currentTime));
            PlayerPrefs.SetInt("BestTime", Mathf.RoundToInt(currentTime));
            bestTime.text = "Best Time Alive: " + Mathf.RoundToInt(currentTime).ToString() + " seconds";
        }

        backroundMusic.Stop();
    }

    public void TakeDamage()
    {
        klonk.Play();
        if (damageTaken == 0)
        {
            
            camera.shakeTheCamera();
            camera.shakeDuration = 1.5f;
            redImage.GetComponent<Image>().color = new Color(1f,0f,0f,0.3f);
            //shakeAmount = 0.3f;
            //shakeDuration = 1.5f;
            //decreaseFactor = 3f;

            lifeX1.SetActive(true);
            damageTaken++;
        }
        else if (damageTaken == 1)
        {
            
            camera.shakeTheCamera();
            camera.shakeDuration = 1.5f;
            redImage.GetComponent<Image>().color = new Color(1f, 0f, 0f, 0.3f);
            lifeX2.SetActive(true);
            damageTaken++;
        }
        else
        {
            
            camera.shakeTheCamera();
            camera.shakeDuration = 1.5f;
            lifeX3.SetActive(true);
            Die();
        }
    }
    void IncreasePlayerSpeed()
    {
        speed += speedIncreasePerPoint;
        Debug.Log("Increasing Speed. Current Speed: " + speed);
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        deathMenu.SetActive(true);
        backroundMusic.Stop();
    }

    public void ResumeMenu()
    {
        Time.timeScale = 1;
        deathMenu.SetActive(false);
        backroundMusic.Play();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}