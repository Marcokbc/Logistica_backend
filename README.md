# API Logistica
 [![NPM](https://img.shields.io/npm/l/react)](https://github.com/devsuperior/sds1-wmazoni/blob/master/LICENSE) 

# Sobre o projeto

A aplicação consiste em uma API Rest, seguindo os princípios do Clean Code, que gerencia Pedidos, ou seja, ela cadastra pedidos, informando o nome do pedido, o local de origem na qual aquele pedido será enviado, o destino daquele pedido e o status do pedido (Efetuado, Enviado, Trânsito, Despachado ou Retirado), no entanto, ao passar essas informações ele gera automaticamente um código de rastreio para que se possa rastrear o pedido através de um método GET. 

Além disso, a API também conta com outra entidade, a classe Rota, na qual cadastra o local na qual aquele pedido se encontra em um determinado momento, informando o Id do pedido a qual aquela rota pertence, o nome da cidade em que se encontra e o horário atual.
Outrossim, A API consta com os métodos HTTP: GET, POST, PUT e DELETE, e variações dos mesmos, como um método GET que busca por ID e outro que busca pelo código de rastreio. 

Por fim, a Web API consta com autenticação via JWT e testes unitários utilizando xUnit, além de obviamente utilizar o Entity Framework Core para se conectar ao banco de dados, que por sua vez é o SQL Server.

## FrontEnd
Confira também o frontend do projeto.
https://github.com/Marcokbc/Logistica_frontend

## Modelo conceitual
![Marco](https://github.com/Marcokbc/Logistica_backend/assets/88397083/b1cfb763-e98f-4939-a33c-dff0ee443196)

# Tecnologias utilizadas
## Back end
- C#
- ASP .NET Core
- Entity Framework
- xUnit

## Banco de Dados
- SQL Server

# Como executar o projeto

Pré-requisitos: .NET 6 e SQL Server

```bash
# clonar repositório
git clone https://github.com/Marcokbc/Logistica_backend
```
Configure a String de conexão do banco de dados no arquivo appsettings.json. 
```
# adicionar e excutar as migrações
dotnet ef migrations add NomeDaMigracao
dotnet ef database update

#Pacotes NuGet
dotnet restore
dotnet build

# executar o projeto
dotnet run
```

# Autor

Marco Antônio Meira de Lima

https://www.linkedin.com/in/marco-antonio-meira-dev/
