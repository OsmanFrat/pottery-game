using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float hitDamage;
    [SerializeField] private Wood wood;
    private Rigidbody knifeRb;
    private Vector3 movementVector;
    private bool isMoving = false;
    void Start()
    {
        knifeRb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        isMoving = Input.GetMouseButton(0);

        if(isMoving)
        {
            movementVector = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f) * movementSpeed * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if(isMoving)
        {
            knifeRb.position += movementVector;
        }
    }

    private void OnCollisionStay(Collision collision) 
    {
        Coll coll = collision.collider.GetComponent<Coll>();
        if(coll != null)
        {
            coll.HitCollider(hitDamage);
            wood.Hit(coll.index, hitDamage);
        }
    }
}
