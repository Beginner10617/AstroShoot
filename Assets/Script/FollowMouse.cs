using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowMouse : MonoBehaviour
{
    Vector3 mouseWorldPosition, mouseScreenPosition;
    [SerializeField] Transform origin;
    public int bullets = 5;
    float theta;
    [SerializeField] Transform offset;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public List<GameObject> todeactivate;
    public GameObject LoseScreen;
    public TextMeshProUGUI AmmoText;
    public void GameOver()
    {
        LoseScreen.SetActive(true);
        foreach(GameObject obj in todeactivate)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        AmmoText.text = "Shells: " + bullets;
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane));
        theta = Mathf.Atan2(mouseWorldPosition.y - origin.position.y, mouseWorldPosition.x - origin.position.x);
        transform.rotation = Quaternion.Euler(0, 0, theta * Mathf.Rad2Deg);

        if(Input.GetMouseButtonDown(0) && bullets > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, offset.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)) * bulletSpeed;
            bullets--;
        }
    }
}
