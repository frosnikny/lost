using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header ("Parameters")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private string playerTag;
    [SerializeField] private float movingSpeed;

    private void Awake(){

        if (this.playerTag == "")
        {
            this.playerTag = "Player";
        }

        if (this.playerTransform == null)
        {
            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
        }

        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x, y = this.playerTransform.position.y, z = this.playerTransform.position.z-10
        };

    }

    private void Update(){
        if (this.playerTransform) {
            Vector3 target = new Vector3() {
                x = this.playerTransform.position.x, y = this.playerTransform.position.y, z = this.playerTransform.position.z-10
            };
        
        Vector3 pos = Vector3.Lerp(a:this.transform.position, b:target, t: this.movingSpeed * Time.deltaTime);
        this.transform.position = pos;
        }
    }
}
