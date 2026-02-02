using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private int maxLines = 6;
    [SerializeField] private float lineLifetime = 3f; // seconds each line stays

    private readonly Queue<string> lines = new Queue<string>();
    private Coroutine clearRoutine;

    private void Awake()
    {
        if (text == null) text = GetComponent<TMP_Text>();
        text.text = "";
    }

    public void Show(string message)
    {
        if (string.IsNullOrWhiteSpace(message)) return;

        // Add line
        lines.Enqueue(message);

        // Keep last N lines
        while (lines.Count > maxLines)
            lines.Dequeue();

        // Render
        text.text = string.Join("\n", lines);

        // Restart the timer that clears everything (optional behavior)
        if (clearRoutine != null) StopCoroutine(clearRoutine);
        clearRoutine = StartCoroutine(ClearAfterDelay());
    }

    private IEnumerator ClearAfterDelay()
    {
        yield return new WaitForSeconds(lineLifetime);

        lines.Clear();
        text.text = "";
        clearRoutine = null;
    }
}