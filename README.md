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

<div style="display: flex; align-items: center; justify-content: space-between;">
  <div>
    <h2> Pedro Delicoli </h2>
  <div style="display: flex;align-items: center;">
    <img src="./frontend/my-app/images/github-logo.png" alt="LinkedIn" style="width:20px;"/> https://github.com/pedrodelicoli
  </div>
  <div style="display: flex;align-items: center;">
    <img src="./frontend/my-app/images/linkedin-logo.png" alt="LinkedIn" style="width:20px;"/> https://www.linkedin.com/in/pedrodelicoli/
  </div>
  <br/>
  Email: pedrodelicoli@hotmail.com  
<br/>

---


## INSTRUÇÕES PARA O TESTE TÉCNICO

- Crie um fork deste projeto (https://gitlab.com/Pottencial/tech-test-payment-api/-/forks/new). É preciso estar logado na sua conta Gitlab;
- Adicione @Pottencial (Pottencial Seguradora) como membro do seu fork. Você pode fazer isto em  https://gitlab.com/`your-user`/tech-test-payment-api/settings/members;
 - Quando você começar, faça um commit vazio com a mensagem "Iniciando o teste de tecnologia" e quando terminar, faça o commit com uma mensagem "Finalizado o teste de tecnologia";
 - Commit após cada ciclo de refatoração pelo menos;
 - Não use branches;
 - Você deve prover evidências suficientes de que sua solução está completa indicando, no mínimo, que ela funciona;

## O TESTE
- Construir uma API REST utilizando .Net Core, Java ou NodeJs (com Typescript);
- A API deve expor uma rota com documentação swagger (http://.../api-docs).
- A API deve possuir 3 operações:
  1) Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento";
  2) Buscar venda: Busca pelo Id da venda;
  3) Atualizar venda: Permite que seja atualizado o status da venda.
     * OBS.: Possíveis status: `Pagamento aprovado` | `Enviado para transportadora` | `Entregue` | `Cancelada`.
- Uma venda contém informação sobre o vendedor que a efetivou, data, identificador do pedido e os itens que foram vendidos;
- O vendedor deve possuir id, cpf, nome, e-mail e telefone;
- A inclusão de uma venda deve possuir pelo menos 1 item;
- A atualização de status deve permitir somente as seguintes transições: 
  - De: `Aguardando pagamento` Para: `Pagamento Aprovado`
  - De: `Aguardando pagamento` Para: `Cancelada`
  - De: `Pagamento Aprovado` Para: `Enviado para Transportadora`
  - De: `Pagamento Aprovado` Para: `Cancelada`
  - De: `Enviado para Transportador`. Para: `Entregue`
- A API não precisa ter mecanismos de autenticação/autorização;
- A aplicação não precisa implementar os mecanismos de persistência em um banco de dados, eles podem ser persistidos "em memória".

## PONTOS QUE SERÃO AVALIADOS
- Arquitetura da aplicação - embora não existam muitos requisitos de negócio, iremos avaliar como o projeto foi estruturada, bem como camadas e suas responsabilidades;
- Programação orientada a objetos;
- Boas práticas e princípios como SOLID, DDD (opcional), DRY, KISS;
- Testes unitários;
- Uso correto do padrão REST;
