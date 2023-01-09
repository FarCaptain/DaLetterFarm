using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterHistoryTicket : MonoBehaviour
{
    [SerializeField] private Timer surviveTimer;
    [SerializeField] private float time = 2f;

    private void Start()
    {
        surviveTimer.ResetTimer(time, true);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
