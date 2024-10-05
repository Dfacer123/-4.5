using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Настройки движения")]
    [Tooltip("Скорость движения врага (положительное значение).")]
    [Range(0, 10)]
    [SerializeField] private float moveSpeed = 1f;

    [Tooltip("Начальное направление движения (вправо - true, влево - false).")]
    [SerializeField] private bool startDirectionRight = true;

    [Space(10)]
    [Header("Настройки респауна")]
    [Tooltip("Точка респауна игрока при столкновении с врагом.")]
    [SerializeField] private Transform respawnPoint;

    [Space(10)]
    [Header("Компоненты")]
    [Tooltip("Компонент Rigidbody2D для врага.")]
    [SerializeField] private Rigidbody2D enemyRigidbody;

    [HideInInspector]
    private bool isGoingRight;

    private void Start()
    {
        isGoingRight = startDirectionRight;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float movement = isGoingRight ? moveSpeed : -moveSpeed;
        enemyRigidbody.velocity = new Vector2(movement, enemyRigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Player"))
        {
            collisionInfo.gameObject.transform.position = respawnPoint.position;
        }

        if (collisionInfo.gameObject.CompareTag("Wall"))
        {
            isGoingRight = !isGoingRight;
        }
    }
}
