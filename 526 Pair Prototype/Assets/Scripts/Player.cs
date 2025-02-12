using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform arrowTransform;
    public Rigidbody2D rb;
    public float explosionSpeed = 10;

    Vector2 _direction = new(-1, 0);

    void Update()
    {
        _direction.x = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) + (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0);
        _direction.y = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) + (Input.GetKey(KeyCode.DownArrow) ? -1 : 0);

        if (_direction != Vector2.zero)
        {
            arrowTransform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - 90);
            arrowTransform.position = new Vector3(transform.position.x + _direction.x * 0.1f, transform.position.y + _direction.y * 0.1f, arrowTransform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(-_direction * explosionSpeed, ForceMode2D.Impulse);
        }
    }
}
