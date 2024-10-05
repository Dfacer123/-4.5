using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Настройки движения")]
    [Tooltip("Вектор движения игрока.")]
    [SerializeField] private Vector2 movementVector;

    [Tooltip("Скорость движения игрока.")]
    [Range(1, 20)]
    [SerializeField] private int speed = 5;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            movementVector.y = 2;
        }
        else
        {
            movementVector.y -= 0.1f;
        }

        CheckVerticalMovement();
        movementVector.x = Input.GetAxis("Horizontal");
        transform.Translate(movementVector * speed * Time.deltaTime);
    }

    void CheckVerticalMovement()
    {
        if (movementVector.y < 0)
        {
            movementVector.y = 0;
        }
    }
}
