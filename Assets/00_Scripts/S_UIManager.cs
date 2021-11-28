using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_UIManager : MonoBehaviour
{
    [SerializeField] SO_Object so_Object;
    [SerializeField] SO_Player so_player;
    [SerializeField] GameObject UI_MenuPanel;
    [SerializeField] Text UI_SpeedText;
    public bool Menuactive;

    public void MenuPanel(bool _isOpen)
    {
        if(_isOpen)
        {
            UI_MenuPanel.SetActive(true);
            so_Object.setEnabled(true);
            so_player.setMove(false);
        }
        else
        {
            UI_MenuPanel.SetActive(false);
            so_Object.setEnabled(false);
        }
        Menuactive = _isOpen;
    }

    public void SpeedText(float _speed)
    {
        UI_SpeedText.text = _speed.ToString();
    }
}
