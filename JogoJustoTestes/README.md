# JogoJusto — Testes Automatizados BDD

Este documento descreve a estratégia, configuração e execução dos testes automatizados do projeto **JogoJusto**, uma plataforma HRTech focada em Diversidade, Inclusão e práticas ESG.

> 📌 Este README será integrado à branch `master` junto com a documentação principal do projeto em uma etapa futura.

## Sobre os Testes

Os testes foram implementados utilizando a abordagem **BDD (Behavior Driven Development)** com linguagem **Gherkin**, garantindo que o comportamento da aplicação seja validado tanto em cenários positivos (caminho feliz) quanto negativos (falhas esperadas).

Cada funcionalidade testada possui um **Contexto** definido na feature, que executa automaticamente o step de autenticação antes de cada cenário — evitando repetição e garantindo que todos os testes partam de um estado autenticado consistente.
 
As credenciais do usuário administrador utilizado nos testes são:
 
```
Email: isabella@example.com
Senha: SenhaForte123
```


### Tecnologias Utilizadas

| Tecnologia | Versão | Finalidade |
|---|---|---|
| SpecFlow | 4.0.31-beta | Framework BDD para .NET |
| xUnit | 2.5.3 | Test runner |
| FluentAssertions | 8.9.0 | Assertions expressivas |
| Newtonsoft.Json | 13.0.3 | Serialização JSON |
| Newtonsoft.Json.Schema | 3.0.15 | Validação de contrato JSON Schema |
| BoDi | 1.5.0 | Injeção de dependência SpecFlow |

---

## Estrutura do Projeto de Testes
 
```
JogoJustoTestes/
├── BDD/
│   ├── Features/                  ← Cenários escritos em Gherkin
│   │   ├── Empresa.feature
│   │   ├── Funcionario.feature
│   │   ├── Login.feature
│   │   ├── Meta.feature
│   │   └── Usuario.feature
│   ├── Hooks/
│   │   └── Hooks.cs               ← Configuração do HttpClient por cenário
│   └── StepDefinitions/           ← Implementação dos steps
│       ├── SharedSteps.cs         ← Steps e validações compartilhados entre features
│       ├── EmpresaSteps.cs
│       ├── FuncionarioSteps.cs
│       ├── LoginStep.cs
│       ├── MetaStep.cs
│       └── UsuarioStep.cs
├── Schemas/                       ← Contratos JSON Schema por entidade
│   ├── empresa-lista.json
│   ├── empresa-por-id.json
│   ├── funcionario-lista.json
│   ├── funcionario-por-id.json
│   ├── metaesg-lista.json
│   ├── metaesg-por-id.json
│   └── usuario-login.json
└── specflow.json                  ← Configuração de idioma (pt-BR)
```
 
---

## Decisão Arquitetural — SharedSteps
 
Para evitar repetição de código entre as diferentes features, foi criada a classe `SharedSteps.cs` que centraliza dois comportamentos compartilhados:
 
**1. Autenticação** — o step `Dado que o administrador está autenticado` é utilizado no `Contexto` de múltiplas features. Centralizá-lo no `SharedSteps` evita duplicação e garante consistência.
 
**2. Validação de JSON Schema** — o método `ValidarJsonSchema` é chamado pelos steps de cada entidade, eliminando a necessidade de replicar a lógica de validação de contrato em cada classe de steps.
 
```csharp
// Exemplo de uso nos steps
SharedSteps.ValidarJsonSchema(json, "empresa-lista.json");
```
 
---

## 🧪 Cenários de Teste

### Empresa (4 cenários)
| Cenário | Tipo | Status Code Esperado |
|---|---|---|
| Cadastrar nova empresa com sucesso | Positivo | 200 |
| Listar todas as empresas com sucesso | Positivo | 200 |
| Buscar empresa existente por ID | Positivo | 200 |
| Buscar empresa inexistente por ID | Negativo | 404 |

