using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;



public class PlayerMovement : MonoBehaviour
{

    bool alive = true;
    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    public float speedIncreasePerPoint = 0.1f;
    [SerializeField] float jumpForce = 600f;
    [SerializeField] LayerMask groundMask;
    public GameObject RestartButton;
    public GameObject QuitButton;
    public Animator animator;
    public GameObject bgMusic;
    private AudioSource audioSource;
    
    private void Awake(){
        RestartButton.SetActive(false);
        QuitButton.SetActive(false);
        audioSource = bgMusic.GetComponent<AudioSource>();
    }
    private void FixedUpdate(){
        if(!alive){
            return;
        }
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * 12 * Time.fixedDeltaTime * 2;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(transform.position.y < -5){
            Die();
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            Jump();
        } 
    }
    public void Die(){
        alive = false;
        animator.SetBool("Alive", false);
        RestartButton.SetActive(true);
        QuitButton.SetActive(true);
        audioSource.Stop();
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump(){
        //float height = GetComponent<Collider>().bounds.size.y;
        bool isInGround = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, 0.2f, groundMask);
        if(isInGround){         
            rb.AddForce(Vector3.up * jumpForce);         
        } 
    }
    
}
