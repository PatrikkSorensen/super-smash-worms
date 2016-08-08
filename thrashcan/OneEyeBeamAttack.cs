using UnityEngine;
using System.Collections;
using DG.Tweening; 

public class OneEyeBeamAttack : MonoBehaviour {

	public SpriteRenderer innerEye;
	public SpriteRenderer outerEye;
    public Transform player;
    public Transform beamStart;
    public GameObject beamProjectile;

    public float beamStartWidth, beamEndWidth, narrowSpeed;
    public float fireRate; 

    private Animator m_anim;

    private Color m_startInner;
    private Color m_startOuter;
    private bool firing, empowering, recovering; 

    void Update()
    {
        if (Input.GetKey(KeyCode.X)) ChargeEyePower();
        if (Input.GetKey(KeyCode.Y)) RecoverPower();
        //if (Input.GetKey(KeyCode.C) && !firing) StartCoroutine(StartBeam());
    }


    void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_startInner = innerEye.color;
        m_startOuter = innerEye.color;  
    }

    public void ChargeEyePower()
    {
        innerEye.material.DOColor(Color.black, 2.0f);
        outerEye.material.DOColor(Color.red, 2.0f); 
    }
    
    public void RecoverPower()
    {
        innerEye.material.DOColor(m_startInner, 2.0f);
        outerEye.material.DOColor(m_startOuter, 2.0f);
    }

    public void FireBeam()
    {
        if(!firing)
            StartCoroutine(StartBeam()); 
    }

    private IEnumerator StartBeam ()
    {
        firing = true; 

        GameObject bp = Instantiate(beamProjectile);
        bp.GetComponent<EyeBeamProjectile>().Instantiate(beamStart, player, beamStartWidth, beamEndWidth, narrowSpeed);

        yield return new WaitForSeconds(fireRate); 
        firing = false; 
    }
}
