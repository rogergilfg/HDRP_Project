using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float jumpScareSpeed;
    private bool isJumpScaring = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isJumpScaring == true)
        {
            Vector3 direccion = (Camera.main.transform.position - transform.position).normalized;
            transform.position += direccion * jumpScareSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
        }
            
    }

    public void JumpScare()
    {
        isJumpScaring = true;
    }
}
