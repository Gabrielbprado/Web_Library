# Livraria Web

Este projeto foi desenvolvido utilizando ASP.Net Core MVC e MySQL, proporcionando um Sistema de Empréstimo de Livros Online eficiente.

## Funcionalidades

- Adição, edição e exclusão de empréstimos.
- **Registro do status atual dos empréstimos em uma tabela no Excel.**

## Capturas de Tela

### Página Inicial
![Home](assets/Capa.jpeg)

### Tabela de Empréstimos
![Tabela](assets/Tabela.jpeg)

# Testando

Para testar o projeto, siga os passos abaixo:

1. Modifique o arquivo 'appsettings.json' para incluir sua própria Connection String:

   ```json
   "ConnectionStrings": {
       "LibraryConnection": "Sua Conexão Aqui"
   }

2. Abra Algum Editor De Texto e Digite o Comando:
 ```dotnet run ```

3. Baixe as Migrações
 ```dotnet ef database update ```

E Pronto o Projeto já esta em Execução

# Deploy

Para acessar o Projeto já em Produção Basta acessar o Link: [Web_Library-MVC](https://webl-ibrary-prado.azurewebsites.net/)
