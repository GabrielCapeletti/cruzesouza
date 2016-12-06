using UnityEngine;
using System.Collections;



public class History_Controler : MonoBehaviour {
	public UnityEngine.UI.Text txtRef;
	public AudioClip audio_beep;
    public AudioClip history1;
    public AudioClip history2;
    public AudioClip history3;

    public int historia;
    public AudioSource narrador;
    public UnityEngine.UI.Image textbox;
    public UnityEngine.UI.Image intro;
    public UnityEngine.UI.Image todas;

    AudioSource audio;
	// Use this for initialization
	float contempo = 0;
	private string[] textos = {
		//Texto 1 - muda tela 1;
		"Olá, seja bem-vind@! Nesse jogo você irá se aventurar pela história de Cruz e Souza, o “Poeta do Desterro”",
		//Texto 2;
		"João da Cruz e Souza nasceu em 24 de novembro de 1861, em Nossa Senhora do Desterro, atual Florianópolis. ", 
		//Texto 3;
		"Seu pai, Guilherme da Cruz, era pedreiro, sua mãe se chamava Carolina Eva da Conceição, ambos escravos alforriados, eles prestavam serviço ao militante da Guerra do Paraguai, marechal Guilherme Xavier de Souza.\n",
		//Texto 4 muda tela 2;
		"Foi na casa do militar que Cruz e Souza se criou, e lá teve suas primeiras lições para alfabetização, com Clarinda Fagundes de Souza, mulher do marechal. Em 1869 ele ingressou na escola pública.\n",
		//Texto 5;
		"No ano de 1971 foi matriculado no Ateneu Provincial Catarinense. Cruz e Sousa estudou com distinção grego, latim, inglês, francês, português e alguns historiadores acreditam que ele foi discípulo do alemão Fritz Müller, com quem aprendeu matemática e Ciências Naturais\n",
		//Texto 6 muda tela 3;
		" O filho de escravos teve papel marcante na história por seus ideais abolicionistas, combatendo a escravidão e o preconceito racial nas letras que escrevia.",
		//Texto 7;
		"A fim de disseminar esse posicionamento, Cruz e Souza, ao lado dos poetas e jornalistas Vírgílio Várzea e Santos Lostada, fundou em 1881 o jornal literário “Colombo”, porém com baixa circulação.\n",
		//Texto 8 muda tela 4;
		"Ainda em 1881, Cruz e Souza dirigiu o jornal Folha Popular, com maior prestígio que a publicação anterior, disseminando assim os ideais abolicionistas.\n",
		//Texto 9;
		"Mantendo a parceria com Virgílio Várzea, em 1885 publicam o livro de poemas em prosa “Tropos e Fantasias”.\n",
		//Texto 10 muda tela 5;
		"Ainda na linha do jornalismo cultural e crítico, Cruz e Souza dirige por seis meses o jornal “O Moleque” um periódico de pequeno formato, ilustrado litograficamente, criticando os costumes e a política com humor, sátiras e caricaturas.\n",
		//Texto 11;
		"Antes de continuarmos a história desse icônico poeta, saltando do sul para o sudeste do país, guie Cruz e Souza pelo Mercado Público de Florianópolis.",
		//Texto 12;
		"Tente coletar os exemplares de “Colombo”, “Folha Popular”, “Tropos e Fantasias” e “O Moleque”. Tome cuidado para não tropeçar nos vendedores de peixe e nas rendeiras",	
		//Texto 13 muda tela 6 - JOGO: MERCADO PÚBLICO;
		"E1stamos agora em 1888, ano da abolição da escravatura, na então capital nacional Rio de Janeiro.",
		//Texto 14;
		"Nessa época Cruz e Souza se aproxima das leituras de Arthur Rimbaud, Stéphane Mallarmé e outros simbolistas europeus. Daria então seus primeiros passos dentro do movimento literário até então desconhecido no Brasil: o Simbolismo.\n",
		//Texto 15;
		"Em 1890 Cruz e Souza muda-se definitivamente para o Rio de Janeiro, onde trabalha como noticiarista da revista A Cidade do Rio de Janeiro, colabora na Revista Ilustrada e no jornal Novidades",
		//Texto 16 muda tela 7;
		"Em uma dessas imprevisibilidades da vida, no dia 18 de setembro de 1891, à porta de um cemitério de subúrbio, Cruz e Sousa conhece Gavita Rosa Gonçalves, uma costureira negra que se criara na casa de um médico de posses. Começara ali um grande amor\n",
		//Texto 17;
		"A luta de Cruz e Souza contra o preconceito racial e as intempéries da vida enchiam sua alma de poesia. Retratando a angústia de sua condição, a publicação de “Missal”, em fevereiro de 1893, e “Broquéis”, em agosto, deflagrou a instauração do Simbolismo no país.\n",
		//Texto 18;
		"No mês de novembro de 1893, Cruz e Souza casa-se com Gavita.",
		//Texto 19;
		"Tempos difíceis viriam nos anos seguintes na vida do poeta, mas antes de passarmos para a última parte dessa história, guie Cruz e Souza pela cidade do Rio de Janeiro." ,
		//Texto 20;
		"coletando exemplares das revistas  A Cidade do Rio de Janeiro e Revista Ilustrada,  do jornal Novidades, e das publicações Missal e Broquéis. Novamente Cuidado com os obstáculos pelo caminho.",
		//Texto 21 muda tela 8 - JOGO: RIO DE JANEIRO;
		"Para garantir o sustento Cruz e Souza, trabalha como arquivista na Estrada de Ferro Central do Brasil. Tempos difíceis de pobreza e doenças se aproximavam.\n",
		//Texto 22;
		"Em fevereiro de 1894 nasce o primeiro filho. Em outubro de 1895 nasce o segundo.\n",
		//Texto 23;
		"Em março de 1896 Gavita é diagnosticada com demência, em agosto do mesmo ano morre o pai do poeta.\n",
		//Texto 24;
		"Era nas palavras que o poeta tinha refúgio diante das dificuldades da vida e nesse período Cruz e Souza compõe os poemas de “Faróis” e a prosa poética “Evocações”\n",
		//Texto 25 muda tela 9;
		"Após presenciar a morte de dois filhos por tuberculose, em 1897 o poeta vê nascer seu terceiro filho, expressando sua alegria e louvores aos céus no poema “Glória”. \n",
		//Texto 26;
		"No mesmo ano, porém, a Cruz e Souza é diagnosticado com tuberculose e, em meio à doença, à pobreza e ao desamparo social, o poeta compõe Últimos Sonetos.",
		//Texto 27;
		"A trajetória de um ícone da literatura brasileira caminhava para o fim. A tuberculose encerraria prematuramente a vida do Poeta do Desterro. ",
		//Texto 28 - muda tela 10;
		"No início de 1898 a doença se agrava e na busca por recuperação Cruz e Souza é transferido para um clima melhor, na Estação Sítio, na localidade de Curral Novo, então pertencente ao município de Barbacena, em Minas Gerais.\n",
		//Texto 29;
		"Três dias depois, em 19 de março de 1898, a história de Cruz e Souza recebe o ponto final. Seu corpo é levado para o Rio de Janeiro em um vagão de carga transportando gado e ao chegar, foi sepultado no Cemitério de São Francisco Xavier por seus amigos.\n",
		//Texto 30;
		"Em 29 de novembro de 2007, os restos mortais de Cruz e Souza foram transladados do Cemitério São Francisco Xavier, no Rio de Janeiro, para Florianópolis, sendo então acolhidos no Museu Histórico de Santa Catarina - Palácio Cruz e Sousa, no centro da capital catarinense\n",
		//Texto 31;
		"Formalizando sua importância para a literatura brasileira e regional, Cruz e Sousa é um dos patronos da Academia Catarinense de Letras, representando a cadeira número 15.\n",
		//Texto 32 - muda tela 11 - JOGO: TREM;
		"Os 36 anos vividos por Cruz e Souza não foram suficientes para que ele pudesse ver todos seus valiosos escritos publicados\n",
		//Texto 33;
		"mas graças as publicações póstumas a literatura nacional hoje é enriquecida com as Poesias e os Poemas em prosa de um dos precursores do simbolismo no Brasil: Cruz e Souza, o Dante Negro, o Poeta do Desterro!\n",

	};

