using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool isPinned = false;

    public static float speed = 100f;
    public Rigidbody2D rb;

    private void Start()
    {
        speed = 100f;
        speed += PlayerPrefs.GetFloat("PinSpeed");
        Debug.Log(Pin.speed);
    }

    private void Update()
    {
        if (!isPinned)
        rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Rotator")
        {
            transform.SetParent(col.transform);
            Score.PinCount++;
            isPinned = true;
        }
        else if (col.tag == "Pin")
        {
            Destroy(Spawner.clone);
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
