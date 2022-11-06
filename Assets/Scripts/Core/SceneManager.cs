using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace NailInTheCoffin.Core
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        private string _currentLevel = "TestLevel1";

        [ContextMenu("Load Level")]
        private void LoadLevel()
        {
            StartCoroutine(LoadSceneCoroutine());

            IEnumerator LoadSceneCoroutine()
            {
                yield return StartCoroutine(_loadingScreen.ShowCoroutine());

                var unloadOperation = UnitySceneManager.UnloadSceneAsync(_currentLevel);
                yield return new WaitUntil(() => unloadOperation.isDone);

                var loadOperation = UnitySceneManager.LoadSceneAsync("TestLevel2", LoadSceneMode.Additive);
                yield return new WaitUntil(() => loadOperation.isDone);

                StartCoroutine(_loadingScreen.HideCoroutine());
                Debug.Log("Level loaded.");
            }
        }
    }
}
