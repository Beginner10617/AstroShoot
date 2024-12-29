using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("bullets"))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<FollowMouse>().GameOver();
        }
    }
}
