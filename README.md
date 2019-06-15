# Poc

#### Download Do Código Fonte

Usando git

```bash
git clone https://github.com/muehringer/Poc.git
```

Ou pode fazer o Download [aqui](https://github.com/muehringer/Poc/archive/master.zip)


### Conteúdo

<p>No projeto as pastas não possuem conteúdo, porém utilizo a estrutura de pastas em uma solução corporativa:
<p>Pasta Docs contém:
<p>MER - Diagrama da modelagem do banco de dados
<p>Requirements - Documentos referente a requisitos do projeto
<p>ScriptsDB - Scripts de banco de dados
<p>Library - Bibliotecas utilizadas no projeto
<p>Draft - Esboço de telas
<p>Prototypes - Protótipos de telas

<p>Pasta Source contém: 
<p>Pasta Backend - Projeto CalcTest, utiliza API em .Net Core versão 2.1.1, C# Sharp, Swagger, JWT - Json Web Token para geração de Token, compressão de dados da API, DDD e TDD.
<p>Pasta Frontend - Projeto CalcTest, utiliza Vue.JS versão 2.0, Bootstrap, HTML e CSS. 
Para facilitar a execução da solução o frontend está incorporado a Solution em .NET Core, dessa forma ao executar a solução, inicializará duas instâncias do browser, uma para a API em .Net Core e outra com a interface do usuário em Vue, o Vue.js e o Bootstrap estão sendo utilizados via includes, lembrando que em um projeto corporativo seria utilizado o Cli-Vue. A justificativa de utilizar o Vue ao invés de React ou Angular, se deve ao fato de levar menos tempo no desenvolvimento. Em um projeto grande corporativo utilizaria Angular por ser padrão de mercado.
  
### Carregar a API no browser com Swagger
  
<p> URL : http://localhost:<porta>/swagger/index.html

#### Utilização das APIs

<p>Primeiro deve utilizar o serviço de Token informando email e senha, como exemplo, basta digitar email igual a senha, lembrando que em um projeto corporativo essas informações estariam em banco de dados, criptografada.<br>
<p>Caso o email e senha estejam corretos será gerado um Token válido.<br>
<p>Para acessar as demais APIs, informar no cabeçalho (Header) Authorization:    Bearer + <TokenGerado>, caso contrário não terá permissão de acesso a nenhuma das APIs.
  

##Obs: Não foquei nos testes unitários e o frontend apenas um exemplo. Comentei o atributo [Authorize] das controllers para não ter que gerar o token a todo momento, caso queira gerar o token basta descomentar este atributo. Não utilizei Docker porque o Windows é Home Edition.


## Licence

Source code can be found on [github](https://github.com/georgeOsdDev/markdown-edit), licenced under [MIT](http://opensource.org/licenses/mit-license.php).

Developed by [Alexandre Muehringer Alves](https://github.com/muehringer)

