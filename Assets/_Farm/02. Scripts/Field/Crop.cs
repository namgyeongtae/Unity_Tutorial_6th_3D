using System.Collections;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public enum CropState { Level1, Level2, Level3 }
    public CropState cropState;

    [SerializeField] private CropData data;

    private float growthTime;
    public bool isHarvest;

    private WeatherType curretWeather = WeatherType.Sun;
    
    void OnEnable()
    {
        growthTime = data.growthTime;
        
        isHarvest = false;
        SetState(CropState.Level1);
        WeatherSystem.weatherChanged += SetGrowth;
        
        StartCoroutine(GrowthRoutine());
    }

    void OnDisable()
    {
        WeatherSystem.weatherChanged -= SetGrowth;
    }

    IEnumerator GrowthRoutine()
    {
        yield return new WaitForSeconds(growthTime);
        SetState(CropState.Level2);
        
        yield return new WaitForSeconds(growthTime);
        SetState(CropState.Level3);
        
        isHarvest = true;
    }

    private void SetState(CropState newState)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == (int)newState);
    }

    
    private void SetGrowth(WeatherType weatherType)
    {
        if (curretWeather != weatherType)
        {
            switch (weatherType)
            {
                case WeatherType.Sun:
                    growthTime *= 1f;
                    break;
                case WeatherType.Rain:
                    growthTime *= 1.3f;
                    break;
                case WeatherType.Snow:
                    growthTime *= 1.5f;
                    break;
            }
            
            if (growthTime > 10) // 최대 성장속도 제한
                growthTime = 10;

            curretWeather = weatherType;
            Debug.Log("성장속도 변경");
        }
    }
}