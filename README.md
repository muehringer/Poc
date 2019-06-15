# Poc

#### Download Do C�digo Fonte

Usando git

```bash
git clone https://github.com/muehringer/Poc.git
```

Ou pode fazer o Download [aqui](https://github.com/muehringer/Poc/archive/master.zip)


### Conte�do

<p>No projeto as pastas n�o possuem conte�do, por�m utilizo a estrutura de pastas em uma solu��o corporativa:
<p>Pasta Docs cont�m:
<p>MER - Diagrama da modelagem do banco de dados
<p>Requirements - Documentos referente a requisitos do projeto
<p>ScriptsDB - Scripts de banco de dados
<p>Library - Bibliotecas utilizadas no projeto
<p>Draft - Esbo�o de telas
<p>Prototypes - Prot�tipos de telas

<p>Pasta Source cont�m: 
<p>Pasta Backend - Projeto CalcTest, utiliza API em .Net Core vers�o 2.1.1, C# Sharp, Swagger, JWT - Json Web Token para gera��o de Token, compress�o de dados da API, DDD e TDD.
<p>Pasta Frontend - Projeto CalcTest, utiliza Vue.JS vers�o 2.0, Bootstrap, HTML e CSS. 
Para facilitar a execu��o da solu��o o frontend est� incorporado a Solution em .NET Core, dessa forma ao executar a solu��o, inicializar� duas inst�ncias do browser, uma para a API em .Net Core e outra com a interface do usu�rio em Vue, o Vue.js e o Bootstrap est�o sendo utilizados via includes, lembrando que em um projeto corporativo seria utilizado o Cli-Vue. A justificativa de utilizar o Vue ao inv�s de React ou Angular, se deve ao fato de levar menos tempo no desenvolvimento. Em um projeto grande corporativo utilizaria Angular por ser padr�o de mercado.
  
### Carregar a API no browser com Swagger
  
<p> URL : http://localhost:<porta>/swagger/index.html

#### Utiliza��o das APIs

<p>Primeiro deve utilizar o servi�o de Token informando email e senha, como exemplo, basta digitar email igual a senha, lembrando que em um projeto corporativo essas informa��es estariam em banco de dados, criptografada.<br>
<p>Caso o email e senha estejam corretos ser� gerado um Token v�lido.<br>
<p>Para acessar as demais APIs, informar no cabe�alho (Header) Authorization:    Bearer + <TokenGerado>, caso contr�rio n�o ter� permiss�o de acesso a nenhuma das APIs.
  

##Obs: N�o foquei nos testes unit�rios e o frontend apenas um exemplo. Comentei o atributo [Authorize] das controllers para n�o ter que gerar o token a todo momento, caso queira gerar o token basta descomentar este atributo. N�o utilizei Docker porque o Windows � Home Edition.


## Licence

Source code can be found on [github](https://github.com/georgeOsdDev/markdown-edit), licenced under [MIT](http://opensource.org/licenses/mit-license.php).

Developed by [Alexandre Muehringer Alves](https://github.com/muehringer)

