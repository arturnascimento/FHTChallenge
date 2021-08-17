# FHTChallenge

Objetivo
Desenvolver uma API em C# com .NET Core que simule algumas funcionalidades de um banco digital. Nesta simulação considere que não há necessidade de autenticação.

Desafio
Você deverá garantir que o usuário conseguirá realizar uma movimentação de sua conta corrente para quitar uma dívida.

Cenários
DADO QUE eu consuma a API
QUANDO eu chamar a mutation sacar informando o número da conta e um valor válido
ENTÃO o saldo da minha conta no banco de dados diminuirá de acordo
E a mutation retornará o saldo atualizado.

DADO QUE eu consuma a API
QUANDO eu chamar a mutation sacar informando o número da conta e um valor maior do que o meu saldo
ENTÃO a mutation me retornará um erro do GraphQL informando que eu não tenho saldo suficiente

DADO QUE eu consuma a API
QUANDO eu chamar a mutation depositar informando o número da conta e um valor válido
ENTÃO a mutation atualizará o saldo da conta no banco de dados
E a mutation retornará o saldo atualizado.

DADO QUE eu consuma a API
QUANDO eu chamar a query saldo informando o número da conta
ENTÃO a query retornará o saldo atualizado.

O desafio consistia em construir uma API GraphQL para esta mesma solução, portanto não consegui um entregável em tempo hábil, resolvi mudar para REST API.
Como pontos de melhoria, estou estudando graphql e TDD no momento.

Técnologias utilizadas no projeto:
- .Net Core 5.0
- Swagger para a documentação da API
- ORM EntityFrameWork
- Banco de Dados MS Sql Server
- XUnit(Não consegui implementar os testes de Unidade.)

