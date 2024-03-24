using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CheatController : MonoBehaviour
{

    [SerializeField] private float _inputTimeToLive;
    [SerializeField] private Cheat[] _cheats;

    private string _currentInputValue;

    private float _inputTime;


    private void Awake()
    {
        Keyboard.current.onTextInput += OnTextInput;
    }

    private void Update()
    {
        if (_inputTime < 0)
        {
            _currentInputValue = string.Empty;
        }
        else
        {
            _inputTime -= Time.deltaTime;
        }
    }

    private void OnTextInput(char inputChar)
    {
        _currentInputValue += inputChar;
        _inputTime = _inputTimeToLive;
        FindCheat(_currentInputValue);
    }

    private void FindCheat(string value)
    {
        foreach (var cheat in _cheats)
        {
            if (value.Contains(cheat.name))
            {
                cheat.Action?.Invoke();
                return;
            }
        }
    }
}

[Serializable]
class Cheat
{
    public string name;
    public UnityEvent Action;
}
