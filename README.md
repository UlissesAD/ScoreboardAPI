<h1 align="center">
  Players API
</h1>
<br>  
<div align="center">
 <p>API simples desenvolvida com ASP.NET e EntityFramework</p>
</div>
<div>
<p> API para um jogo ou plataforma que possui um sistema de pontuação entre os usuários, retornando para o cliente informações como Nome do Jogador/Usuário, Pontuação atual e Creditos dentro da plataforma</p>
<br>
<p> Atualmente hospedada pela Azure: <a href="https://ulissesplayerapi.azurewebsites.net/">LINK</a></p>
<br>
</div>
<div>
<ul>
<li>Suporta os metodos padrão de requisições HTTP.</li>
<li>Swagger para a documentação.</li>
<li>Usuários/Jogadores com Id repetido ou invalidos não podem ser criados, o que danificaria o banco de dados.</li>
<li>Rota TOP traz informação direta para a criação de um placar geral, menos dados enviados e processados pelo lado do cliente</li>
<ul>
<br>
</div>
<h3>Estrutura</h3> 
	
````json
{
	"Id": "1",
	"Nome": "Ulisses Auresco",
	"Score": "150",
	"Cash": "0",	
},
````

<h3>Métodos</h3> 

```C#
//Metodos:
.GET api/Players    		//Obter todos os Jogadores
.GET api/Players/{id}    	//Obter um Jogador pelo ID
.GET api/Players/TOP/{max}      //Obter no maximo max jogadores com a maior pontuação
.POST api/Players    		//Criar um novo Jogador
.PUT api/Players /{id}    	//Alterar um Jogador cadastrado
.DELETE api/Players /{id}   	//Deletar um Jogador cadastrado
```
<br>
<div>
<br>  
<p>API para testes locais esta configurada para a porta 5001/5000 e ao iniciar para a rota api/Players isso pode ser alterado em .</p>
<p>Ao clonar este repositório é necessário a vincular uma Connection String de um banco dedos SQL em .</p>
<p>Documentação e Testes pelo Swagger na rota raiz, ou os teste pode ser realizados pela plataforma externa <a href="https://www.postman.com/">Postman</a> </p>
</div>
<br>
<div align="center" style=" display: inline_block;"> 
 <a href="https://visualstudio.microsoft.com/pt-br/">
  <img align="center" alt="CSharp"  height="70" width="70"  src="https://icongr.am/devicon/csharp-original.svg?size=128&color=currentColor">
  <img align="center" alt="VisualStudio" height="70" width="70" src="https://icongr.am/devicon/visualstudio-plain.svg?size=128&color=currentColor">
    </a>
</div>
