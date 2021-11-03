using TMPro;
using UnityEngine;

public class TaskTextUpdater : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;    

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTaskText(string task)
    {
        if (_textMesh == null) return;

        _textMesh.text = $"Find {task}";
    }
}
