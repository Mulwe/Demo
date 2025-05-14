using Unity.VisualScripting;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField] float _velocity = 10.0f;
    private Transform _transform;
    private Rigidbody _rb;

    private void Start()
    {
        _transform = transform;
        _transform.gameObject.tag = "Player";
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
        {
            _rb = this.AddComponent<Rigidbody>();
            _rb.useGravity = false;
            _rb.constraints |= RigidbodyConstraints.FreezePositionY; //!
        }
    }

    private void Update()
    {
        ProccessInput(_velocity);
    }

    private void ProccessInput(float speed)
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, 0, z);
        float currentY = _rb.linearVelocity.y;

        if (direction != Vector3.zero)
        {
            var targetVelocity = direction.normalized * speed;
            targetVelocity.y = currentY;

            _rb.linearVelocity = Vector3.Lerp(_rb.linearVelocity, targetVelocity, 0.2f);
        }
        else
        {
            _rb.linearVelocity = new Vector3(0, currentY, 0);
        }

    }
}
