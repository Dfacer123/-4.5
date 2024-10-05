using UnityEngine;

public class Trigger : MonoBehaviour
{
    [Header("Настройки респауна")]
    [Tooltip("Точка респауна для игрока.")]
    [SerializeField] private Transform respawnPoint;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Player"))
        {
            collisionInfo.gameObject.transform.position = respawnPoint.position;
        }
    }
}
