using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float jumpScareSpeed;
    private bool isJumpScaring = false;
    [SerializeField] private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isJumpScaring == true)
        {
            Vector3 direccion = (player.transform.position - transform.position).normalized;
            transform.position += direccion * jumpScareSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player tocado");
        }
            
    }

    public void JumpScare()
    {
        isJumpScaring = true;
    }

    
}
