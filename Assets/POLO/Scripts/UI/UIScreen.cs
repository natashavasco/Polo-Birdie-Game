using System;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    [SerializeField] private GameObject m_PreviousScreen;
    public event Action<UIScreen> OnReturnButtonPressed;
    
    public void OnReturnPress()
    {
        OnReturnButtonPressed?.Invoke(this);
    }

    public virtual UIScreen GetPreviousScreen()
    {
        if (m_PreviousScreen != null)
        {
            return this;
        }
        return null;
    }
}
