# EShopMicroservices

Uma solução de **e-commerce distribuída baseada em microsserviços**, desenvolvida para demonstrar arquitetura escalável, independente e bem organizada.  
O repositório propõe uma separação de domínios, comunicação assíncrona, orquestração de serviços e boas práticas de desenvolvimento.

---

## 🎯 Visão Geral  
Este projeto reúne diversos microsserviços que formam uma aplicação de loja online — desde catálogo de produtos, carrinho de compras, pedidos, até autenticação/usuário e gateway de API. A meta é demonstrar como estruturar um sistema moderno, distribuir responsabilidades e permitir a escalabilidade de cada parte separadamente.

---

## 🧩 Funcionalidades Principais  
- Serviços de catálogo, estoque, carrinho, pedidos, usuários
- Interface ou API Gateway para unificar acesso aos serviços  
- Comunicação entre microsserviços via mensagens/eventos (broker, filas, GRPC)  
- Cada serviço tem seu próprio banco de dados para isolamento de dados  
- Containerização / orquestração (Docker / Docker Compose)  
- Monitoramento, logs estruturados, pontos de falha isolados  

---

## ⚙️ Tecnologias Utilizadas  
- Linguagem: C# / .NET (.NET 8)  
- Microsserviços via ASP.NET Core Minimal APIs  
- Banco de dados distintos por serviço (SQL Server, PostgreSQL, Redis, SQLite)  
- Mensageria/eventos: RabbitMQ, Apache Kafka, MassTransit  
- Contêineres e orquestração: Docker / Docker Compose  
- Padrões de arquitetura: DDD (Domain-Driven Design), CQRS, Clean Architecture  
- API Gateway (YARP)
- Ferramentas de logging/monitoramento (Serilog)  

---

## 🚀 Como Rodar o Projeto  
### Pré-requisitos  
- .NET SDK instalado (.NET 8+)  
- Docker instalado ou acesso aos bancos de dados (SQL Server, PostgreSQL, Redis) localmente ou em nuvem  
- Git  

### Passos  
```bash
# Clone o repositório
git clone https://github.com/lazarobodevan/EShopMicroservices.git
cd EShopMicroservices

# Utilize Docker Compose para levantar todos os serviços
docker-compose up --build

# Ou execute cada serviço individualmente via Visual Studio/CLI
