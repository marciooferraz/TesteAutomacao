using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Xunit;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace TesteAutomacao
{
    class QAMetodos
    {
 
        IWebDriver driver = new ChromeDriver(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            );


        //Metodo para abrir navegador Chrome
        public void AbrirNavegador()
        {
            driver.Navigate().GoToUrl("https://www.sicredi.com.br/html/ferramenta/simulador-investimento-poupanca/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        //Metodo para fechar navagador
        public void FecharNavegador()
        {
            Thread.Sleep(2000);
            driver.Quit();
        }

        

        //Metodo para testar acesso a url
        public void MetodoTestAcesso()
        {
            //RESULTADOS ESPERADOS
            //Validar titulo da página 
            Assert.Contains("Simulador de investimento - Poupança | Sicredi", driver.Title);

            //Validar logo SICREDI
            driver.FindElement(By.ClassName("logoPrevidencia"));

            string texto = driver.FindElement(By.XPath(xpathToFind: "html/body/div[1]/div[1]/div[1]/DIV[1]")).Text;

            //Validar texto "Simulador de INVESTIMENTO" no cabeçalho da página 
            Assert.Contains("Simulador de" + Environment.NewLine + "INVESTIMENTO", texto);


        }

        //Metodo para testar Simulação com campos em branco
        public void MetodoValidaSimulCamposBranco()
        {
            Thread.Sleep(2000);

            //Clicar no botão SIMULAR
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[5]/ul/li[2]/button")).Click();

            Thread.Sleep(3000);

            //RESULTADO ESPERADO 
            //Verificar exibição do texto de valor mínimo
            Assert.Equal("Valor mínimo de 20.00", 
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[2]/div[2]/label[2]")).Text);

            //Verificar exibição do texto de valor mínimo
            Assert.Equal("Valor mínimo de 20.00",
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[3]/div[2]/label[2]")).Text);

            //Verificar de texto Obrigatóio
            Assert.Equal("Obrigatório",
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[4]/div[2]/div[1]/label[2]")).Text);

        }

        //Metodo para iserção de valores
        public void InserirValor(String valor, String campo)
        {
            driver.FindElement(By.XPath(campo)).SendKeys(valor);
        }

        //
        public void MetodoValorAbaixoMinimo()
        {
            //Preenchendo campos com valores inválidos
            InserirValor("1000", "/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[2]/div[2]/input");
            InserirValor("1000", "/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[3]/div[2]/input");
            InserirValor("0", "/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[4]/div[2]/div[1]/input");

            //Clicar no botão SIMULAR
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[5]/ul/li[2]/button")).Click();

            Thread.Sleep(500);

            //RESULTADO ESPERADO
            //Verificar exibição do texto de valor mínimo
            Assert.Equal("Valor mínimo de 20.00",
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[2]/div[2]/label[2]")).Text);

            //Verificar exibição do texto de valor mínimo
            Assert.Equal("Valor mínimo de 20.00",
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[3]/div[2]/label[2]")).Text);

            //Verificar de texto Valor esperado não confere
            Assert.Equal("Valor esperado não confere",
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[4]/div[2]/div[1]/label[2]")).Text);
            
        }
        
        //
        public void MetodoValorInvalido()
        {
            //Preenchendo campos com valores inválidos
            InserirValor("letra", "/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[2]/div[2]/input");
            InserirValor("letra", "/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[3]/div[2]/input");
            InserirValor("a", "/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[4]/div[2]/div[1]/input");

            Thread.Sleep(500);

            //RESULTADO ESPERADO
            //Verificar que valor texto não foi inserido no campo
            Assert.DoesNotContain("letra",
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[2]/div[2]/input")).Text);

            //Verificar que valor texto não foi inserido no campo
            Assert.DoesNotContain("letra", 
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[3]/div[2]/input")).Text);

            //Verificar que valor texto não foi inserio no campo
            Assert.DoesNotContain("a",
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[4]/div[2]/div[1]/input")).Text);

        }

        //
        public void SimularInvestimento()
        {
            //Preenchendo campos com valores inválidos
            InserirValor("10000", "/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[2]/div[2]/input");
            InserirValor("9000", "/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[3]/div[2]/input");
            InserirValor("12", "/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[4]/div[2]/div[1]/input");

            IWebElement numMes = driver.FindElement(
                By.XPath(
                    "/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[4]/div[2]/div[1]/input"));

            String numMesVal = numMes.GetAttribute("value");

            //Clicar no botão SIMULAR
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[1]/form/div[5]/ul/li[2]/button")).Click();

            Thread.Sleep(1000);

            //RESUTADO ESPERADO
            //Verifica existencia do texto com número de meses inserido pelo usuário
            Assert.Contains("Em " + numMesVal+ " meses você terá guardado", 
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[2]/span[1]")).Text);

            //Verificar exibição de simulação
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[2]/div[1]/table"));

            //Verificar exibição do botão "REFAZER SIMULAÇÃO"
            Assert.Equal("REFAZER A SIMULAÇÃO",
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div[2]/a")).Text);

        }
    }
}
