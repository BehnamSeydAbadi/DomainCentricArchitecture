# DomainCentricArchitecture
<img align="center" width="404" height="404" src="https://i.ibb.co/7CTfWfG/database-centrics-vs-domain-centric-architecture.png" />

This is a sample of domain-based clean architecture. It's created with ASP.NET 6, Entity Framework Core, and the sight of TDD. The project handles simple to-do app businesses with CQRS pattern.

<img align="center" width="701" height="330" src="https://i.ibb.co/KNdNBf6/Untitled.jpg" />

There are three types of CQRS pattern which I mentioned below:
  1. Separated APIs to commands and queries that both of them work with one database (Which I used and implemented)
  2. Separated APIs to commands and queries with separated databases
  3. Separated APIs to commands and queries with event sourcing pattern.


List of used technologies:
* [ASP.NET 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [SQL Server](https://docs.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver16)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
* [NUnit](https://nunit.org/)
* [FluentAssertions](https://fluentassertions.com/)
