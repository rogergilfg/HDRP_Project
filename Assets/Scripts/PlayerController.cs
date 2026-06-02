using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{

    public InputActionReference action;
    private bool pasosRepro;
    [SerializeField] private float iniciarPasos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pasosRepro == false)
        {

            Vector2 input = action.action.ReadValue<Vector2>();

            if(input.x >= iniciarPasos || input.x <= -iniciarPasos || input.y >= iniciarPasos || input.y <= -iniciarPasos)
            {
                pasosRepro = true;
                Debug.Log("Reproducir pasos");
                AudioManager.instance.PlaySteps(0.3f);
            }
        }
        else
        {
            Vector2 input = action.action.ReadValue<Vector2>();

            if (input.x >= -iniciarPasos && input.x <= iniciarPasos && input.y >= -iniciarPasos && input.y <= iniciarPasos)
            {
                AudioManager.instance.StopSteps();
                pasosRepro = false;
            }
        }
    }
}
