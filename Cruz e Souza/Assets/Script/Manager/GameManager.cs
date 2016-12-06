using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
	public class GameManager : MonoBehaviour {


        public float timeMagicItem = 30;
        public float playerOffSet;
        public float speed;

        public AudioSource normalMusic;
        public AudioSource magicMusic;

        public bool poemMode = false;

        public GameObject magicItem;
        public GameObject[] enemies;
        public GameObject[] itens;
        public Text[] itensTexts;

        public TelaPretaController telaPreta;     

        [HideInInspector]
        public int[] totalItens;                

        private GameStateMap gameState = GameStateMap.RUNNING;

        private System.DateTime lastGcCall = System.DateTime.Now;

		private const int MIN_TIME_CG_CALL = 30;

        public GameStateMap GameState { get { return gameState; } set { gameState = value; } }

        private int spawMagicItem;

		/**
		 * System otimization. When the game is paused
		 * the system checks if the memory has been cleaned in the 
		 * last 30 minutes, case positive only pause the game, otherwise
		 * the memory is cleaned, freeing dead spaces.
		 * */
		public void Pause () {
			Time.timeScale = 0;
			if ((this.lastGcCall - System.DateTime.Now).TotalMinutes > MIN_TIME_CG_CALL) {
				System.GC.Collect ();
				this.lastGcCall = System.DateTime.Now;
			}
			gameState = GameStateMap.PAUSED;
		}

        public void ShowBlackScreen()
        {
            telaPreta.goBlack = true;
            telaPreta.goTransparent = false;

            telaPreta.gameObject.SetActive(true);
        }

        public void HideScreen()
        {
            telaPreta.goBlack = false;
            telaPreta.goTransparent = true;
            this.poemMode = !this.poemMode;
        }


        void Start()
        {
            this.SpawnItem();
            this.normalMusic.time = 5;
            this.normalMusic.Play();

            totalItens = new int[itensTexts.Length];
            for (int i = 0; i < totalItens.Length; i++)
            {
                totalItens[i] = 0;
            }
        }

		public void Resume () {
			Time.timeScale = 1;
			gameState = GameStateMap.RUNNING;
		}

		public void LoadScene (string sceneName) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
		}

        public void GotItem(int itenType)
        {
            this.totalItens[itenType]++;
            for (int i = 0; i < itensTexts.Length; i++)
            {
                itensTexts[i].text = ""+totalItens[i];
            }

        }

       void SpawnItem()
        {
            int f = UnityEngine.Random.Range(0, itens.Length);
            int offset = UnityEngine.Random.Range(-1 , 2);
                                  
            GameObject.Instantiate(itens[(int)f], this.transform.position + new Vector3(offset * playerOffSet , 0.95f, 0), Quaternion.identity);
            
            Invoke("SpawnEnemy", 1);
        }

        void SpawnMagicItem()
        {
            int offset = UnityEngine.Random.Range(-1, 2);

            GameObject.Instantiate(magicItem, this.transform.position + new Vector3(offset * playerOffSet, 1.35f, 0), Quaternion.identity);

            Invoke("SpawnEnemy", 1);
        }

        void SpawnEnemy()
        {
            int f = UnityEngine.Random.Range(0, enemies.Length);            
            int offset = UnityEngine.Random.Range(-1 , 2);
            if (!this.poemMode) {
                GameObject.Instantiate(enemies[(int)f], this.transform.position + new Vector3(offset * playerOffSet, 0.95f, 0), Quaternion.identity);
            }
            if (spawMagicItem <= 0 && Time.timeSinceLevelLoad > timeMagicItem)
            {
                Invoke("SpawnMagicItem", 1);
                spawMagicItem++;
            }
            else
            {
                Invoke("SpawnItem", 1);
            }
        }
    }

}
