using UnityEngine;

class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public bool disabled = false;
    public Transform destination;
    
    private Animator anim;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (destination != null) {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destination.position,
                speed * Time.deltaTime
            );
            
            Vector3 direction = (destination.position - transform.position).normalized;
            if (direction.x > 0) {
                sr.flipX = false;
            } else if (direction.x < 0) {
                sr.flipX = true;
            }
            
            anim.SetFloat("Speed", 1);
            if (transform.position == target.position) {
                destination = null;
                anim.SetFloat("Speed", 0);
            }
            return;
        }
        
        if (!disabled) {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
    
            anim.SetFloat("Speed", moveX == 0 && moveY == 0 ? 0 : 1);
            if (moveX > 0)
            {
                sr.flipX = false;
            }
            else if (moveX < 0)
            {
                sr.flipX = true;
            }
    
            Vector3 move = transform.right * moveX + transform.forward * moveY;
            transform.Translate(move * speed * Time.deltaTime);
        }
    }
    
    public void Enable() {
        disabled = false;
    }
    
    public void Disable() {
        disabled = true;
    }
}
