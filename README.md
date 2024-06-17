# Escopo do Projeto: Aplicação de Cadastro com PostgreSQL

## 1. Introdução
Desenvolver uma aplicação desktop utilizando Windows Forms e banco de dados PostgreSQL para gerenciar um cadastro simples com campos de texto e numérico. O projeto visa demonstrar o uso de CRUD (Create, Read, Update, Delete) básico integrado com um banco de dados relacional, além de registrar logs de operações.

## 2. Objetivos
- Criar uma aplicação que permita inserir, atualizar, e deletar registros de um cadastro.
- Utilizar o banco de dados PostgreSQL para armazenar os dados do cadastro.
- Registrar em uma tabela de log as operações de inserção, atualização e deleção realizadas na tabela principal de cadastro.
- Implementar validações no banco de dados para garantir a integridade dos dados.

## 3. Funcionalidades

### 3.1. Interface Gráfica
**Formulário Principal (Form1):**
- Interface principal da aplicação contendo os campos para inserir dados (`txtTexto` para texto e `txtNumero` para número) e botões para realizar as operações CRUD.
- **Campos Obrigatórios:** Garantir que ambos os campos (`txtTexto` e `txtNumero`) sejam preenchidos antes de permitir a inserção de um novo registro.

### 3.2. Operações CRUD
- **Inserir Registro (btnInserirClick):** Ao clicar no botão "Inserir", os dados inseridos nos campos de texto e número são adicionados à tabela cadastro no banco de dados PostgreSQL. Após a inserção, uma mensagem de sucesso é exibida.
- **Atualizar Registro (btnAtualizarClick):** Ao clicar no botão "Atualizar", o registro correspondente ao número fornecido é atualizado com o novo texto fornecido. Caso nenhum registro seja encontrado com o número fornecido, uma mensagem informativa é exibida. Após a atualização bem-sucedida, uma mensagem de sucesso é exibida.
- **Deletar Registro (btnDeletarClick):** Ao clicar no botão "Deletar", o registro correspondente ao número fornecido é removido da tabela cadastral. Caso nenhum registro seja encontrado com o número fornecido, uma mensagem informativa é exibida. Após a deleção bem-sucedida, uma mensagem de sucesso é exibida.

### 3.3. Validar Número Único
- **Validação no Banco de Dados:** Implementar uma restrição no banco de dados PostgreSQL para garantir que o número inserido seja único na tabela cadastro. Isso é feito através de uma chave única ou outra restrição adequada.

### 3.4. Registros de Log
- **Tabela de Log (log_operacoes):** Criar uma tabela no banco de dados para registrar as operações realizadas na tabela cadastral. Cada entrada no log deve conter a data/hora da operação e o tipo de operação (Inserção, Atualização, Deleção).

## 4. Tecnologias Utilizadas
- **Windows Forms:** Interface gráfica para interação com o usuário.
- **PostgreSQL:** Banco de dados relacional para armazenamento dos dados do cadastro e do log de operações.
- **Npgsql:** Biblioteca .NET para conexão e interação com o PostgreSQL a partir do C#.

## 5. Entregáveis
- **Código Fonte:** Arquivos do projeto contendo o código fonte da aplicação Windows Forms.
- **Backup do Banco de dados**

## 6. Considerações Finais
O projeto visa proporcionar uma experiência prática na implementação de operações básicas de CRUD com integração a um banco de dados PostgreSQL, utilizando uma abordagem focada em boas práticas de desenvolvimento e segurança de dados.
