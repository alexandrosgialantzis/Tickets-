# E-Tickets

A movie ticket shop. Browse films, add them to a cart, place an order. Admins manage the movies, actors, producers, and cinemas.

Built with ASP.NET Core MVC, Entity Framework Core, SQL Server, and Bootstrap.

## Roles

Guests browse and see details. Logged in users get a cart and an order list. Admins get create, edit, and delete on every entity.

Roles come from ASP.NET Identity. Controllers are guarded with attributes, so the check sits on the action itself, not scattered through the code.

## How the data layer is shaped

Every model implements `IEntityBase`, which just holds an id. That lets one generic repository serve them all: get, get by id, add, update, delete, written once in `EntityBaseRepository`.

Each entity then gets a service that inherits that repository and adds only what it needs. Movies, for example, needs the actor and cinema lookups for its dropdowns. The services sit behind interfaces and are registered in `Startup`, so controllers depend on the interface, not the class.

## The cart

The cart is tied to a session id, not a user. A guest can fill a cart before logging in.

`ShoppingCart.GetShoppingCart` pulls the id from session, or makes a new one, and hands back a cart bound to it. It is registered as scoped, so each request gets the right cart with no extra wiring.

A view component shows the item count in the navbar on every page.

## Layout

```
Controllers/      one per entity, plus Orders and Account
Models/           entities and the join table for actors and movies
Data/Base/        the generic repository
Data/Services/    one service and interface per entity
Data/Cart/        session based cart
Data/ViewModels/  shapes for forms
Migrations/       EF migrations
Views/            Razor pages
```

## Run it

```
git clone https://github.com/alexandrosgialantzis/Tickets-.git
```

Copy `appsettings.example.json` to `appsettings.json` and put your SQL Server connection string in it.

Then open the solution in Visual Studio and run. The database seeds itself on first start with sample movies and two accounts, one admin and one user.

Needs .NET 5.
