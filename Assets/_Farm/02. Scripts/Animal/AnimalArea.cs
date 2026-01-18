using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalArea : MonoBehaviour, ITriggerEvent
{
    [SerializeField] private GameObject flag;
    [SerializeField] private TextMeshProUGUI timerUI;

    private BoxCollider coll;

    private float timer;
    private bool isInteract;

    public static Action failAction;

    void OnEnable()
    {
        failAction += SetRandomPosition;
    }

    void Start()
    {
        coll = GetComponent<BoxCollider>();
    }

    void OnDisable()
    {
        failAction -= SetRandomPosition;
    }

    public void InteractionEnter()
    {
        isInteract = true;
        timerUI.gameObject.SetActive(true);
        CameraManager.OnChangedCamera("Player", "Animal");
        SetRandomPosition();

        StartCoroutine(AnimalRoutine());        // 타이머 활성화
    }

    public void InteractionExit()
    {
        isInteract = false;
        timerUI.gameObject.SetActive(false);
        CameraManager.OnChangedCamera("Animal", "Player");

        Debug.Log($"깃발을 가지고 나오는데 걸린 시간: {(int)timer}초 입니다.");

        timer = 0f;
    }

    IEnumerator AnimalRoutine()
    {
        while (isInteract)
        {
            timer += Time.deltaTime;

            int min = Mathf.FloorToInt(timer / 60f);
            int sec = Mathf.FloorToInt(timer % 60f);
            timerUI.text = $"{min:D2} : {sec:D2}";

            yield return null;
        }
    }

    private void SetRandomPosition()
    {
        float randomX = Random.Range(coll.bounds.min.x, coll.bounds.max.x);
        float randomZ = Random.Range(coll.bounds.min.z, coll.bounds.max.z);

        Vector3 randomPos = new Vector3(randomX, 0, randomZ);

        SetFlag(randomPos, true);
    }

    private void SetFlag(Vector3 pos, bool isActive)
    {
        flag.transform.SetParent(transform);
        flag.transform.position = pos;
        flag.SetActive(isActive);
    }
}