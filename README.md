# ⚡ AgnostiQ BI — Predictive Business Intelligence & DSS

> **Any Data. Any Metric. Instant Decisions.**

O **AgnostiQ BI** é uma plataforma SaaS de Business Intelligence Preditivo e Sistema de Suporte à Decisão (DSS) baseada em séries temporais agnósticas. O sistema analisa qualquer conjunto de dados numéricos sequenciais (preços de commodities, ações, fluxo de caixa, estoque, vendas) e gera automaticamente tendências preditivas e recomendações acionáveis (*Comprar*, *Vender*, *Aguardar*).

---

## 🎯 Principais Funcionalidades

* 📈 **Dados Temporais Agnósticos:** Suporte a qualquer métrica temporal através de colunas JSON dinâmicas no banco de dados.
* 🧠 **Motor Preditivo Matemático:** Regressão linear por Mínimos Quadrados para projeção de $N$ períodos futuros em $< 200\text{ms}$.
* 🤖 **Motor de Decisão (DSS):** Classificação automática da tendência com justificativas em linguagem natural.
* 📊 **Dashboard Reativo em Blazor:** Visualização limpa e responsiva utilizando Bootstrap 5, focada em alta legibilidade e KPIs estratégicos.
* 📥 **Ingestão Flexível:** Entrada de dados via formulário interativo ou upload de arquivos CSV.

---

## 🏗️ Arquitetura & Stack Tecnológica

O projeto foi construído seguindo os princípios de **Vertical Slice Architecture** e **MVP Lean**:

* **Framework:** .NET 10 (C#)
* **Frontend UI:** Blazor Web App (InteractiveServer / InteractiveAuto)
* **Estilização:** Bootstrap 5 (Mobile-First & Componentes Nativos)
* **Backend:** Minimal APIs organizadas por *Features*
* **OR/M & Banco:** Entity Framework Core com mapeamento de colunas JSON
* **Testes:** xUnit & FluentAssertions

---

## 📁 Estrutura de Pastas (Vertical Slice)

```text
Features/
└── TimeSeriesAnalytics/
    ├── TimeSeriesEntity.cs       # Mapeamento de entidade e colunas JSON
    ├── TimeSeriesDssEngine.cs    # Motor algorítmico e cálculo DSS
    ├── TimeSeriesEndpoints.cs    # Endpoints Minimal API da feature
    └── AnalyticsDashboard.razor  # Componente de interface Blazor (Bootstrap) 
```
---
## 🚀 Como Executar o Projeto Localmente

1. Clonar o repositório:
``` 
git clone https://github.com/WellintonRodrigo/AgnostiQ_BI.git
cd AgnostiQ_BI
``` 
2. Restaurar dependências:
```
dotnet restore
```
3. Executar a aplicação:
```
dotnet run
```
4. Acesse https://localhost:5001 no seu navegador.

## 📜 Licença

Este projeto está sob a licença MIT.
