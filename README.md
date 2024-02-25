# Livraria Web

Este projeto foi desenvolvido utilizando ASP.Net Core MVC e MySQL, proporcionando um Sistema de Empr�stimo de Livros Online eficiente.

## Funcionalidades

- Adi��o, edi��o e exclus�o de empr�stimos.
- **Registro do status atual dos empr�stimos em uma tabela no Excel.**

## Capturas de Tela

### P�gina Inicial
![Home](assets/Capa.jpeg)

### Tabela de Empr�stimos
![Tabela](assets/Tabela.jpeg)

# Testando

Para testar o projeto, siga os passos abaixo:

1. Modifique o arquivo 'appsettings.json' para incluir sua pr�pria Connection String:

   ```json
   "ConnectionStrings": {
       "LibraryConnection": "Sua Conex�o Aqui"
   }

2. Abra Algum Editor De Texto e Digite o Comando:
 ```dotnet run ```

3. Baixe as Migra��es
 ```dotnet ef database update ```

E Pronto o Projeto j� esta em Execu��o

# Deploy

Para acessar o Projeto j� em Produ��o Basta acessar o Link: [Web_Library-MVC](https://webl-ibrary-prado.azurewebsites.net/)
