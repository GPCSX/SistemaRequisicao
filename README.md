# Sistema de Gerenciamento de Requisição

## Visão Geral

Este projeto é um sistema simples para gerenciamento de tarefas, implementado em C# usando .NET Framework. Ele inclui a funcionalidade de cadastrar tarefas, verificar feriados antes de realizar um cadastro e outras operações básicas de CRUD (Create, Read, Update, Delete).

## Funcionalidades

- Cadastro de Tarefas: Permite adicionar, visualizar, atualizar e excluir tarefas.
- Verificação de Feriado: Antes de cadastrar uma tarefa, o sistema verifica se a data é um feriado usando uma API externa.

## Tecnologias Utilizadas

- C#
- .NET Framework
- Entity Framework Core (para acesso ao banco de dados)
- ASP.NET Core (para construção da API)
- PostgresSQL (como banco de dados)
- [API de Feriados](https://api.invertexto.com/api-feriados) para verificação de feriados

## Configuração do Ambiente de Desenvolvimento

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/GPCSX/SistemaRequisicao.git
   cd SistemaRequisicao
