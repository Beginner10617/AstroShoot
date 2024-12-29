using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player

    private Vector3 moveDirection; // Stores the player's movement direction

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down Arrow

        moveDirection = new Vector3(moveX, moveY, 0).normalized;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
