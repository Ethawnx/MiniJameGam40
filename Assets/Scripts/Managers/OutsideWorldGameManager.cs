using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.CorgiEngine;
public class OutsideWorldGameManager : GameManager
{
    public GameObject SpawnerGameObject;
    public GameObject CityBackGroundObject;
    public GameObject SkyBackGroundObject;
    //time it takes for the game to increment difficulty of the game
    [SerializeField]
    private float IncrementGameDifficultyTime;

    //Our Current Game Difficulty With 0 Index;
    private int currentGameDifficultyIndex;

    private float timePassedSinceStart = -1f;
    private float timeCounter;

    private ObstaclePlatformeSpawner _obstaclePlatformeSpawner;
    private PlatformSpawner _platformSpawner;
    private Scroll _cityScroll;
    private Scroll _skyScroll;

    private float defaultCityScrollValue;
    private float defaultSkyScrollValue;
    private float defaultObstaclePlatformValue;
    private float defaultPlatformValue;
    private float platformSpawnerMinFrequencyDefaultValue;
    private float platformSpawnerMaxFrequencyDefaultValue;
    private float ObsplatformSpawnerMinFrequencyDefaultValue;
    private float ObsplatformSpawnerMaxFrequencyDefaultValue;



    protected override void Start()
    {
        base.Start();

        _obstaclePlatformeSpawner = SpawnerGameObject.GetComponentInChildren<ObstaclePlatformeSpawner>();
        _platformSpawner = SpawnerGameObject.GetComponentInChildren<PlatformSpawner>();
        _cityScroll = CityBackGroundObject.GetComponent<Scroll>();
        _skyScroll = SkyBackGroundObject.GetComponent<Scroll>();

        defaultSkyScrollValue = _skyScroll.speed;
        defaultCityScrollValue = _cityScroll.speed;
        defaultObstaclePlatformValue = _obstaclePlatformeSpawner.XoffsetToAdd;

        platformSpawnerMinFrequencyDefaultValue = _platformSpawner.MinFrequency;
        platformSpawnerMaxFrequencyDefaultValue = _platformSpawner.MaxFrequency;
        ObsplatformSpawnerMinFrequencyDefaultValue = _obstaclePlatformeSpawner.MinFrequency;
        ObsplatformSpawnerMaxFrequencyDefaultValue = _obstaclePlatformeSpawner.MaxFrequency;
    }
    private void Update()
    {
        timePassedSinceStart += Time.deltaTime;
        timeCounter += Time.deltaTime;
        if (timeCounter >= IncrementGameDifficultyTime)
        {
            //IncrementGameDifficultyTime += 2f;
            IncreaseGameDifficulty();
            timeCounter = 0f;
        }
            
        // Debug.Log("timePassedSinceStart: " + timePassedSinceStart);
        // Debug.Log("IncrementGameDifficultyTime: " + IncrementGameDifficultyTime);
        // Debug.Log("currentGameDifficultyIndex: " + currentGameDifficultyIndex);

    }
    public override void ResetGameValues()
    {
        timeCounter = 0f;
        currentGameDifficultyIndex = 0;
        _skyScroll.speed = defaultSkyScrollValue;
        _cityScroll.speed = defaultCityScrollValue;
        _obstaclePlatformeSpawner.XoffsetToAdd = defaultObstaclePlatformValue;
        _platformSpawner.MinFrequency = platformSpawnerMinFrequencyDefaultValue;
        _platformSpawner.MaxFrequency = platformSpawnerMaxFrequencyDefaultValue;
        _obstaclePlatformeSpawner.MinFrequency = ObsplatformSpawnerMinFrequencyDefaultValue;
        _obstaclePlatformeSpawner.MaxFrequency = ObsplatformSpawnerMaxFrequencyDefaultValue;
    }
    private void IncreaseGameDifficulty()
    {
        if (_platformSpawner.MinFrequency <= 1f && _platformSpawner.MaxFrequency <= 1f)
        {
            _platformSpawner.MinFrequency = 0.1f;
            _platformSpawner.MaxFrequency = 0.1f;
        }
        else
        {
            _platformSpawner.MinFrequency -= 0.1f;
            _platformSpawner.MaxFrequency -= 0.1f;
        }

        if (_obstaclePlatformeSpawner.MinFrequency <= 2f && _obstaclePlatformeSpawner.MaxFrequency <= 2f)
        {
            _obstaclePlatformeSpawner.MinFrequency = 2f;
            _obstaclePlatformeSpawner.MaxFrequency = 2f;
        }
        else
        {
            _obstaclePlatformeSpawner.MinFrequency -= 0.2f;
            _obstaclePlatformeSpawner.MaxFrequency -= 0.2f;
        }
        
        currentGameDifficultyIndex++;
        _skyScroll.speed *= 1.25f;
        _cityScroll.speed *= 1.25f;
        _obstaclePlatformeSpawner.XoffsetToAdd--;
    }
    
}
