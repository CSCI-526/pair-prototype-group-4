using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform arrowTransform;
    public Rigidbody2D rb;
    public float bombSpeed = 10;
    public float minPlayerSpeed = 5, maxPlayerSpeed = 10;
    public int maxBombsInAir = 2;
    private int _bombsUsedInAir = 0;
    private bool _isGrounded = false;
    public LayerMask groundLayer;

    public GameObject bombPrefab;
    public GameObject GameOverScreen;
    public GameObject WinScreen;

    Vector2 _direction = new(-1, 0);
    Bomb _spawnedBomb;

    public static Player instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnDestroy()
    {
        instance = null;
    }

    void Update()
    {
        Vector2 aimDirection;
        aimDirection.x = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) + (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0);
        aimDirection.y = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) + (Input.GetKey(KeyCode.DownArrow) ? -1 : 0);

        if (aimDirection != Vector2.zero)
        {
            _direction = aimDirection;
            arrowTransform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - 90);
            arrowTransform.position = new Vector3(transform.position.x + _direction.x * 0.1f, transform.position.y + _direction.y * 0.1f, arrowTransform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_spawnedBomb == null)
            {
                if (_isGrounded || _bombsUsedInAir < maxBombsInAir)
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, _direction, 1.5f, groundLayer);
                    if (hit.collider != null)
                    {
                        LaunchPlayer(-_direction, 1f);
                    }
                    else
                    {
                        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
                        bomb.GetComponent<Rigidbody2D>().AddForce(_direction * bombSpeed, ForceMode2D.Impulse);
                        _spawnedBomb = bomb.GetComponent<Bomb>();
                        _spawnedBomb.player = this;
                    }

                    if (!_isGrounded)
                    {
                        _bombsUsedInAir++;
                    }
                }
            }
            else
            {
                _spawnedBomb.Explode();
            }
        }
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundLayer);
        _isGrounded = hit.collider != null;
        if (_isGrounded)
        {
            _bombsUsedInAir = 0;
        }
    }

    public void LaunchPlayer(Vector2 direction, float explosionStrength)
    {
        rb.velocity = direction * Mathf.Lerp(minPlayerSpeed, maxPlayerSpeed, explosionStrength);
    }

    public void Die()
    {
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
        Destroy(gameObject);
    }

    public void Win()
    {
        Time.timeScale = 0;
        WinScreen.SetActive(true);
    }
}
