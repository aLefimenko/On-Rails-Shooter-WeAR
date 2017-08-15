using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private float range = 3000f;

    public float[] coordinats = new float[3];

    [SerializeField]
    private int currrentSpeed = 500;

    [SerializeField]
    private GameObject[] screenOfLife = new GameObject[4];

    [SerializeField]
    private Sprite[] textureOfScreens = new Sprite[2];

    [SerializeField]
    private GameObject _prefabOfHit;

    [SerializeField]
    private GameObject _glass;

    [SerializeField]
    private Sprite[] glasses = new Sprite[4];

    [SerializeField]
    private GameObject[] _glassPlanes = new GameObject[4];

    private int _life = 4;

    [SerializeField]
    private GameObject _spaceShip;

    private GameObject _player;

    private AudioSource _fireSound;

    [SerializeField]
    private GameObject _lineHit;

    [SerializeField]
    private GameObject _linehit2;

    private float[] _masForClampSpace = new float[10];

    private float[] _masForClampSpacex = new float[10];

    private int i;

    [SerializeField]
    private GameObject _reset;

    [SerializeField]
    private GameObject _exit;

    [SerializeField]
    private GameObject _createOnStart;

    [SerializeField]
    private Image _pric;

    private bool isClicked = false;

    void Start()
    {
        ResetLife();
        _fireSound = GetComponent<AudioSource>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _spaceShip = GameObject.FindGameObjectWithTag("spaceship");
    }

    public void LifeMinus()
    {
        _life -= 1;
        screenOfLife[_life].GetComponent<MeshRenderer>().material.SetTexture("_MainTex", textureOfScreens[1].texture);
        _glass.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", glasses[_life].texture);
        if(_life==0)
        {
            if(_reset.activeSelf==false)
            {
                _reset.SetActive(true);
                _exit.SetActive(true);
                _createOnStart.GetComponent<InstAsteroids>().PoolObjects();
                _createOnStart.SetActive(false);
                gameObject.transform.position = Vector3.zero;
                _spaceShip.transform.localRotation = new Quaternion(gameObject.transform.localRotation.x, gameObject.transform.localRotation.y + 180f, gameObject.transform.localRotation.z, gameObject.transform.localRotation.w);
                gameObject.GetComponent<Controller>().enabled = false;
                
            }
        }
    }

    public void ResetLife()
    {
        _life = 4;
        _glass.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", glasses[3].texture);
        for(int i=0;i<screenOfLife.Length;i++)
        {
            screenOfLife[i].GetComponent<MeshRenderer>().material.SetTexture("_MainTex", textureOfScreens[0].texture);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            _fireSound.Play();
            _lineHit.SetActive(true);
            _linehit2.SetActive(true);
            _fireSound.Play();
            StartCoroutine(LineObFire());
        }
        transform.Translate(Vector3.forward * Time.deltaTime * currrentSpeed);
        /*if (BaseSDK.GetButton(2))
        {
                _fireSound.Play();
                _lineHit.SetActive(true);
                _linehit2.SetActive(true);
                RaycastHit raycastHit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, range))
                {
                    TargetHit component = raycastHit.transform.GetComponent<TargetHit>();
                    if (component != null)
                    {
                        Destroy(Instantiate(_prefabOfHit, raycastHit.transform.position, Quaternion.identity), 1f);
                        component.gameObject.GetComponent<AudioSource>().Play();
                        component.gameObject.SetActive(false);
                        component.gameObject.transform.localScale = Vector3.zero;
                        component.transform.position = _player.transform.position + (_player.transform.position - component.transform.position);
                        component.gameObject.SetActive(true);
                    }
                }
                StartCoroutine(LineObFire());
        }*/
        RaycastHit raycastHit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, range))
        {
            if (BaseSDK.GetButton(2)&&isClicked==false)
            {
                isClicked = true;
                _fireSound.Play();
                _lineHit.SetActive(true);
                _linehit2.SetActive(true);
                StartCoroutine(LineObFire());
                TargetHit component = raycastHit.transform.GetComponent<TargetHit>();
                if (component != null)
                {
                    Destroy(Instantiate(_prefabOfHit, raycastHit.transform.position, Quaternion.identity), 1f);
                    component.gameObject.SetActive(false);
                    component.gameObject.transform.localScale = Vector3.zero;
                    component.transform.position = _player.transform.position + (_player.transform.position - component.transform.position);
                    component.gameObject.SetActive(true);
                }
            }
            TargetHit componen = raycastHit.transform.GetComponent<TargetHit>();
            if (componen != null)
            {
                if (_pric.color == Color.white)
                {
                    _pric.color = Color.red;
                }
            }
        }
        else
        {
            if (BaseSDK.GetButton(2)&&isClicked==false)
            {
                isClicked = true;
                _fireSound.Play();
                _lineHit.SetActive(true);
                _linehit2.SetActive(true);
                StartCoroutine(LineObFire());
            }
            if (_pric.color == Color.red)
            {
                _pric.color = Color.white;
            }
        }

        /*if(BaseSDK.GetButton(1))
        {
            Time.timeScale = 0;
        }*/
        coordinats = BaseSDK.GetAxel();
        Vector3 vector = new Vector3(coordinats[0], coordinats[1], coordinats[2]) * 200f;
        transform.Rotate(new Vector3(vector.x*2f, vector.z, -vector.z) * 0.01f);
        _spaceShip.transform.localRotation = new Quaternion(gameObject.transform.localRotation.x + GetAngleRotate(), gameObject.transform.localRotation.y + 180f, gameObject.transform.localRotation.z + GetAngleRotateX(), gameObject.transform.localRotation.w);
        transform.Translate(new Vector3(vector.x*1.2f, vector.z, 0f) * 0.007f);
        
    }


    private IEnumerator LineObFire()
    {
        _lineHit.SetActive(true);
        _linehit2.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _lineHit.SetActive(false);
        _linehit2.SetActive(false);
        isClicked = false;
    }

    private float GetAngleRotate()
    {
        if (i < _masForClampSpace.Length)
        {
            _masForClampSpace[i] = coordinats[2] * 50f;
            i++;
        }
        else
        {
            i = 0;
        }
        float num = 0f;
        for (int i = 0; i < _masForClampSpace.Length; i++)
        {
            num += _masForClampSpace[i];
        }
        return num / _masForClampSpace.Length;
    }

    private float GetAngleRotateX()
    {
        if (i < _masForClampSpace.Length)
        {
            _masForClampSpacex[i] = coordinats[0] * 5f;
            i++;
        }
        else
        {
            i = 0;
        }
        float num = 0f;
        for (int i = 0; i < _masForClampSpacex.Length; i++)
        {
            num += _masForClampSpacex[i];
        }
        return num / _masForClampSpacex.Length;
    }
}
