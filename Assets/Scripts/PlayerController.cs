using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rig;
    public float moveSpeed;
    public float jumpForce;
    private bool isGrounded;
    [SerializeField] public int coins;
    public TextMeshProUGUI coinsText;
    public int health;
    public TextMeshProUGUI healthText;
    

    void Update()
    {
        // moving the player with arrow keys
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float z = Input.GetAxisRaw("Vertical")* moveSpeed;

        rig.velocity = new Vector3(x, rig.velocity.y, z);

        // player faces the direction it is moving to (except axis y)
        Vector3 vel = rig.velocity;
        vel.y = 0;

        if(vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        // player jumps with the space key (only if it's back on the ground)
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(transform.position.y <= -5)
        {
            GameOver();
        }
    }

    // condition to check if the player has touched the ground
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    // restarts the current scene
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SubtractHealth (int amount)
    {
        if (health > 0)
        {
            health -= amount;
            healthText.text = "Health: " + health.ToString();
        }
        else
            GameOver();
    }

    // adds to the player's coins
    public void TotalCoins (int amount)
    {   
        coins -= amount;
        coinsText.text = "Coins: " + coins.ToString();
    }
}
