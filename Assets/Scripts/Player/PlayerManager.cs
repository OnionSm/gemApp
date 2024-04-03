using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager: OnionBehaviour
{
    [SerializeField] public float model_scale_x = 5f;
    [SerializeField] public float player_direction = 1f;
    [SerializeField] public static PlayerManager Instance;
    [SerializeField] public List<GameObject> game_object;
    [SerializeField] public string current_animation;
    [SerializeField] public bool is_using_skill = false;
    private void Awake()
    {
        if (PlayerManager.Instance == null)
        {
            PlayerManager.Instance = this;
        }
        //this below code is used for print all name of playermanager child object

        /*GameObject playerManager = GameObject.Find("PlayerManager");
        Transform[] children = playerManager.GetComponentsInChildren<Transform>();
        game_object = new List<GameObject>();

        foreach (Transform child in children)
        {
           
            if (child.gameObject != playerManager)
            {
                game_object.Add(child.gameObject);
            }
        }
        foreach (GameObject obj in game_object)
        {
            Debug.Log(obj.name);
        }*/
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void RotatePlayer(float value)
    {
        Vector3 new_scale = new Vector3(value * model_scale_x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        gameObject.transform.localScale = new_scale;
    }
}
