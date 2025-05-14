using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TargetUI : MonoBehaviour
{
    //создает событие
    [Header("Text (TMP) field:")]
    [SerializeField] private UIHitCounter _uiHitCounter;
    private Collider _collider;

    private UnityEvent _OnCollisionTrigger;

    private void Awake()
    {
        this.transform.position = new Vector3(0, 0, 5);
        _collider = GetComponent<Collider>();
        if (_collider == null)
        {
            _collider = this.AddComponent<Collider>();
        }
        _OnCollisionTrigger = new UnityEvent();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"<color=green>Попадание!</color>");
            if (_uiHitCounter != null)
            {
                _uiHitCounter.HandleUICountChanged();
                _OnCollisionTrigger.Invoke();
            }
        }
    }

    //2nd variant
    private void CheckCollisions()
    {
        if (_collider != null)
        {
            Renderer r = GetComponent<Renderer>();
            if (r != null)
            {
                Vector3 size = r.bounds.size;
                var hits = Physics.OverlapBox(this.transform.position, size / 2);
                foreach (var who in hits)
                {
                    if (who != _collider)
                        Debug.Log($"Попадание!");
                }
            }
        }
    }


}


