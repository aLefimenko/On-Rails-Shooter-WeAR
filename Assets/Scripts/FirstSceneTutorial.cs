using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

public class FirstSceneTutorial : MonoBehaviour {

    [SerializeField]
    private GameObject _StartTutorial;

    private GameObject _spriteStartTutorial;

    private bool isEnterStartTutor = false, isExitEnter = false;

    private Coroutine _cor;

    private AndroidJavaObject _activeContext;

    private AndroidJavaObject _pluginClass;

    private AndroidJavaClass _activeClass;

    private GameObject _playerControll;

    [SerializeField]
    private GameObject _great;

    [SerializeField]
    private GameObject _clickButton;

    [SerializeField]
    private Transform _spawn;

    [SerializeField]
    private Image left;

    [SerializeField]
    private Image right;

    [SerializeField]
    private Image forward;

    [SerializeField]
    private Image back;

    [SerializeField]
    private Sprite _spriteGreen;

    [SerializeField]
    private Sprite _spriteWhite;

    [SerializeField]
    private GameObject _pleaseRotate;
    [SerializeField]
    private GameObject _leftRight;
    [SerializeField]
    private GameObject _forwardBack;

    [SerializeField]
    private Image _pointer;

    [SerializeField]
    private GameObject _prefabOfFire;

    [SerializeField]
    private GameObject[] prefRotate = new GameObject[4];

    float _color = 1f;

    [SerializeField]
    private GameObject prefabOfHit;

    private bool isPool = false;

    private float[] coordinats = new float[3];
    private GameObject pref;
    private GameObject _linehit;
    private GameObject _linehit2;

    [SerializeField]
    private GameObject[] screens = new GameObject[4];

    private bool isReset = false;

    [SerializeField]
    private GameObject pressAnyButton;

    [SerializeField]
    private GameObject[] buttonMenu = new GameObject[2];

    [SerializeField]
    private GameObject _reset;

    [SerializeField]
    private GameObject _exit;


    private bool isReadyToMenu = false;

    private bool isInMenu = false;


    void Awake()
    {
        StartCoroutine(StartVR("Cardboard"));
        _linehit = GameObject.FindGameObjectWithTag("fire");
        _linehit2 = GameObject.FindGameObjectWithTag("fire2");
        _linehit.SetActive(false);
        _linehit2.SetActive(false);
        _playerControll = GameObject.FindGameObjectWithTag("Player");
        _spriteStartTutorial = GameObject.FindGameObjectWithTag("startTutor");
        for(int i=0;i<prefRotate.Length;i++)
        {
            prefRotate[i].SetActive(false);
        }
    }

    private IEnumerator StartVR(string newDevice)
    {
        VRSettings.LoadDeviceByName(newDevice);
        yield return null;
        VRSettings.enabled = true;
    }

    void Update()
    {

        if(BaseSDK.GetButton(1)&&isReadyToMenu==true)
        {
            if(isInMenu==false)
            {
                _reset.SetActive(true);
                _exit.SetActive(true);
                _StartTutorial.SetActive(false);
                _playerControll.GetComponent<Controller>().enabled = false;
                isInMenu = true;
                isReadyToMenu = false;
                StartCoroutine(SetMenu());
            }
            else
            {
                _reset.SetActive(false);
                _exit.SetActive(false);
                _StartTutorial.SetActive(true);
                _playerControll.GetComponent<Controller>().enabled = true;
                isInMenu = false;
                isReadyToMenu = false;
                StartCoroutine(SetMenu());
            }
        }

        if(isExitEnter)
        {
            ChangeStartTutorial(0,1);
        }
        else
        {
            UnchangeStartTutorial(0,1);
        }
        if(isReset)
        {
            ChangeStartTutorial(1,0);
        }
        else
        {
            UnchangeStartTutorial(1,0);
        }
        coordinats = BaseSDK.GetAxel();
        if (_pleaseRotate.activeSelf == true)
        {
            isReadyToMenu = false;
            isInMenu = false;
            for (int i = 0; i < prefRotate.Length; i++)
            {
                if (prefRotate[i].activeSelf == false)
                {
                    prefRotate[i].SetActive(true);
                }
            }
            if (left.sprite != _spriteGreen && coordinats[2] < 0f)
            {
                left.fillAmount = coordinats[2] * -1f;
                if(right.sprite==_spriteWhite)
                {
                    right.fillAmount = 0;
                }
            }
            if (left.fillAmount > 0.9f)
            {
                left.fillAmount = 1f;
                left.sprite = _spriteGreen;
            }
            if (right.sprite != _spriteGreen && coordinats[2] > 0f)
            {
                right.fillAmount = coordinats[2];
                if(left.sprite==_spriteWhite)
                {
                    left.fillAmount = 0;
                }
            }
            if (right.fillAmount > 0.9f)
            {
                right.fillAmount = 1f;
                right.sprite = _spriteGreen;
            }
            if (forward.sprite != _spriteGreen && coordinats[0] < 0f)
            {
                forward.fillAmount = coordinats[0]*-1f;
                if(back.sprite == _spriteWhite)
                {
                    back.fillAmount = 0;
                }
            }
            if (forward.fillAmount > 0.7f)
            {
                forward.fillAmount = 1f;
                forward.sprite = _spriteGreen;
            }
            if (back.sprite != _spriteGreen && coordinats[0] > 0f)
            {
                back.fillAmount = coordinats[0];
                if(forward.sprite == _spriteWhite)
                {
                    forward.fillAmount = 0;
                }
            }
            if (back.fillAmount > 0.7f)
            {
                back.fillAmount = 1f;
                back.sprite = _spriteGreen;
            }
        }
        if(left.sprite == _spriteGreen && right.sprite == _spriteGreen && forward.sprite == _spriteGreen && back.sprite == _spriteGreen)
        {
            _pleaseRotate.SetActive(false);

            left.sprite = _spriteWhite;
            right.sprite = _spriteWhite;
            forward.sprite = _spriteWhite;
            back.sprite = _spriteWhite;
            left.fillAmount = 0;
            right.fillAmount = 0;
            forward.fillAmount = 0;
            back.fillAmount = 0;
            left.gameObject.SetActive(false);
            right.gameObject.SetActive(false);
            forward.gameObject.SetActive(false);
            back.gameObject.SetActive(false);
            _great.SetActive(true);
            StartCoroutine(EndGreat());
            for (int i = 0; i < prefRotate.Length; i++)
            {
                if (prefRotate[i].activeSelf == true)
                {
                    prefRotate[i].SetActive(false);
                }
            }
            CreateObject();
            _clickButton.SetActive(true);
        }
        if(_clickButton.activeSelf==true)
        {
           
            if (BaseSDK.GetButton(2))
            {
                _linehit.SetActive(true);
                _linehit2.SetActive(true);
                Destroy(Instantiate(prefabOfHit, pref.transform.position, Quaternion.identity), 1.5f);
                StartCoroutine(Fire());
                _great.SetActive(true);
                _great.GetComponent<Animator>().Play(0);
                StartCoroutine(GoOn());
            }
        }
    }

