using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance;
    public GameObject loadingScreenPrefab; // 로딩 화면 프리팹
    private GameObject loadingScreenInstance; // 로딩 화면 인스턴스
    public Slider progressBar;       // 진행률 슬라이더
    public Text progressText;        // 진행률 텍스트

    private string targetSceneName;  // 로드할 씬 이름을 저장

    private void Awake()
    {
        // 싱글턴 패턴을 사용하여 로딩 매니저의 중복 생성을 방지
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 파괴되지 않음
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // 외부에서 호출할 수 있는 씬 로드 함수
    public void LoadScene(string sceneName)
    {
        targetSceneName = sceneName;
        SceneManager.LoadScene("LoadingScene"); // 로딩 씬으로 이동
        StartCoroutine(LoadLoadingSceneAsync());
    }

    // 로딩 씬에서 호출되는 코루틴
    public void StartLoadingTargetScene()
    {
        StartCoroutine(LoadTargetSceneAsync());
    }

    private IEnumerator LoadTargetSceneAsync()
    {
        float minimumLoadingTime = 0.75f; // 최소 로딩 시간 (1초)
        float elapsedTime = 0f;

        yield return null; // 한 프레임 대기 (로딩 씬이 완전히 로드될 때까지 대기)

        AsyncOperation operation = SceneManager.LoadSceneAsync(targetSceneName);
        operation.allowSceneActivation = false;

        if (loadingScreenInstance == null && loadingScreenPrefab != null)
        {
            loadingScreenInstance = Instantiate(loadingScreenPrefab);
            progressBar = loadingScreenInstance.transform.Find("ProgressBar").GetComponent<Slider>();
            progressText = loadingScreenInstance.transform.Find("ProgressText").GetComponent<Text>();
        }

        if (loadingScreenInstance != null)
        {
            loadingScreenInstance.SetActive(true); // 로딩 화면 활성화
        }

        while (!operation.isDone)
        {
            elapsedTime += Time.deltaTime;

            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            if (progressBar != null)
            {
                progressBar.value = progress; // 슬라이더 진행률 업데이트
            }
            if (progressText != null)
            {
                progressText.text = (progress * 100).ToString("F0") + "%"; // 진행률 텍스트 업데이트
            }

            // 최소 로딩 시간 동안 대기
            if (operation.progress >= 0.9f && elapsedTime >= minimumLoadingTime)
            {
                if (progressBar != null)
                {
                    progressBar.value = 1f;
                }
                if (progressText != null)
                {
                    progressText.text = "100%";
                }
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        if (loadingScreenInstance != null)
        {
            loadingScreenInstance.SetActive(false); // 로딩 화면 비활성화
        }
    }


    private IEnumerator LoadLoadingSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("LoadingScene");
        while (!operation.isDone)
        {
            yield return null;
        }

        if (Instance != null)
        {
            Instance.StartLoadingTargetScene();
        }
    }
}

// LoadingScene에서 사용할 스크립트
public class LoadingSceneInitializer : MonoBehaviour
{
    private void Start()
    {
        // LoadingManager의 로딩 코루틴 시작
        if (SceneLoadManager.Instance != null)
        {
            SceneLoadManager.Instance.StartLoadingTargetScene();
            Debug.Log("나와라 ㅅㅂ");
        }
        Debug.Log("나와라 ㅅㅂ");
    }
}