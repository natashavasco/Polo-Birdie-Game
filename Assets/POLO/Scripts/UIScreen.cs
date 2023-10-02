using System;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    public event Action<UIScreen> OnReturnButtonPressed;
    
    public void OnReturnPress()
    {
        OnReturnButtonPressed?.Invoke(this);
    }
}
