using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D _rb;
    Animator _animator;
    Collider2D _collider2D;
    SpriteRenderer _spriteRenderer;

    [SerializeField] GameObject ammoPrefab;
    [SerializeField] Transform weaponPosition;
    [SerializeField] float playerSpeed;
    [SerializeField] Slider playerHPSlider;
    [SerializeField] float fireRate;
    [SerializeField] AudioClip laserSound;
    [SerializeField] AudioClip enemyHit;
    [SerializeField] AudioClip lastHitSound;
    float lastFire;
    bool isFiring;
    float xDir;
    float yDir;
    float playerHP;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider2D = GetComponentInChildren<Collider2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        lastFire = Time.time;
    }

    void Update()
    {
        if (isFiring)
        {
            Fire();
        }
    }

    void OnAttack(InputValue inputValue)
    {
        isFiring = inputValue.isPressed;
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnMove(InputValue inputValue)
    {
        xDir = inputValue.Get<Vector2>().x;
        yDir = inputValue.Get<Vector2>().y;
    }

    void Move()
    {
        _rb.linearVelocityX = xDir * playerSpeed * Time.deltaTime;
        _rb.linearVelocityY = yDir * playerSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(enemyHit, transform.position);
        playerHP += 0.2f;
        playerHPSlider.value = playerHP;
        if (playerHP >= 1)
        {
            _animator.enabled = true;
            _collider2D.enabled = false;         
            AudioSource.PlayClipAtPoint(lastHitSound, transform.position);

            Invoke("GameOver", 1.5f);
        }
    }

    void GameOver()
    {
        GameManager.Instance.SaveHighScore();
        SceneManager.LoadScene("GameOver");
    }

    void Fire()
    {
        if (Time.time > lastFire + fireRate)
        {
            lastFire = Time.time;
            Instantiate(ammoPrefab, weaponPosition.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(laserSound, transform.position);
        }
    }
}
