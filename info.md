# Teknisk dokumentation - ProjectManagement

## Arkitektur

### Backend

#### UnitOfWork och DependencyInjection.cs

**UnitOfWork-mönstret**

UnitOfWork är ett designmönster som kapslar in alla databasoperationer och ser till att de utförs som en enda "enhet". Huvudfördelarna är:

- **Transaktionshantering**: Alla ändringar sparas i en och samma transaktion.
- **Centraliserad databaslogi**: Enhetlig åtkomst till alla repositories.
- **Lägre koppling**: Tjänster behöver bara beror på UnitOfWork, inte flera enskilda repositories.
- **Prestandaoptimering**: Minimerar antalet databasanslutningar.

**DependencyInjection.cs**

DependencyInjection.cs är en extension-klass som konfigurerar och registrerar alla tjänster, repositories och DbContext för Dependency Injection. Detta gör att:

- **Centraliserad konfiguration**: All konfiguration av tjänster finns på ett ställe.
- **Enkel testning**: Gör det lättare att byta ut komponenter under testning.
- **Minskad kodduplicering**: Registreringen görs en gång och kan återanvändas.

### Frontend

#### Context API och Hooks

Applikationen använder React Context API för tillståndshantering, vilket ger flera fördelar:

- **Centraliserad tillståndshantering**: All data och logik finns på ett ställe.
- **Minskad props-drilling**: Komponenter kan komma åt data utan att skicka props genom flera nivåer.
- **Separation av ansvar**: UI-komponenter fokuserar på rendering, medan Context hanterar data och logik.

**Kontext-struktur**:

- `ProjectContext`: Hanterar projektdata och operationer
- `ReferenceDataContext`: Hanterar referensdata (kunder, projektledare, etc.)
- `FormContext`: Hanterar formulärdata och validering

#### Offline-stöd

Applikationen har stöd för att fungera även när backend-API:et inte är tillgängligt:

- **Fallback-data**: Fördefinierad data används när API-anrop misslyckas
- **Lokal lagring**: Ändringar sparas i localStorage tills API:et är tillgängligt igen
- **Transparent hantering**: Användaren märker inte av övergången mellan online och offline

## Datamodell

### Huvudentiteter

- **Project**: Representerar ett projekt med budget, tidsram och status
- **Client**: Kunder som projekten utförs för
- **ProjectManager**: Anställda som leder projekten
- **ServiceType**: Typer av tjänster som erbjuds
- **Status**: Möjliga statusar för projekt

### Relationer

- Ett projekt tillhör en kund
- Ett projekt har en projektledare
- Ett projekt har en tjänstetyp
- Ett projekt har en status

## API-struktur

API:et följer RESTful-principer med följande huvudendpoints:

- `/api/Projects`: CRUD-operationer för projekt
- `/api/Clients`: CRUD-operationer för kunder
- `/api/Employees`: CRUD-operationer för anställda/projektledare
- `/api/ServiceTypes`: CRUD-operationer för tjänstetyper
- `/api/Status`: CRUD-operationer för statusar

## Utvecklingsguide

### Lägga till en ny entitet

1. Skapa en modellklass i `src/Models`
2. Lägg till DbSet i `ApplicationDbContext`
3. Skapa ett repository-interface i `src/Repositories/Interfaces`
4. Implementera repository i `src/Repositories`
5. Uppdatera `IUnitOfWork` och `UnitOfWork`
6. Registrera repository i `DependencyInjection.cs`
7. Skapa en controller i `src/Controllers`

### Lägga till en ny React-komponent

1. Skapa en ny komponentfil i `React/src/components`
2. Exportera komponenten från index.ts
3. Uppdatera API-funktioner i `React/src/api` om det behövs
4. Lägg till fallback-data i `React/src/data` om det behövs
