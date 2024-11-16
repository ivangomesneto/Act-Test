# **CashFlow.WebApi**

Bem-vindo à aplicação **CashFlow.WebApi**. Este projeto utiliza Docker Compose para execução e inclui funcionalidades como conexão a um banco de dados MySQL e gravação de logs em arquivos locais.

---

## **Antes de Executar a Aplicação**

É necessário que o docker esteja rodando na máquina que executará a aplicação

---

## **Executando a Aplicação**

### **Passos para Iniciar**
1. **Selecionar o perfil de inicialização**:
   - No Visual Studio, selecione o perfil **docker-compose**.
2. **Iniciar a aplicação**:
   - Pressione **F5** para compilar e executar o projeto.
3. **Acessar a documentação Swagger**:
   - Se o navegador não abrir automaticamente após a inicialização, acesse manualmente a URL:
     ```
     https://localhost:61701/swagger/index.html
     ```

---

## **Configurações da Aplicação**

### **Conexão com o Banco de Dados**
- A string de conexão do banco MySQL está localizada no arquivo `appsettings.json`:
  ```json
  "PersistenceModule": {
      "MySQLConnection": "SuaStringDeConexaoAqui"
  }

Substitua "SuaStringDeConexaoAqui" pelos valores corretos para conectar-se ao seu banco.

### **Logs**
- Os logs da aplicação são gravados localmente na pasta Logs do projeto.
- Divisão dos Logs:
    - Logs gerais: Contêm informações gerais da aplicação.
    - Logs de erros: Registros detalhados de erros ocorridos durante a execução.
    - Logs de banco: Detalham as interações com o banco de dados.

---

### **Tecnologias Utilizadas**
- Docker Compose: Para orquestração de containers.
- Swagger: Documentação e teste de APIs.
- Entity Framework Core: ORM para comunicação com o banco de dados.
- MySQL: Banco de dados relacional.
- Serilog: Biblioteca para geração de logs estruturados.

---

### **Ambiente de Desenvolvimento**
- URL Local:
    - Swagger: https://localhost:61701/swagger/index.html

- Logs:
    - Diretório: Logs/

Certifique-se de que todas as dependências (como Docker, MySQL e Visual Studio) estão corretamente configuradas no ambiente local antes de iniciar o projeto.
