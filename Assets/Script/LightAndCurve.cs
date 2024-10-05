using UnityEngine;

public class LightAndCurve : MonoBehaviour
{
    [Header("��������� �����")]
    [SerializeField] private Light lightSource;

    [Header("��������� ������ ��������")]
    [SerializeField] private AnimationCurve brightnessCurve;

    [Header("��������� �����������������")]
    [SerializeField] private float duration = 5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        float t = timer / duration;

        if (t > 1)
        {
            timer = 0f;
            t = 0f;
        }

        lightSource.intensity = brightnessCurve.Evaluate(t);
        MoveObject(t);
    }

    void MoveObject(float t)
    {
        Vector3 position = new Vector3(t * 10f - 5f, Mathf.Sin(t * Mathf.PI * 2) * 2, 0);
        transform.position = position;
    }
}
