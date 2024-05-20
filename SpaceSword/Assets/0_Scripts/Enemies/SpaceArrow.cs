using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceArrow : MonoBehaviour
{
    public float m_SideSpeed, m_SideLimit, m_SideRate, m_TripleRate, m_ArrowRate;
    private bool m_Side;
    public GameObject m_Arrow,
        m_TripleTurretLeft, m_TripleTurretRight, m_TripleBullet,
        m_SideTurretLeft, m_SideTurretRight, m_NormalBullet;
    public Animator m_Anim;

    //RingShine
    public Renderer m_TargetRenderer;
    public float IntensityTarget = 1.0f,
        LoadTime = 2.0f,
        initialEmissionIntensity;
    private Material ShineRingMaterial;
    private Color baseEmissionColor;
    void Start()
    {
        //InvokeRepeating("SideShot", 0, m_SideRate);
        //InvokeRepeating("TripleShot", 0, m_TripleRate);

        ShineRingMaterial = m_TargetRenderer.material;
        ShineRingMaterial.EnableKeyword("_EMISSION");
        Color initialEmission = ShineRingMaterial.GetColor("_EmissionColor");
        initialEmissionIntensity = Mathf.GammaToLinearSpace(initialEmission.maxColorComponent);
        baseEmissionColor = initialEmission / initialEmissionIntensity;
        InvokeRepeating("ArrowLaunch", 0, m_ArrowRate);
    }
    void Update()
    {
        if (m_Side)
        {
            transform.Translate(Vector3.left * m_SideSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * m_SideSpeed * Time.deltaTime);
        }

        if (transform.position.x >= m_SideLimit)
        {
            m_Side = true;
        }
        if (transform.position.x <= -m_SideLimit)
        {
            m_Side = false;
        }
    }
    public void ArrowLaunch()
    {
        StartCoroutine(ArrowLaunchment(IntensityTarget, LoadTime));
    }
    IEnumerator ArrowLaunchment(float targetIntensity, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / duration;

            float currentIntensity = Mathf.Lerp(initialEmissionIntensity, targetIntensity, t);

            Color currentEmissionColor = baseEmissionColor * Mathf.LinearToGammaSpace(currentIntensity);

            ShineRingMaterial.SetColor("_EmissionColor", currentEmissionColor);

            yield return null;
        }

        Color finalEmissionColor = baseEmissionColor * Mathf.LinearToGammaSpace(targetIntensity);
        ShineRingMaterial.SetColor("_EmissionColor", finalEmissionColor);

        m_Anim.Play("ArrowLaunch");

        Color noEmissionColor = baseEmissionColor * Mathf.LinearToGammaSpace(0f);
        ShineRingMaterial.SetColor("_EmissionColor", noEmissionColor);

        yield return new WaitForSeconds(m_Anim.GetCurrentAnimatorStateInfo(0).length);

        elapsedTime = 0f;

        float currentIntensityZero = 0f;

        Color currentEmissionColorZero = baseEmissionColor * Mathf.LinearToGammaSpace(currentIntensityZero);

        ShineRingMaterial.SetColor("_EmissionColor", currentEmissionColorZero);

        yield return null;
        Color initialEmissionColor = baseEmissionColor * Mathf.LinearToGammaSpace(initialEmissionIntensity);
        ShineRingMaterial.SetColor("_EmissionColor", initialEmissionColor);
    }
    public void TripleShot()
    {
        StartCoroutine("ThreeShoot");
    }
    IEnumerator ThreeShoot()
    {
        Instantiate(m_TripleBullet, m_TripleTurretLeft.transform.position, m_TripleTurretLeft.transform.rotation);
        Instantiate(m_TripleBullet, m_TripleTurretRight.transform.position, m_TripleTurretRight.transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(m_TripleBullet, m_TripleTurretLeft.transform.position, m_TripleTurretLeft.transform.rotation);
        Instantiate(m_TripleBullet, m_TripleTurretRight.transform.position, m_TripleTurretRight.transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(m_TripleBullet, m_TripleTurretLeft.transform.position, m_TripleTurretLeft.transform.rotation);
        Instantiate(m_TripleBullet, m_TripleTurretRight.transform.position, m_TripleTurretRight.transform.rotation);
    }
    public void SideShot()
    {
        Instantiate(m_TripleBullet, m_SideTurretLeft.transform.position, m_SideTurretLeft.transform.rotation);
        Instantiate(m_TripleBullet, m_SideTurretRight.transform.position, m_SideTurretRight.transform.rotation);
    }
}
