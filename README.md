# Documentação da API

---

## **1. Auth**

### **Endpoints disponíveis**

#### 1.1. Log-in  
- **Descrição**: Realiza o login e retorna um token para autenticação.  
- **Método HTTP**: `POST`  
- **Entrada**: Credenciais de usuário:
  ```json
  {
    "userName": "Francisco",
    "password": "123456"
  }
- **Saída**: Um token no formato JWT.  

#### 1.2. Autorizar Token  
- Após obter o token no endpoint de Log-in:
  1. Pressione o botão **Authorize** no Swagger.
  2. Insira o token no formato:  
     ```plaintext
     Bearer <seu_token_aqui>
     ```
  3. Confirme para habilitar a autenticação.

#### 1.3. RotaProtegida  
- **Descrição**: Verifica se o token de autenticação está funcionando corretamente.  
- **Método HTTP**: `GET`  
- **Saída**: Uma mensagem indicando se a autenticação foi bem-sucedida.

---

## **2. Produtos**

### **Endpoints disponíveis**

#### 2.1. Listar todos os produtos  
- **Descrição**: Retorna todos os produtos cadastrados.  
- **Método HTTP**: `GET`  
- **Rota**: `/api/Produtos`

#### 2.2. Listar produtos em estoque  
- **Descrição**: Retorna apenas os produtos que possuem estoque disponível.  
- **Método HTTP**: `GET`  
- **Rota**: `/api/Produtos/Estoque`

#### 2.3. Buscar produto por ID  
- **Descrição**: Retorna os dados de um produto específico com base no ID informado.  
- **Método HTTP**: `GET`  
- **Rota**: `/api/Produtos/{id}`  
- **Parâmetro**: `id` (identificador único do produto).

#### 2.4. Registrar um novo produto  
- **Descrição**: Permite cadastrar um novo produto na base de dados.  
- **Método HTTP**: `POST`  
- **Rota**: `/api/Produtos`  
- **Entrada**: Objeto JSON com as informações do produto:  
  ```json
  {
    "produtoName": "Monitor",
    "produtoDescription": "Monitor de computador",
    "produtoValue": 259.99,
    "produtoAmount": 5,
    "idCategoria": 1
  }
#### 2.5. Editar um produto existente  
- **Descrição**: Atualiza os dados de um produto já cadastrado.  
- **Método HTTP**: `PUT`  
- **Rota**: `/api/Produtos/{id}`  
- **Parâmetro**: `id` (identificador único do produto).  
- **Entrada**: Objeto JSON com os novos dados do produto:  
  ```json
  {
  "produtoName": "Monitor",
  "produtoDescription": "Monitor de computador",
  "produtoValue": 259.99,
  "produtoAmount": 0,
  "idCategoria": 1
  }
#### 2.6. Remover um produto  
- **Descrição**: Exclui um produto específico da base de dados.  
- **Método HTTP**: `DELETE`  
- **Rota**: `/produtos/{id}`  
- **Parâmetro**: `id` (identificador único do produto).

---

## **3. Usuários**

Os endpoints da aba **Usuários** possuem a mesma estrutura que os da aba **Produtos**, com foco em gerenciar informações dos usuários da aplicação.

### **Endpoints disponíveis**

#### 3.1. Listar todos os usuários  
- **Descrição**: Retorna todos os usuários cadastrados.  
- **Método HTTP**: `GET`  
- **Rota**: `/api/usuarios`

#### 3.2. Buscar usuário por ID  
- **Descrição**: Retorna os dados de um usuário específico com base no ID informado.  
- **Método HTTP**: `GET`  
- **Rota**: `/api/usuarios/{id}`  
- **Parâmetro**: `id` (identificador único do usuário).

#### 3.3. Registrar um novo usuário  
- **Descrição**: Permite cadastrar um novo usuário.  
- **Método HTTP**: `POST`  
- **Rota**: `/api/usuarios`  
- **Entrada**: Objeto JSON com as informações do usuário:  
  ```json
  {
    {
      "userName": "Nome",
      "userEmail": "Email",
      "userPassword": "Senha",
      "userPhone": "(55) 61 1276-3498",
      "userSalario": 43210.99,
      "userCpf": "593-823-532-1",
      "userCargo": "Estoquista"
    }
  }
#### 3.4. Editar um usuário existente  
- **Descrição**: Atualiza os dados de um usuário já cadastrado.  
- **Método HTTP**: `PUT`  
- **Rota**: `/api/usuarios/{id}`  
- **Parâmetro**: `id` (identificador único do usuário).  
- **Entrada**: Objeto JSON com os novos dados do usuário:  
  ```json
  {
    {
      "userName": "Nome",
      "userEmail": "Email",
      "userPassword": "Senha",
      "userPhone": "(55) 61 1276-3498",
      "userSalario": 43210.99,
      "userCpf": "593-823-532-1",
      "userCargo": "Funcionario"
    }
  }
#### 3.5. Remover um usuário  
- **Descrição**: Exclui um usuário específico da base de dados.  
- **Método HTTP**: `DELETE`  
- **Rota**: `/api/usuarios/{id}`  
- **Parâmetro**:  
  - `id` (identificador único do usuário).

---

## **Instruções gerais**

1. **Autenticação**: Sempre autentique o token antes de acessar rotas protegidas.
2. **Testes no Swagger**: Utilize a interface gráfica do Swagger para executar os endpoints e visualizar as respostas.
3. **Formato do token**: Certifique-se de usar o prefixo `Bearer` ao informar o token no campo de autorização.
4. **Banco de dados**: Certifique-se que o [path do banco de dados local](https://github.com/deBearN/APISquadra/blob/c02e1f2a4d2441f076556eba7291e56f25cdd681/APISquadra/Program.cs#L60) está correto, e que você conectou o banco de dados Local ao .mdf.


