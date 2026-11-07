using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialogueInputController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputField;
    [SerializeField] private RawImage rt;
    [SerializeField] private float inputDelay = .2f;

    private bool isEnabled = false;
    private int currentLetterIndex = 0;
    private string textContent = "";
    private float currentDelay = 0f;
    private bool isAnimating = false;

    public event Action OnTypingFinish;

    private void Start()
    {
        inputField.text = "";
    }

    public void Setup(string text)
    {
        currentLetterIndex = 0;
        inputField.text = "";
        textContent = text;
        isEnabled = true;
    }

    private void FinishTyping()
    {
        inputField.text = "";
        isEnabled = false;
        OnTypingFinish?.Invoke();
    }

    private void Update()
    {
        if (!isEnabled) return;
        currentDelay -= Time.deltaTime;

        if (currentLetterIndex == textContent.Length)
        {
            if (Keyboard.current.enterKey.wasPressedThisFrame)
                FinishTyping();
            else if (Keyboard.current.anyKey.isPressed && !isAnimating)
            {
                isAnimating = true;
                rt.DOColor(Color.darkRed, .05f).OnComplete(() =>
                {
                    rt.color = Color.white;
                    isAnimating = false;
                });
            }

        }
        else if (Keyboard.current.anyKey.isPressed && !Keyboard.current.enterKey.isPressed && currentDelay <= 0f)
        {
            inputField.text += textContent[currentLetterIndex++];
            currentDelay = inputDelay;
        }
    }
}