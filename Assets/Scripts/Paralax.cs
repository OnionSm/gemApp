using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform main_camera;
    [SerializeField] private Vector3 last_camera_position;
    [SerializeField] private Vector2 paralax_mult;
    // Start is called before the first frame update
    void Start()
    {
        LoadComponent();
    }
    private void LoadComponent()
    {
        main_camera = Camera.main.transform;
        paralax_mult = new Vector2(0.9f, 0.8f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector3 delta_movement = main_camera.position - last_camera_position;
        transform.position += new Vector3(delta_movement.x * paralax_mult.x, delta_movement.y * paralax_mult.y, 0);
        last_camera_position = main_camera.position;
    }
}
