using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class calcular : MonoBehaviour
{
    public TMP_InputField raioCone;
    public TMP_InputField alturaCone;

    public TMP_InputField larguraRetangulo;
    public TMP_InputField alturaRetangulo;
    public TMP_InputField comprimentoRetangulo;

    public TMP_InputField raioCilindro;
    public TMP_InputField alturaCilindro;

    public TMP_InputField raioEsfera;

    public Button btnCalcular;
    public Button btnVoltar;
    public Button btnLimpar;

    public GameObject painelResposta;

    public TextMeshProUGUI txtResultado;
    
    // Start is called before the first frame update
    void Start()
    {
        btnCalcular.onClick.AddListener(CalcularHandler);
        btnVoltar.onClick.AddListener(VoltarHandler);
        btnLimpar.onClick.AddListener(LimparHandler);
    }

    public void CalcularHandler()
    {
        // Cone
        if (string.IsNullOrEmpty(raioCone.text))
        {
            raioCone.text = "0";
        }

        if (string.IsNullOrEmpty(alturaCone.text))
        {
            alturaCone.text = "0";
        }

        string raioConeText = raioCone.text;
        string alturaConeText = alturaCone.text;

        float raioDoCone = float.Parse(raioConeText);
        float alturaDoCone = float.Parse(alturaConeText);

        float areaBaseDoCone = Mathf.PI * Mathf.Pow(raioDoCone, 2);
        float volumeDoCone = (1.0f / 3.0f) * areaBaseDoCone * alturaDoCone;

        // Retangulo
        if (string.IsNullOrEmpty(larguraRetangulo.text))
        {
            larguraRetangulo.text = "0";
        }

        if (string.IsNullOrEmpty(alturaRetangulo.text))
        {
            alturaRetangulo.text = "0";
        }

        if (string.IsNullOrEmpty(comprimentoRetangulo.text))
        {
            comprimentoRetangulo.text = "0";
        }

        string larguraRetanguloText = larguraRetangulo.text;
        string alturaRetanguloText = alturaRetangulo.text;
        string comprimentoRetanguloText = comprimentoRetangulo.text;

        float larguraDoRetangulo = float.Parse(larguraRetanguloText);
        float alturaDoRetangulo = float.Parse(alturaRetanguloText);
        float comprimentoDoRetangulo = float.Parse(comprimentoRetanguloText);

        float areaDoRetangulo = larguraDoRetangulo * alturaDoRetangulo;
        float perimetroDoRetangulo = 2 * (larguraDoRetangulo + alturaDoRetangulo);
        float volumeDoRetangulo = areaDoRetangulo * comprimentoDoRetangulo;
        
        // Cilindro
        if (string.IsNullOrEmpty(raioCilindro.text))
        {
            raioCilindro.text = "0";
        }

        if (string.IsNullOrEmpty(alturaCilindro.text))
        {
            alturaCilindro.text = "0";
        }

        string raioCilindroText = raioCilindro.text;
        string alturaCilindroText = alturaCilindro.text;

        float raioDoCilindro = float.Parse(raioCilindroText);
        float alturaDoCilindro = float.Parse(alturaCilindroText);

        float areaBaseDoCilindro = Mathf.PI * Mathf.Pow(raioDoCilindro, 2);
        float volumeDoCilindro = areaBaseDoCilindro * alturaDoCilindro;

        // Esfera
        if (string.IsNullOrEmpty(raioEsfera.text))
        {
            raioEsfera.text = "0";
        }

        string raioEsferaText = raioEsfera.text;
        float raioDaEsfera = float.Parse(raioEsferaText);

        float volumeDaEsfera = (4.0f / 3.0f) * Mathf.PI * Mathf.Pow(raioDaEsfera, 3);

        string resultadoText = "";

        // Cone
        if (!string.IsNullOrEmpty(raioCone.text) && !string.IsNullOrEmpty(alturaCone.text) && (raioCone.text != "0" || alturaCone.text != "0"))
        {
            string areaBaseDoConeFormat = string.Format("{0:F" + 2 + "}", areaBaseDoCone);
            string volumeDoConeFormat = string.Format("{0:F" + 2 + "}", volumeDoCone);

            resultadoText += "Área da Base do Cone: " + areaBaseDoConeFormat + "cm²" +
                            "\nVolume do Cone: " + volumeDoConeFormat + "cm³\n";
        }

        // Retângulo
        if (!string.IsNullOrEmpty(larguraRetangulo.text) && !string.IsNullOrEmpty(alturaRetangulo.text) && !string.IsNullOrEmpty(comprimentoRetangulo.text)
            && (larguraRetangulo.text != "0" || alturaRetangulo.text != "0" || comprimentoRetangulo.text != "0"))
        {
            string areaDoRetanguloFormat = string.Format("{0:F" + 2 + "}", areaDoRetangulo);
            string perimetroDoRetanguloFormat = string.Format("{0:F" + 2 + "}", perimetroDoRetangulo);
            string volumeDoRetanguloFormat = string.Format("{0:F" + 2 + "}", volumeDoRetangulo);

            resultadoText += "Área do Retângulo: " + areaDoRetanguloFormat + "cm²" +
                            "\nPerímetro do Retângulo: " + perimetroDoRetanguloFormat + "cm²" +
                            "\nVolume do Retângulo: " + volumeDoRetanguloFormat + "cm³\n";
        }

        // Cilindro
        if (!string.IsNullOrEmpty(raioCilindro.text) && !string.IsNullOrEmpty(alturaCilindro.text) && (
            raioCilindro.text != "0" || alturaCilindro.text != "0"))
        {
            string areaBaseDoCilindroFormat = string.Format("{0:F" + 2 + "}", areaBaseDoCilindro);
            string volumeDoCilindroFormat = string.Format("{0:F" + 2 + "}", volumeDoCilindro);

            resultadoText += "Área da Base do Cilindro: " + areaBaseDoCilindroFormat + "cm²" +
                            "\nVolume do Cilindro: " + volumeDoCilindroFormat + "cm³\n";
        }

        // Esfera
        if (!string.IsNullOrEmpty(raioEsfera.text) && raioEsfera.text != "0")
        {
            string volumeDaEsferaFormat = string.Format("{0:F" + 2 + "}", volumeDaEsfera);

            resultadoText += "Volume da Esfera: " + volumeDaEsferaFormat + "cm³";
        }

        // Exibir o resultado
        txtResultado.text = resultadoText;


        // Controle do painel de resposta
        if (painelResposta) 
        {
            DesativarInputField(raioCone);
            DesativarInputField(alturaCone);
            DesativarInputField(larguraRetangulo);
            DesativarInputField(alturaRetangulo);
            DesativarInputField(comprimentoRetangulo);
            DesativarInputField(raioCilindro);
            DesativarInputField(alturaCilindro);
            DesativarInputField(raioEsfera);
        }


        if (btnCalcular != null)
        {
            btnCalcular.gameObject.SetActive(false);
            btnVoltar.gameObject.SetActive(true);
        }
    }

    // Função para desativar um InputField
    void DesativarInputField(TMP_InputField inputField)
    {
        if (inputField != null)
        {
            GameObject inputFieldObject = inputField.gameObject;
            if (inputFieldObject != null)
            {
                inputFieldObject.SetActive(false);
            }
        }
    }

    public void VoltarHandler()
    {
        AtivarInputField(raioCone);
        AtivarInputField(alturaCone);
        AtivarInputField(larguraRetangulo);
        AtivarInputField(alturaRetangulo);
        AtivarInputField(comprimentoRetangulo);
        AtivarInputField(raioCilindro);
        AtivarInputField(alturaCilindro);
        AtivarInputField(raioEsfera);
        
        if (btnCalcular != null)
        {
            btnCalcular.gameObject.SetActive(true);
            btnVoltar.gameObject.SetActive(false);
        } 

        txtResultado.text = "";
       
    }

    // Função para ativar um InputField
    void AtivarInputField(TMP_InputField inputField)
    {
        if (inputField != null)
        {
            GameObject inputFieldObject = inputField.gameObject;
            if (inputFieldObject != null)
            {
                inputFieldObject.SetActive(true);
            }
        }
    }

    public void LimparHandler()
    {
        raioCone.text = "0";
        alturaCone.text = "0";
        larguraRetangulo.text = "0";
        alturaRetangulo.text = "0";
        comprimentoRetangulo.text = "0";
        raioCilindro.text = "0";
        alturaCilindro.text = "0";
        raioEsfera.text = "0";
    }
   
}
