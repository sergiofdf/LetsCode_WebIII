# LetsCode_WebIII

## Descrição do Projeto
Desenvolvimento de uma API em C# com um exemplo de CRUD para fixação dos assuntos vistos em aula.

> Curos Let's Code, programa Top Coders, Professora Amanda Mantovani

---
## Enunciado

Construa um cadastro completo (CRUD) de clientes. Neste cadastro, o cliente deve possuir cpf, nome, data de nascimento e idade.

---

## Conceitos abordados
- Desenvolvimento de uma API com "ASP.NET Core Web App (Model-View-Controller)";
- Aplicação de métodos do protocolo HTTP para criar um CRUD;
- REST API;
- Open API;
- ApiController;
- Decorators;
- Passagem por rota, query e body;
- Data annotations para validações de dados;
- Produces e consumes;
- Definição de códigos e mensagens de retorno;
- Action Result;
- Conexão com banco SQL utilizando Dapper;
- Boas práticas de segurança (proteção de connection strings, uso de dynamic parameters, etc);
- Aplicação de ResourceFilter, ActionFilter e ExceptionFilter.

--- 
## 🚀 Como executar o programa
- Clonar o repositório em uma pasta local:
    `git clone https://github.com/sergiofdf/LetsCode_WebIII.git`
  
- Abra a solução do projeto com o visual studio, arquivo `LetsCode_WebIII.sln`.

- Dentro do projeto principal da API ('APIEventosBotucatu'), será necessário criar um arquivo `appsettings.json ` com as credenciais para acesso ao banco de dados. Segue o exemplo do modelo do conteúdo do arquivo. Troque os campos ilustrados em português pelos dados para o acesso ao banco de dados.

``` 
"Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=NomeServidor;Database=NomeBancoDeDados; User Id=Usuario; Password=Senha; Encrypt=False"
  },
  "secretKey": "chave para criação de token JWT"
}
```

- Execute o projeto com `CTRL + F5`