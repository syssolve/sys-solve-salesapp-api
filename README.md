# sys-solve-salesapp-api
# Sales Application API

This is the documentation for the Sales Application API developed in .NET 6.0. This API provides functionality for performing CRUD operations on sales, products, invoices, users, and companies.

## API Documentation

The API documentation is provided using OpenAPI 3.0.1. You can view the API specification by clicking [here](link-to-your-api-spec).

## Endpoints

### Company

#### Get Company by ID

- **Endpoint**: `/api/Company/{id}`
- **Method**: GET
- **Description**: Get company details by ID.
- **Parameters**:
  - `id` (path, integer, required): The ID of the company.
- **Responses**:
  - `200 OK`: Success

#### Create Company

- **Endpoint**: `/api/Company`
- **Method**: POST
- **Description**: Create a new company.
- **Request Body**: CompanyDTO (JSON)
- **Responses**:
  - `200 OK`: Success

#### Update Company

- **Endpoint**: `/api/Company`
- **Method**: PUT
- **Description**: Update an existing company.
- **Request Body**: CompanyDTO (JSON)
- **Responses**:
  - `200 OK`: Success

### Invoice

...

[Repeat the above format for all other endpoints: Invoice, Login, Parameter, Product, Sale, SaleInvoice, Unit, User, UserType]

## Data Models

### CompanyDTO

- **Properties**:
  - `id` (integer, int32)
  - `name` (string, nullable)
  - `nameRegistered` (string, nullable)
  - `soluser` (string, nullable)
  - `solpassword` (string, nullable)
  - `lastInvoice` (string, nullable)
  - `status` (string, nullable)

### InvoiceDTO

...

[Repeat the above format for all other data models: InvoiceDTO, ParameterDTO, ProductDTO, SaleDTO, SaleInvoiceDTO, UnitDTO, UserModel, UserTypeDTO]

## Getting Started

Follow these steps to set up and run the Sales Application API:

1. Clone this repository.
2. Install .NET 6.0 SDK.
3. Configure your database connection in `appsettings.json`.
4. Run `dotnet build` to build the project.
5. Run `dotnet run` to start the API.

## Usage

- Ensure the API is running locally or on your server.
- Use the provided API endpoints to perform CRUD operations on sales, products, invoices, users, and companies.

## Contributing

...

## License

This project is licensed under the [License Name] - see the [LICENSE.md](LICENSE.md) file for details.
