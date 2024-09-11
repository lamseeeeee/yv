using UnityEngine;
using UnityEngine.UI; // Required for UI elements
using System.Collections; // Required for coroutines

public class Target : MonoBehaviour
{
    public static int score = 0; // Player's total score
    public int points = 5; // Points for hitting the target

    public Text scoreText; // Reference to the UI Text that shows the score
    public Text wellDoneText; // Reference to the "Well Done" UI Text

    void Start()
    {
        UpdateScoreText();
        wellDoneText.gameObject.SetActive(false); // Ensure "Well Done" message is hidden initially
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object hitting the target is a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Add 5 points
            score += points;

            // Update the score text
            UpdateScoreText();

            // Check if score has reached 50
            if (score >= 50)
            {
                StartCoroutine(DisplayWellDoneMessage());
            }

            // Destroy the bullet
            Destroy(collision.gameObject);

            // Optionally move the target to a new position
            ChangePosition();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Update the score display
    }

    void ChangePosition()
    {
        // Generate random positions for the target
        float randomX = Random.Range(-10f, 10f);
        float randomY = Random.Range(1f, 5f);
        float randomZ = Random.Range(-10f, 10f);

        // Move the target to the new random position
        transform.position = new Vector3(randomX, randomY, randomZ);
    }

    // Coroutine to display the "Well Done" message for 3 seconds
    IEnumerator DisplayWellDoneMessage()
    {
        wellDoneText.gameObject.SetActive(true); // Show the message
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        wellDoneText.gameObject.SetActive(false); // Hide the message after 3 seconds
    }
}