	//TEMPO TOTAL EM QUE CADA TEXTO FICARÁ NA TELA
	private int[] textos_segundos = { 
		/* texto 1 */ 10, 
		/* texto 2 */12,
		/* texto 3 */18,
		/* texto 4 */17, 
		/* texto 5 */24,
		/* texto 6 */13,

		/* texto 7 */16, 
		/* texto 8 */12,
		/* texto 9 */10,
		/* texto 10 */17,
		/* texto 11 */10,
		/* texto 12 */8,
		/* texto 13 */8,
		/* texto 14 */17,
		/* texto 15 */14,
		/* texto 16 */22,
		/* texto 17 */22,
		/* texto 18 */6,
		/* texto 19 */10,
		/* texto 20 */5,
		/* texto 21 */11,
		/* texto 22 */9,
		/* texto 23 */10,
		/* texto 24 */11,
		/* texto 25 */15,
		/* texto 26 */13,
		/* texto 27 */10,
		/* texto 28 */17,
		/* texto 29 */20,
		/* texto 30 */18,
		/* texto 31 */11,
		/* texto 32 */10,
		/* texto 32 */16,
		/* texto 33 */15,
	};
	//TEMPO TOTAL QUE DEMORA PARA ESCREVER O TEXTO
	private int[] textos_segundos_escrita = {		
		/* texto 1 */5, 
		/* texto 2 */7,
		/* texto 3 */13,
		/* texto 4 */11, 
		/* texto 5 */19,
		/* texto 6 */8,

		/* texto 7 */11, 
		/* texto 8 */6,
		/* texto 9 */5,
		/* texto 10 */12,
		/* texto 11 */5,
		/* texto 12 */3,
		/* texto 13 */3,
		/* texto 14 */11,
		/* texto 15 */9,
		/* texto 16 */17,
		/* texto 17 */17,
		/* texto 18 */2,
		/* texto 19 */5,
		/* texto 20 */3,
		/* texto 21 */5,
		/* texto 22 */3,
		/* texto 23 */5,
		/* texto 24 */7,
		/* texto 25 */10,
		/* texto 26 */8,
		/* texto 27 */5,
		/* texto 28 */12,
		/* texto 29 */15,
		/* texto 30 */13,
		/* texto 31 */6,
		/* texto 32 */5,
		/* texto 32 */10,
		/* texto 33 */10,
	};
	
