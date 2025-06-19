using UnityEngine;

public class Sparkle : MonoBehaviour
{
    [SerializeField] private LightLogic _gameLogic;
    public float floatSpeed = 2f;
    public float floatHeight = 0.1f;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        float newY = _startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gameLogic.addLight(gameObject);
    }
}
