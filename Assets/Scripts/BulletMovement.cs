using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float screenMax = 5f;
    public float speed = 10f;

    void Start()
    {
        
    }

    void Update()
    {

        
            if (transform.position.y > screenMax)
            {
                transform.position = new Vector2(13f, 0f);
                this.gameObject.SetActive(false);
        }
            else
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            }
        

    }
}
