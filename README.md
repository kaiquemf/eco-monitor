# 🌱 EcoMonitor API

> Projeto acadêmico FIAP — Capítulo 7: APIs e Integração de Sistemas com ASP.NET Core 8  
> Tema ESG: Eficiência Energética e Sustentabilidade

---

## 📌 Visão Geral

O **EcoMonitor** é um sistema RESTful desenvolvido em **.NET 8/9**, com o objetivo de monitorar o consumo de energia em dispositivos eletrônicos. Ele registra o uso em tempo real, detecta padrões anormais e gera alertas e relatórios para promover **eficiência energética** e **ações sustentáveis**.

---

## 🔧 Tecnologias e Ferramentas

- ✅ **ASP.NET Core 8 / 9**
- ✅ **Entity Framework Core** + Migrations
- ✅ **SQL Server LocalDB**
- ✅ **xUnit** para testes automatizados
- ✅ **Swagger / Swashbuckle** para documentação interativa
- ✅ **Dockerfile** pronto para conteinerização
- ✅ **Postman** / **Insomnia** para testes de API
- ✅ Padrão de arquitetura: **MVVM + Repository Pattern**

---

## 📁 Estrutura de Projeto

EcoMonitor.Api/
├── Controllers/ # Endpoints REST
├── Models/ # Entidades do domínio
├── Repositories/ # Interfaces e implementações de dados
├── Services/ # Lógica de negócio
├── ViewModels/ # DTOs para responses
├── Data/ # Contexto EF + Seed
├── Migrations/ # Migrations EF Core
└── Properties/ # launchSettings.json

---

## 📲 Endpoints RESTful

### 📌 AlertController

| Verbo | Rota                             | Descrição                                 |
|-------|----------------------------------|--------------------------------------------|
| GET   | `/api/Alert`                     | Lista todos os alertas                     |
| GET   | `/api/Alert/device/{deviceId}`   | Filtra alertas por dispositivo e período   |
| POST  | `/api/Alert`                     | Cria um novo alerta                        |

### ⚡ EnergyUsageController

| Verbo | Rota                                     | Descrição                                        |
|-------|------------------------------------------|--------------------------------------------------|
| GET   | `/api/EnergyUsage`                       | Lista com paginação o consumo de energia         |
| GET   | `/api/EnergyUsage/device/{deviceId}`     | Consumo por dispositivo e período                |

### 📊 ReportController

| Verbo | Rota                             | Descrição                                 |
|-------|----------------------------------|--------------------------------------------|
| GET   | `/api/Report/paged`             | Lista relatórios com paginação             |
| GET   | `/api/Report/alerts/high`       | Lista alertas acima de um limite (threshold) |
| GET   | `/api/Report/{deviceId}/period` | Gera relatório por dispositivo e período   |

### 🖥️ DeviceController

| Verbo | Rota             | Descrição                       |
|-------|------------------|----------------------------------|
| GET   | `/api/Device`    | Lista todos os dispositivos     |
| GET   | `/api/Device/{id}` | Busca dispositivo por ID        |
| POST  | `/api/Device`    | Cria um novo dispositivo        |
| PUT   | `/api/Device/{id}` | Atualiza um dispositivo         |
| DELETE| `/api/Device/{id}` | Remove um dispositivo           |

---

## 🧪 Testes Automatizados

Os testes são implementados com **xUnit** e cobrem todos os controllers principais.  
Exemplo de teste de status `200 OK` para um endpoint:

```csharp
[Fact]
public async Task GetAllDevices_Returns200()
{
    var response = await _client.GetAsync("/api/Device");
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
}
```

Executar os testes:
dotnet test

### 🐳 Docker
Para executar via Docker:
docker build -t ecomonitor-api .
docker run -p 5283:80 ecomonitor-api

### 💾 Banco de Dados
O projeto utiliza EF Core + SQL Server LocalDB.
A base pode ser criada automaticamente via migration.

#### Gerar e aplicar migrations:
dotnet ef migrations add InitialCreate
dotnet ef database update

### 📚 Tema ESG
Eficiência Energética e Sustentabilidade
O EcoMonitor visa monitorar e reduzir o consumo energético de ambientes corporativos ou domésticos, promovendo alertas inteligentes e relatórios automatizados.
