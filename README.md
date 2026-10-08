# InspiredAssessmentAutomation

**C# · .NET 8 · Microsoft Playwright · Reqnroll · NUnit · Page Object Model**

A personal UI test automation practice framework using the [Automation Exercise](https://automationexercise.com/) website. It demonstrates behavior-driven tests, reusable page objects, browser lifecycle management, and assertions for typical shopping flows.

## What this project covers

The repository contains Gherkin feature files for:
- Authentication
- Product search
- Shopping cart: add a product, add multiple products, remove items, and validate quantities
- Checkout

These are the scenarios defined in the project; not all scenarios have necessarily been confirmed passing.

## Technology

| Tool | Purpose |
| --- | --- |
| C# / .NET 8 | Test implementation and runtime |
| Microsoft Playwright | Browser automation |
| Reqnroll + NUnit | BDD bindings and test execution |
| Gherkin | Readable feature scenarios |
| Page Object Model | Centralized page interactions and locators |

## Project layout

```text
InspiredAssessmentAutomation/
├── InspiredAssessmentAutomation.sln
├── global.json
└── UI/
    └── InspiredAssessment.UI/
        ├── Features/
        ├── Hooks/
        ├── Pages/
        ├── StepDefinitions/
        ├── Support/
        └── InspiredAssessment.UI.csproj
```

## Run locally

**Prerequisites:** .NET 8 SDK and Git. Playwright needs browser binaries installed on the machine.

```bash
git clone https://github.com/MlungisiGumede/InspiredAssessmentAutomation.git
cd InspiredAssessmentAutomation
dotnet restore
dotnet build
pwsh UI/InspiredAssessment.UI/bin/Debug/net8.0/playwright.ps1 install chromium
dotnet test
```

On macOS, install PowerShell (`pwsh`) if it isn't available. The browser initialization currently launches Chromium in **headed mode**, so tests require a desktop environment.

## Framework design

- **Gherkin scenarios** express user behavior in a readable format.
- **Page objects** encapsulate UI locators and interactions.
- **Step definitions** link scenarios to the automation code.
- **Hooks and browser support** manage browser session setup and teardown.

## About

Created as a personal QA automation portfolio and hands-on learning project.

**Author:** [Mlungisi Gumede](https://github.com/MlungisiGumede)