	int textoAtual = 0;
	string txtemtela = "";
	int letraAtual = 0;

    Color colorBegin;
    Color colorEnd;
    void Start () {
        Application.runInBackground = true;
		audio = GetComponent<AudioSource>();
        audio.volume = 0.1f;

        colorBegin = intro.color;
        colorEnd = new Color(colorBegin.r, colorBegin.g, colorBegin.b, 0f);


       
        if (historia == 0)
        {
           //narrador.PlayOneShot(history1);
        }
        if (historia == 1) {
       
			textoAtual = 0;
		}
		if (historia == 2) {
			textoAtual = 12;
		}
		if (historia == 3) {
			textoAtual = 20;
		}
		if (historia == 4) {
			textoAtual = 31;
		}
	}

    // Update is called once per frame
    //MUDANÇA DE FASES NO 13, 28, 32
    float textbox_targetX = 467;
    bool primeiro = true;
    
    float Delay = 0;
    float tempo_alpha_img1 = 10;

    float targetFala2Y = 0;
    float targetFala3Y = -310;
    float targetFala4Y = 215;
    float targetFala5Y = -290;
    float targetFala6X = 15;
    float targetFala7X = 0;
    void Update () {
       
  
        if(textbox.GetComponent<RectTransform>().transform.position.x >= 467)
            {

          //  Debug.Log(textbox.GetComponent<RectTransform>().transform.position.x);
            textbox.transform.Translate(new Vector3(-2,0,0));
              
        }
      
        else
        {
            
            mudaTexto(textoAtual, contempo);
            contempo += Time.deltaTime;
            switch (textoAtual)
            {
                case 0: //BAIXANDO O ALPHA
                        //intro
                    if (primeiro)
                    {
                        narrador.PlayOneShot(history1);
                        primeiro = false;
                    }
                    Delay += Time.deltaTime;
                    intro.color = Color.Lerp(colorBegin, colorEnd, Delay * 0.1f);

                    if (intro.color.a == 0)
                    {
                        GameObject.Destroy(intro);
                    }
                    break;
                case 1:
                    if (!intro.IsDestroyed())
                    {
                        GameObject.Destroy(intro);
                    }
                    break;
                case 2:
                
                    if (todas.transform.position.y > targetFala2Y)
                        todas.transform.Translate(new Vector3(0,-1,0));
                    break;
                case 3:
                    if (todas.transform.position.y > targetFala3Y)
                        todas.transform.Translate(new Vector3(0, -1, 0));
                        break;
                case 4:
                    if (todas.transform.position.y< targetFala4Y)
                        todas.transform.Translate(new Vector3(0, +1.5f, 0));
                 //   Debug.Log(todas.transform.position.y);
                    break;
                case 5:
                    if (todas.transform.position.y > targetFala5Y)
                        todas.transform.Translate(new Vector3(0, -1.5f, 0));
                 //   Debug.Log(todas.transform.position.y);
                    break;
                case 6:
                    if (todas.transform.position.x > targetFala6X)
                        todas.transform.Translate(new Vector3(-1.2f, 0, 0));
                   // Debug.Log(todas.transform.position.x);
                    break;
                case 12:
                    if (primeiro)
                    {
                        narrador.PlayOneShot(history2);
                        primeiro = false;
                        Vector3 v = new Vector3(todas.transform.position.x - 900, todas.transform.position.y, todas.transform.position.z);
                        todas.transform.position = v;


                    }

                    Delay += Time.deltaTime;
                    intro.color = Color.Lerp(colorBegin, colorEnd, Delay * 0.1f);

                    if (intro.color.a == 0)
                    {
                        GameObject.Destroy(intro);
                    }

                    break;
                case 13:
                    if (!intro.IsDestroyed())
                    {
                        GameObject.Destroy(intro);
                    }
                    break;
                case 14:
                    if(todas.transform.position.y<300)
                         todas.transform.Translate(new Vector3(0, 1f, 0));
                    Debug.Log(todas.transform.position.y);
                    break;
                   
                case 17:
                    if (todas.transform.position.y < 460)
                        todas.transform.Translate(new Vector3(0, 0.5f, 0));
                    Debug.Log(todas.transform.position.y);
                    break;
                case 20:
                    //intro
                    if (primeiro)
                    {
                        narrador.PlayOneShot(history3);
                        primeiro = false;
                        Vector3 v = new Vector3(todas.transform.position.x-980, todas.transform.position.y+910, todas.transform.position.z);
                        todas.transform.position = v;
                    }
                    Delay += Time.deltaTime;
                    intro.color = Color.Lerp(colorBegin, colorEnd, Delay * 0.1f);

                    if (intro.color.a == 0)
                    {
                        GameObject.Destroy(intro);
                    }
                   
                    break;
                case 21:
                    if (!intro.IsDestroyed())
                    {
                        GameObject.Destroy(intro);
                    }
                   // if(todas.transform.position.x > -125)
                         todas.transform.Translate(new Vector3(0.3f, 0, 0));
                    Debug.Log(todas.transform.position.x);
                    break;
                case 22:
                    //if (todas.transform.position.x > -125)
                        todas.transform.Translate(new Vector3(0.3f, 0, 0));
                    Debug.Log(todas.transform.position.x);
                    break;
                case 23:
                    if (todas.transform.position.x < 845)
                        todas.transform.Translate(new Vector3(0.3f, 0, 0));
                    Debug.Log(todas.transform.position.x);
                    break;
                case 24:
                    if (todas.transform.position.x < 845)
                        todas.transform.Translate(new Vector3(0.3f, 0, 0));
                    Debug.Log(todas.transform.position.x);
                    break;
                case 25:
                    if (todas.transform.position.x < 845)
                        todas.transform.Translate(new Vector3(0.3f, 0, 0));
                    Debug.Log(todas.transform.position.x);
                    break;
                case 26:
                    if (todas.transform.position.y > 850)
                        todas.transform.Translate(new Vector3(0, -.3f, 0));
                    Debug.Log(todas.transform.position.y);
                    break;
                case 27:
                    if (todas.transform.position.y < 920)
                        todas.transform.Translate(new Vector3(0, .3f, 0));
                    Debug.Log(todas.transform.position.y);
                    break;
                case 28:
                    if(todas.transform.position.x > -70)
                        todas.transform.Translate(new Vector3(-.4f, 0, 0));
                    Debug.Log(todas.transform.position.x);
                    break;
                case 29:
                    if (todas.transform.position.x > -70)
                        todas.transform.Translate(new Vector3(-.4f, 0, 0));
                    Debug.Log(todas.transform.position.x);
                    break;
                case 30:
                    if (todas.transform.position.x > -70)
                        todas.transform.Translate(new Vector3(-.4f, 0, 0));
                    Debug.Log(todas.transform.position.x);
                    break;
                  
                default:
                    break;

            }
        }
        
	


			

	}


	void mudaTexto(int v, float satual){


		string texto = textos [v]; 
		int stotal = textos_segundos[v];
		float smostar = textos_segundos_escrita[v];

		float sporletra = smostar / texto.Length;
		int novaLetra = (int)(satual / sporletra);
        txtemtela = "";
        if (novaLetra > letraAtual && letraAtual < texto.Length)
        {
            for (int i = 0; i < novaLetra; i++)
            {
                txtemtela += texto[i];
            }
         
          //  audio.PlayOneShot(audio_beep, 1);
            txtRef.text = txtemtela;
            letraAtual = novaLetra;
         

        }
        //txtemtela += texto [letraAtual];



        if (satual > stotal) {
			if (textoAtual == 11)
				Application.LoadLevel (2);
			if (textoAtual == 19)
				Application.LoadLevel (0);
			if (textoAtual == 32)
				Application.LoadLevel (1);
			
			textoAtual++;
			txtRef.text = "";
			letraAtual = 0;
			txtemtela = "";
			contempo = 0;

		}

	}
}
