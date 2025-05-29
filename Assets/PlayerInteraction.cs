using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject currentBreakable;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentBreakable != null)
        {
            animator.SetTrigger("Hit");
            
            Destroy(currentBreakable, 0.5f); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destructable"))
        {
            currentBreakable = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Destructable"))
        {
            if (other.gameObject == currentBreakable)
                currentBreakable = null;
        }
    }
}