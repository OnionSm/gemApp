using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private float witch_scale_x;
    private float witch_scale_y;
    

    // Start is called before the first frame update
    void Start()
    {
        this.LoadComponent();
    }

    // Update is called once per frame
    void Update()
    {
        this.LookPlayer();
    }
    protected void LookPlayer()
    {
        Vector3 player_pos = PlayerManager.Instance.transform.position;
        if (player_pos.x >= transform.position.x)
        {
            WitchManager.Instance.SetDirect(1f);
            transform.localScale = new Vector3(witch_scale_x, witch_scale_y, 1f);
        }
        else
        {
            WitchManager.Instance.SetDirect(-1f);
            transform.localScale = new Vector3(-witch_scale_x, witch_scale_y, 1f);
        }
    }
    private void LoadComponent()
    {
        this.witch_scale_x = 1.5f;
        this.witch_scale_y = 1.5f;
    }
}
