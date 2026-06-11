using UnityEngine;

// Головний клас для роботи керування та анімацій персонажа
public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.5f;
    public float turnSpeed = 720f;
    public float gravity = -9.81f;
    public Animator anim;

    private CharacterController controller;
    private Vector3 velocity;
    private Transform cam;

    private float rotationVelocity;

    // Знаходження потрібних компонентів
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        // Зчитування вводу гравця
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Якщо натиснута кнопка вмикаєтсья анімція ходьби
        if (x != 0 || z != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        // Створення вектора напрямку руху зі стабільною швидкістю
        Vector3 inputDir = new Vector3(x, 0, z).normalized;


        if (inputDir.magnitude >= 0.1f)
        {
            // Вирахування кута, куди має повернутися персонаж, враховуючи кут повороту камери
            float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // Згладження кута для плавності повороту
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationVelocity, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // Застосування вирахуваного кута до моделі персонажа
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            // Рух персонажа в цьому напрямку
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}