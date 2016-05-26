using UnityEngine;
using System.Collections;

public class Paralaxxing : MonoBehaviour {

    public Transform[] backgrounds;
    public float smoothihng = 1.0f;

    private float[] parallexScales; 
    private Transform cam;
    private Vector3 previousCamPos; 
    
    void Awake()
    {
        cam = Camera.main.transform; 
    }
     
	
	void Start () {
        previousCamPos = cam.position;

        parallexScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
            parallexScales[i] = backgrounds[i].position.z * -1; 
	}
	
	void Update () {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallexScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, Time.deltaTime); 
        }

        previousCamPos = cam.position; 
    }
}