    private IEnumerator SetMenu()
    {
        yield return new WaitForSeconds(1f);
        isReadyToMenu = true;
    }

    private void CreateObject()
    {
        if (isPool == false)
        {
            Debug.Log("gogo");
            pref = Instantiate(_prefabOfFire, _spawn.position, Quaternion.identity);
            isPool = true;
        }
    }

    private IEnumerator GoOn()
    {
        _clickButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        _great.SetActive(false);
        _StartTutorial.SetActive(true);
        isReadyToMenu = true;
        isInMenu = false;
        _playerControll.GetComponent<Controller>().enabled = true;
        _StartTutorial.GetComponent<InstAsteroids>().InstaitiateObjects();
        _playerControll.GetComponent<Controller>().ResetLife();
        

    }

    private IEnumerator Fire()
    {
        Destroy(pref);
        yield return new WaitForSeconds(0.2f);
        _linehit.SetActive(false);
        _linehit2.SetActive(false);
    }

    private IEnumerator EndGreat()
    {
        yield return new WaitForSeconds(2f);
        _great.SetActive(false);
    }

    private IEnumerator ForwardOn()
    {
        _leftRight.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        forward.gameObject.SetActive(true);
        _pleaseRotate.SetActive(true);
        _forwardBack.SetActive(true);
    }

    private IEnumerator BackON()
    {
        _forwardBack.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        back.gameObject.SetActive(true);
        _pleaseRotate.SetActive(true);
        _forwardBack.SetActive(true);
    }

    private IEnumerator RightOn()
    {
        _leftRight.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        right.gameObject.SetActive(true);
        _leftRight.SetActive(true);
        _pleaseRotate.SetActive(true);
    }

    public void StartTutorial()
    {
        _pleaseRotate.SetActive(true);
    }
    private IEnumerator Tutor()
    {
        yield return new WaitForSeconds(2f);
        _spriteStartTutorial.SetActive(false);
        _pleaseRotate.SetActive(true);
    }

    public void StopTutor()
    {
        isEnterStartTutor = false;
        StopCoroutine(_cor);
    }

    public void ChangeStartTutorial(int i, int j)
    {
        buttonMenu[i].transform.localScale += Vector3.one * 0.002f;
        buttonMenu[j].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, _color);
        _color -= 0.01f;
        
    }

    public void UnchangeStartTutorial(int i, int j)
    {
        buttonMenu[i].transform.localScale = Vector3.one * 0.5f;
        buttonMenu[j].GetComponent<SpriteRenderer>().color = Color.white;
    }


    public void Exit()
    {
        _color = 1f;
        isExitEnter = true;
        _cor = StartCoroutine(ExitCor());
    }

    private IEnumerator ExitCor()
    {
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }

    public void ExitCancel()
    {
        isExitEnter = false;
        StopCoroutine(_cor);
    }

    public void ResetGame()
    {
        _color = 1f;
        isReset = true;
        _cor = StartCoroutine(ResetOn());
    }

    private IEnumerator ResetOn()
    {
        yield return new WaitForSeconds(1.5f);
        isReset = false;
        for(int i=0;i<buttonMenu.Length;i++)
        {
            buttonMenu[i].transform.localScale = Vector3.one * 0.5f;
            buttonMenu[i].SetActive(false);
        }
        for (int j = 0; j < screens.Length; j++)
        {
            screens[j].SetActive(true);
        }
        _StartTutorial.SetActive(false);
        _playerControll.GetComponent<Controller>().enabled = false;
        _pleaseRotate.SetActive(true);
        left.gameObject.SetActive(true);
        right.gameObject.SetActive(true);
        forward.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
        isPool = false;
        isReadyToMenu = false;
    }

    public void ResetGameQuit()
    {
        isReset = false;
        StopCoroutine(_cor);
    }
    
}
