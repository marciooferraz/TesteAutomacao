using System;
using Xunit;


namespace TesteAutomacao
{
    
    public class QATest
    {
        [Fact]
        // CT01 - [POS] VALIDAR ACESSO A URL A P�GINA "SIMULADOR DE INVESTIMENTO"
        public void CT01_TesteValidarAcesso()
        {
            //Instanciando a classe Metodos
            QAMetodos m = new QAMetodos();

            //Abrir Navegador
            m.AbrirNavegador();

            //Valida��es do caso de teste
            m.MetodoTestAcesso();

            //Fechar Navegador
            m.FecharNavegador();
        }

        [Fact]
        //CT02 - [NEG] VALIDAR SIMULA��O DE INVESTIMENTO COM TODOS OS CAMPOS EM BRANCO
        public void CT02_TesteValidarSimulCamposBranco()
        {
            //Instanciando a classe Metodos
            QAMetodos m = new QAMetodos();

            //Abrir Navegador
            m.AbrirNavegador();

            //Valida��es do caso de teste
            m.MetodoValidaSimulCamposBranco();

            //Fechar navegador
            m.FecharNavegador();
        }

        [Fact]
        //CT03 - [NEG] VALIDAR SIMULA��O DE INVESTIMENTO COM VALORES ABAIXO DO MINIMO 
        public void CT03_TesteValidarValorAbaixoMinimo()
        {
            QAMetodos m = new QAMetodos();

            //Abrir Navegador
            m.AbrirNavegador();

            //Valida��es do caso de teste
            m.MetodoValorAbaixoMinimo();

            //Fechar navegador
            m.FecharNavegador();

        }
        
        [Fact]
        //CT04 - [NEG] VALIDAR SIMULA��O DE INVESTIMENTO COM VALORES INV�LIDOS
        //(CARACTERES DIFERENTES DE NUMERIDOS E 0 NO CAMPO MESES)
        public void CT04_TesteValidarValorInvalido()
        {
            QAMetodos m = new QAMetodos();

            //Abrir Navegador
            m.AbrirNavegador();

            //Valida��es do caso de teste
            m.MetodoValorInvalido();

            //Fechar navegador
            m.FecharNavegador();
        }

        [Fact]
        //CT05 - [POS] VALIDAR SIMULA��O DE INVESTIMENTO PREENCHENDO OS CAMPOS CORRETAMENTE
        public void CT05_TesteValidarSimularInvestimento()
        {
            QAMetodos m = new QAMetodos();

            //Abrir Navegador
            m.AbrirNavegador();

            //Valida��es do caso de teste
            m.SimularInvestimento();

            //Fechar navegador
            m.FecharNavegador();
        }
    }
}