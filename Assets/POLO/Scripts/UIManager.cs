using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Handles the showing and hiding of UI screens.
/// TODO: Make this a singleton [NV 02-Oct-23]
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private List<UIScreen> m_Screens = new List<UIScreen>();
    [SerializeField] private GameObject m_UICanvas;
    public List<UIScreen> Screens => m_Screens;

    private UIScreen m_CurrentScreen;
    
    public T Get<T>() where T : UIScreen
    {
        for (int i = 0; i < m_Screens.Count; i++)
        {
            if (m_Screens[i].TryGetComponent(out T screen))
            {
                return screen;
            }
        }
        return null;
    }

    public void Show(UIScreen screen)
    {
        if (m_CurrentScreen != screen)
        {
            if (m_CurrentScreen != null)
            {
                Hide(m_CurrentScreen);
            }
        }
        
        screen.gameObject.SetActive(true);
        m_CurrentScreen = screen;
    }

    public void Hide(UIScreen screen)
    {
        screen.gameObject.SetActive(false);

        if (m_CurrentScreen == screen)
        {
            m_CurrentScreen = null;
        }
    }

    public void HideAll()
    {
        HideAllScreens();
        m_UICanvas.SetActive(false);
    }
    
    public void HideAllScreens()
    {
        foreach (UIScreen screen in m_Screens)
        {
            screen.gameObject.SetActive(false);
        }
    }
}
