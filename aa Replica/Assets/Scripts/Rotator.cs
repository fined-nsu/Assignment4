using UnityEngine;

public class Rotator : MonoBehaviour
{
    public static float speed = 100f;

    private void Start()
    {
        speed = 100f;
        speed += PlayerPrefs.GetFloat("RotationSpeed");
        Debug.Log(Rotator.speed);
    }

    void Update ()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
