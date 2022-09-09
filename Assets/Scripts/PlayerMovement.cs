using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private void Start()
    {
        deathMenu.SetActive(false);
        InvokeRepeating("IncreasePlayerSpeed", 5f, 10f);
        damageTaken = 0;
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
	}

    public void Die ()
    {
        alive = false;
        deathMenu.SetActive(true);
        backroundMusic.Stop();
    }

    public void TakeDamage()
    {
        if (damageTaken == 0)
        {
            lifeX1.SetActive(true);
            damageTaken++;
        }
        else if (damageTaken == 1)
        {
            lifeX2.SetActive(true);
            damageTaken++;
        }
        else if(damageTaken == 2)
        {
            lifeX3.SetActive(true);
            damageTaken++;
        }
        else
        {
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

    public void QuitGame()
    {
        Application.Quit();
    }
}