using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10;
    private float initialSize;
    private int i = 0;
    private bool floored;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialSize = rb.transform.localScale.y;
    }

    void FixedUpdate()
    {
        GetInput();
    }

    private void GetInput()
    {
        Jump();
        Duck();
    }

    private void Jump()
    {
        
            if (Input.GetKey(KeyCode.W)) //Si esta en el piso + Toca W
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // +Fuerza en Y
            }
    }

    private void Duck()
    {
        if (floored)//Si esta en el piso
        {
            if (Input.GetKey(KeyCode.S))//Si esta en el piso + Toco "S"
            {
                if (i == 0)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z); //Hacer al rb la mitad de su cuerpo
                    i++;
                }
            }
            else //Si no toco S
            {
                if (rb.transform.localScale.y != initialSize) //Regresalo a su forma inicial
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z);
                    i = 0;
                }
            }
        }
        else // Si no esta en el piso
        {
            if (Input.GetKeyDown(KeyCode.S))// Dar fuerza hacia abajo en el aire
            {
                rb.AddForce(new Vector3(0, -jumpForce * 5, 0), ForceMode.Impulse) ;
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))// Enemigo mata a jugador
        {
            Destroy(this.gameObject);
            Controller_Hud.gameOver = true;
        }

        if (collision.gameObject.CompareTag("Floor"))// Piso da la habilidad para saltar
        {
            floored = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))// Si sale del piso entonces no puede saltar mas
        {
            floored = false;
        }
    }
}
