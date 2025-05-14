using TMPro;
using UnityEngine;

public class UIHitCounter : MonoBehaviour
{
    // реагирует на событие
    private int _count = 0;
    private TextMeshProUGUI textBox;
    private const string _string = "Count:";

    public int Count => _count;

    private bool _isUpdated;

    public void HandleUICountChanged()
    {
        _isUpdated = false;
    }

    private void Awake()
    {
        _isUpdated = true;
        textBox = transform.GetComponent<TextMeshProUGUI>();
        if (textBox != null)
        {
            textBox.color = Color.magenta;
            textBox.text = $"{_string} {_count}";
        }
    }

    private void Update()
    {
        if (!_isUpdated && textBox != null)
        {
            _count++;
            textBox.text = $"{_string} {_count}";
            _isUpdated = true;
        }
    }
}
