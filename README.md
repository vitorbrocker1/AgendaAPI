# 📌 AgendaAPI

## 📖 Descrição
API REST desenvolvida para gerenciamento de agendamentos.  
O sistema permite criar, consultar, atualizar e remover compromissos, garantindo organização e controle das informações.

Cada agendamento pode conter:
-  Data  
-  Horário  
-  Descrição  
-  Usuário vinculado  

---

## 🛠️ Tecnologias Utilizadas

### 🔹 Back-end
- C#
- ASP.NET Core
- Entity Framework Core
- SQL Server

### 🔹 Ferramentas
- Swagger
- Postman
- Visual Studio

---

## 🗄️ Banco de Dados
Modelagem relacional estruturada conforme diagrama próprio do projeto.

📌 Diagrama do banco:

<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/d904781e-fc79-40cd-8d69-cc83faa7916e" />

---

## 🔗 APIs RESTful

O sistema fornece endpoints para:

-  Criar agendamentos  
-  Listar todos os registros  
-  Buscar por ID  
-  Buscar por usuário  
-  Atualizar informações  
-  Remover registros  

---

## 🏗️ Arquitetura em Camadas

O projeto segue separação de responsabilidades:

- **Controller** → Exposição dos endpoints  
- **Service** → Regras de negócio  
- **Repository** → Acesso ao banco de dados  
- **DTOs** → Transferência segura de dados  
