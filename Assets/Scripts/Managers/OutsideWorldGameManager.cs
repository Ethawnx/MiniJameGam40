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
    }
    private void IncreaseGameDifficulty()
    {
        currentGameDifficultyIndex++;
        _skyScroll.speed ++;
        _cityScroll.speed ++;
        _obstaclePlatformeSpawner.XoffsetToAdd--;
    }
    
}