### Funcionário (4 cenários)
| Cenário | Tipo | Status Code Esperado |
|---|---|---|
| Cadastrar novo funcionário com sucesso | Positivo | 200 |
| Listar todos os funcionários com sucesso | Positivo | 200 |
| Buscar funcionário existente por ID | Positivo | 200 |
| Buscar funcionário inexistente por ID | Negativo | 404 |

### Login (2 cenários)
| Cenário | Tipo | Status Code Esperado |
|---|---|---|
| Verificar se login válido | Positivo | 200 |
| Verificar se login inválido | Negativo | 401 |

### Meta ESG (5 cenários)
| Cenário | Tipo | Status Code Esperado |
|---|---|---|
| Cadastrar nova meta com sucesso | Positivo | 200 |
| Listar metas cadastradas com sucesso | Positivo | 200 |
| Atualizar meta existente com sucesso | Positivo | 200 |
| Pesquisar meta existente por ID | Positivo | 200 |
| Deletar meta existente com sucesso | Positivo | 200 |

### Usuário (2 cenários)
| Cenário | Tipo | Status Code Esperado |
|---|---|---|
| Criar novo usuário com dados válidos | Positivo | 200 |
| Criar usuário com dados inválidos | Negativo | 500 |

**Total: 17 cenários BDD | 0 falhas** ✅ 

---


## Validação de Contrato JSON Schema
 
Os testes validam não apenas o status code, mas também o **contrato da resposta JSON** de cada endpoint, garantindo que a estrutura retornada pela API está conforme o esperado.
 
Os schemas estão localizados em `JogoJustoTestes/Schemas/` e são gerados a partir das respostas reais da API utilizando a ferramenta [ExtendsClass](https://extendsclass.com/json-schema-validator.html).
 
| Endpoint | Schema |
|---|---|
| `GET /api/empresa` | `empresa-lista.json` |
| `GET /api/empresa/{id}` | `empresa-por-id.json` |
| `GET /api/funcionario` | `funcionario-lista.json` |
| `GET /api/funcionario/{id}` | `funcionario-por-id.json` |
| `GET /api/metaesg` | `metaesg-lista.json` |
| `GET /api/metaesg/{id}` | `metaesg-por-id.json` |
| `POST /api/usuario/login` | `usuario-login.json` |
 
---

## ⚙️ Pré-requisitos
 
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) — necessário apenas para execução local
---

## 🚀 Como Executar
 
Os testes podem ser executados de duas formas — localmente via Docker ou apontando para o ambiente Azure.
 
### Opção 1 — Execução Local (Docker)
 
**1. Clone o repositório e acesse a branch de testes:**
```bash
git clone git@github.com:welinton19/JogoJusto.git
cd JogoJusto
git checkout bdd
```
 
**2. Suba a API via Docker:**
```bash
docker-compose up --build
```
 
**3. Confirme o BaseAddress no `Hooks.cs`:**
```csharp
BaseAddress = new Uri("http://localhost:5000/")
```
 
**4. Execute os testes:**
```bash
dotnet test --verbosity normal
```
 
---

### Opção 2 — Execução contra Azure
 
**1. Confirme o BaseAddress no `Hooks.cs`:**
```csharp
BaseAddress = new Uri("https://jogojusto-dev-h0e9bsesfjgkeydd.eastus2-01.azurewebsites.net/")
```
 
**2. Execute os testes:**
```bash
dotnet test --verbosity normal
```
 
---

## Pipeline CI/CD
 
Os testes são executados automaticamente via **GitHub Actions** a cada push na branch `master`, conforme configurado em `.github/workflows/`.

---
 
## Observações
 
- O cenário de **criação de usuário** usa `Guid.NewGuid()` para gerar emails únicos a cada execução, evitando falhas por violação de constraint de unicidade no banco.
- O cenário de **exclusão de meta ESG** realiza um ID fixo - verifique se o registro existe antes de executar.
- Os testes de **contrato JSON Schema** validam a estrutura da resposta, mas não os valores específicos dos campos.
---