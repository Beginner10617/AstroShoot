using UnityEngine;
using TMPro;

public class Collect : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            score++;
            GetComponent<FollowMouse>().bullets += 4;
            Destroy(other.gameObject);
        }
    }
    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
