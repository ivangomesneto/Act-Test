# **CashFlow.WebApi**

Bem-vindo � aplica��o **CashFlow.WebApi**. Este projeto utiliza Docker Compose para execu��o e inclui funcionalidades como conex�o a um banco de dados MySQL e grava��o de logs em arquivos locais.

---

## **Antes de Executar a Aplica��o**

� necess�rio que o docker esteja rodando na m�quina que executar� a aplica��o


## **Executando a Aplica��o**

### **Passos para Iniciar**
1. **Selecionar o perfil de inicializa��o**:
   - No Visual Studio, selecione o perfil **docker-compose**.
2. **Iniciar a aplica��o**:
   - Pressione **F5** para compilar e executar o projeto.
3. **Acessar a documenta��o Swagger**:
   - Se o navegador n�o abrir automaticamente ap�s a inicializa��o, acesse manualmente a URL:
     ```
     https://localhost:61701/swagger/index.html
     ```

---

## **Configura��es da Aplica��o**

### **Conex�o com o Banco de Dados**
- A string de conex�o do banco MySQL est� localizada no arquivo `appsettings.json`:
  ```json
  "PersistenceModule": {
      "MySQLConnection": "SuaStringDeConexaoAqui"
  }

Substitua "SuaStringDeConexaoAqui" pelos valores corretos para conectar-se ao seu banco.

### **Logs**
- Os logs da aplica��o s�o gravados localmente na pasta Logs do projeto.
- Divis�o dos Logs:
    - Logs gerais: Cont�m informa��es gerais da aplica��o.
    - Logs de erros: Registros detalhados de erros ocorridos durante a execu��o.
    - Logs de banco: Detalham as intera��es com o banco de dados.

### **Tecnologias Utilizadas**
- Docker Compose: Para orquestra��o de containers.
- Swagger: Documenta��o e teste de APIs.
- Entity Framework Core: ORM para comunica��o com o banco de dados.
- MySQL: Banco de dados relacional.
- Serilog: Biblioteca para gera��o de logs estruturados.

### **Ambiente de Desenvolvimento**
- URL Local:
    - Swagger: https://localhost:61701/swagger/index.html

- Logs:
    - Diret�rio: Logs/

Certifique-se de que todas as depend�ncias (como Docker, MySQL e Visual Studio) est�o corretamente configuradas no ambiente local antes de iniciar o projeto.