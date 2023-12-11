using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded;
    public int maxHealth = 3;
    private int currentHealth;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; 
    }

    void Update()
    {
        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 jumpDirection = new Vector2(horizontalInput, 1).normalized;

            rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(); 
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
    void TakeDamage() // Add this method.
    {
        currentHealth--;

        // Check for game over.
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver() 
    { 
        Debug.Log("Game Over");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

        public void ApplySpeedBoost(float multiplier, float duration)
        {
            StartCoroutine(SpeedBoostRoutine(multiplier, duration));
        }

        IEnumerator SpeedBoostRoutine(float multiplier, float duration)
        {
            speed *= multiplier;

            yield return new WaitForSeconds(duration);
            
            speed /= multiplier;
        }
        
}
