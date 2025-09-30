using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    Rigidbody2D _rb;
    Animator _animator;
    Collider2D _collider2D;

    [SerializeField] float speedX;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] Transform weaponPosition;
    [SerializeField] float fireRate;
    [SerializeField] AudioClip fireSound;
    [SerializeField] AudioClip explosionSound;
    float lastFire;
    bool isFiring = true;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.AddForceX(-speedX, ForceMode2D.Impulse);

        _animator = GetComponent<Animator>();

        _collider2D = GetComponentInChildren<Collider2D>();

        lastFire = Time.time;
    }

    void Update()
    {
        if (isFiring)
        {
            Fire();
        }
    }
    void Fire()
    {
        if (Time.time > lastFire + fireRate)
        {
            lastFire = Time.time;
            Instantiate(ammoPrefab, weaponPosition.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(fireSound, transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _animator.enabled = true;
        _collider2D.enabled = false;
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        Score.instance.AddPoint();
        Destroy(gameObject, 0.5f);
    }
}