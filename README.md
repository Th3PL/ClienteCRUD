# ClienteCRUD

Este projeto é uma aplicação de CRUD (Create, Read, Update, Delete) para gerenciamento de clientes com diferentes tipos de endereços. Ele utiliza **ASP.NET MVC Core** com uma abordagem de **Modelagem DDD (Domain-Driven Design)** e o **DevExpress** para criar grids dinâmicos na interface.

## Tecnologias Utilizadas

- **ASP.NET MVC Core**: Framework principal para a construção da aplicação web.
- **DevExtreme (DevExpress)**: Biblioteca para criar grids e componentes interativos e estilizados.
- **Entity Framework Core**: Para interação com o banco de dados e manipulação de entidades.
- **SQL Server**: Banco de dados utilizado na aplicação.
- **HTML/CSS/JavaScript**: Para estilização e interatividade no frontend.
- **C#**: Linguagem de programação para a lógica do servidor e do cliente.

## Funcionalidades

- **CRUD completo de Clientes**: Criação, leitura, atualização e exclusão de clientes.
- **Tipos de Endereço**: Cada cliente pode ter um endereço classificado como **Fiscal**, **Cobrança** ou **Entrega**.
- **Integração com Grids do DevExtreme**: Exibe uma lista interativa de clientes com colunas editáveis para as propriedades.
- **Validação e controle de erros**: Manipulação de erros durante operações CRUD.
- **Customização de Tabelas**: As tabelas permitem edição direta com suporte a dropdowns para selecionar o tipo de endereço.

## Requisitos

- **.NET 6.0 ou superior**
- **SQL Server**
- **DevExpress** (versão trial ou licenciado)
