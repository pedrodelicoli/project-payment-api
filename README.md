# Bem-vindos ao repositório do PaymentApi

## Contexto

---

Esse projeto foi desenvolvido para uma vaga de backend.

A proposta era desenvolver uma API de cadastro de vendas.

---

## Como instalar

Pre-requisitos para rodar o projeto: 
- dotnet 6.0

Copie o ssh do projeto `git@gitlab.com:pedrodelicoli/tech-test-payment-api.git`

* Abra um terminal no seu computador e utilize os comandos a baixo na ordem que são apresentados:

  * `git clone git@gitlab.com:pedrodelicoli/tech-test-payment-api.git`
  * `cd tech-test-payment-api/PaymentApi/src`
  * `dotnet build`

---

## ARQUITETURA DO PROJETO

- Foi usado arquitetura em camadas ( Api -> Application -> Domain -> Repository -> Database). Dessa forma foi trabalhado a injeção
de dependência para que as camadas inferiores não dependam de camadas externas.

- Foi utilizado Entity Framework In Memory Database como bando de dados do projeto.

- Para os testes foi utilizado a biblioteca xUnit. Usando também o FluentAssertions para as validações dos dados e o Moq para simular 
o mock dos repositórios e do resultado do AutoMapper.

---

## Contato
  
<h2> Pedro Delicoli </h2>
<img src="https://cdn-icons-png.flaticon.com/512/25/25231.png" alt="Github" width="20"/> https://github.com/pedrodelicoli

<img src="https://cdn.worldvectorlogo.com/logos/linkedin-icon-2.svg" alt="LinkedIn" width="20"/> https://www.linkedin.com/in/pedrodelicoli/
<h3> Email: pedrodelicoli@hotmail.com </h3>

---
