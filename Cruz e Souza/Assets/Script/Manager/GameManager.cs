using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{

	public class GameManager : MonoBehaviour {

        public float playerOffSet;
        public float speed;
                
        public GameObject[] enemies;
        public GameObject[] itens;
        public Text[] itensTexts;        

        [HideInInspector]
        public int[] totalItens;                

        private GameStateMap gameState = GameStateMap.RUNNING;

        private System.DateTime lastGcCall = System.DateTime.Now;

		private const int MIN_TIME_CG_CALL = 30;

        public GameStateMap GameState { get { return gameState; } set { gameState = value; } }

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

        void Start()
        {
            this.SpawnItem();            
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

        void SpawnEnemy()
        {
            int f = UnityEngine.Random.Range(0, enemies.Length);            
            int offset = UnityEngine.Random.Range(-1 , 2);

            GameObject.Instantiate(enemies[(int)f], this.transform.position + new Vector3(offset*playerOffSet, 0.95f, 0), Quaternion.identity);
            Invoke("SpawnItem", 1);
        }
    }

}
