using System;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public event Action Disabled;

    private void OnDisable()
    {
        Disabled?.Invoke();
    }
}
