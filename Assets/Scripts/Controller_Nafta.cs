using UnityEngine;

public class Controller_Nafta : MonoBehaviour
{
    public static float naftaVelocity;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(new Vector3(-naftaVelocity, 0, 0), ForceMode.Force); //Controlar la velocidad con la nafta
        OutOfBounds();
    }

    public void OutOfBounds()
    {
        //Destruir objetos que se van fuera de la cam
        if (this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {   //Agarrar la nafta
        if (collision.gameObject.CompareTag("Player")) 
        {
            Destroy(this.gameObject);
            Controller_Hud.timeUntilLose += 20;
        }

    }
}
