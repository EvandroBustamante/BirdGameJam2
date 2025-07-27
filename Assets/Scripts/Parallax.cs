using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;

    private float myWidth;

    private void Awake()
    {
        myWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        Debug.Log(myWidth);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x -speed * Time.deltaTime, 0, 0);

        if(transform.position.x + myWidth/2 <= -myWidth/2)
        {
            //Debug.Log("parallax");
            transform.position = new Vector3(+myWidth, 0, 0);
        }
    }
}
