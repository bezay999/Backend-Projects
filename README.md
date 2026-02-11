### LinksUpdater
  
LinksUpdater is a lightweight and efficient microservice built with ASP.NET Core for URL shortening. It transforms long URLs into unique 
short codes, featuring built-in link availability validation before storage.

- Secure Code Generation: Uses a cryptographically strong random number generator (RandomNumberGenerator) to create unique 6-character codes.
- Live Link Validation: Automatically performs a HEAD request to verify the target URL is accessible before saving.
- Fast Redirects: Efficiently maps short codes back to original URLs with instant redirection.
- Persistent Storage: Integrated with Entity Framework Core and pre-configured for SQLite.
- API Documentation: Built-in Swagger UI for easy testing and integration.

