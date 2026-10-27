# Accessible Enterprise Portal

Enterprise web application sample built with Angular and ASP.NET Core.

## Stack

- Angular
- TypeScript
- HTML5
- Sass/SCSS
- Bootstrap
- Angular Material
- ASP.NET Core .NET 8
- REST API

## Features

- Responsive dashboard
- Searchable employee table
- Add/edit employee workflow
- Accessible dialog
- Keyboard navigation
- Screen-reader-friendly labels and live messages
- WCAG 2.1 AA / Section 508 implementation patterns
- REST API integration

## Run locally

### API

```bash
cd server
dotnet restore
dotnet run
```

API runs at:

```text
http://localhost:5057
```

### UI

```bash
cd client
npm install
npm start
```

UI runs at:

```text
http://localhost:4200
```

## Accessibility checks

Tested patterns include:

- Keyboard-only navigation
- Logical focus order
- Visible focus
- Semantic headings and landmarks
- Accessible names and form labels
- Dialog focus management
- ARIA live status messages
- Responsive reflow
- Screen-reader-compatible table markup
- axe-ready semantic structure
