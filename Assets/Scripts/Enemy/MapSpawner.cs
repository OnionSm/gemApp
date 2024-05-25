using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [SerializeField][Range(1f, 500f)] private float radius = 400f;
    [SerializeField] private Transform prefabs;
    private bool has_generate = false;
    [SerializeField] private LayerMask Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.Generate();
    }
    public void Generate()
    {
        if (has_generate == false)
        {
            Collider2D collisionPlayer = Physics2D.OverlapCircle(transform.position, radius, Player);
            if (collisionPlayer == true)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform childTransform = transform.GetChild(i);
                    Transform obj = Instantiate(prefabs);
                    obj.gameObject.SetActive(true);
                    obj.position = childTransform.position;
                }
                has_generate = true;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
