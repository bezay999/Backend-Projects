### LinksUpdater
  
LinksUpdater is a lightweight and efficient microservice built with ASP.NET Core for URL shortening. It transforms long URLs into unique 
short codes, featuring built-in link availability validation before storage.

- Secure Code Generation: Uses a cryptographically strong random number generator (RandomNumberGenerator) to create unique 6-character codes.
- Live Link Validation: Automatically performs a HEAD request to verify the target URL is accessible before saving.
- Fast Redirects: Efficiently maps short codes back to original URLs with instant redirection.
- Persistent Storage: Integrated with Entity Framework Core and pre-configured for SQLite.
- API Documentation: Built-in Swagger UI for easy testing and integration.

### Password & Cipher Tools

Password & Cipher Tools is a utility-focused microservice built with ASP.NET Core. It provides developers with ready-to-use API endpoints for cryptographic text manipulation and high-entropy password generation.

- Strong Password Generation:
  1) Guarantees inclusion of uppercase, lowercase, numbers, and special symbols.
  2) Implements the Fisher-Yates Shuffle algorithm to ensure character positions are truly randomized.
  3) Uses RandomNumberGenerator for cryptographic security.

- Caesar Cipher Engine:
  1) Provides a classic substitution cipher (ROT3) for text obfuscation.
  2) Handles alphabetic characters, spaces, and punctuation.

- Clean Architecture:
  1) Services are registered as Singletons for high performance and low memory overhead.
  2) Uses modern C# features like Records for clean Data Transfer Objects (DTOs).
