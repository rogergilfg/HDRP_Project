using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;


    private Animator animator;
    public InputActionReference action;
    private bool pasosRepro;
    [SerializeField] private float iniciarPasos;
    [SerializeField] private GameObject monster;
    [SerializeField] private LayerMask pickLayer;
    [SerializeField] private GameObject black;
    [SerializeField] private TextMeshProUGUI final;
    [SerializeField] private GameObject enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
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

        Ray ray = new(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100f, Color.red);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, pickLayer))
        {
            if (hit.transform.tag == "Enemy")
            {
                EnemyController enemy = hit.transform.GetComponent<EnemyController>();
                enemy.JumpScare();
            }
        }

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Nota")
            {
                enemy.SetActive(true);
            }
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            Debug.Log("Enemy");
            black.SetActive(true);
            StartCoroutine(TextoFin());
            StartCoroutine(Close());
        }
    }

    IEnumerator TextoFin()
    {
        yield return new WaitForSeconds(3f);
        final.enabled = true;
    }
    IEnumerator Close()
    {
        yield return new WaitForSeconds(5f);
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    //UnityEditor.TransformWorldPlacementJSON:{"position":{"x":68.07,"y":4.02,"z":60.58},"rotation":{"x":0.0,"y":0.65,"z":0.0,"w":0.75},"scale":{"x":1.0,"y":1.0,"z":1.0}}
}
