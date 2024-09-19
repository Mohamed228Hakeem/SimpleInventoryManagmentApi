Inventory Management System API

Project Overview

The Inventory Management System API is a robust backend service built using .NET 8 and SQL Server, designed to manage products, categories, and orders efficiently. This API serves as the core component of an inventory management solution, providing functionality for product management, category management, and order processing. The system integrates with ASP.NET Core Identity for user authentication and authorization, ensuring secure access and role-based permissions.



Key Features


Product Management: Add, update and retrieve products. Each product is associated with a category, and product quantities are managed to prevent overselling.

Category Management: Create product categories. Categories help in organizing products and are linked to products for easy categorization.

Order Processing: Create orders, add items to orders, and finalize orders. The system allows users to manage their orders in a step-by-step process, with real-time updates to product quantities.

User Authentication: Integrated with ASP.NET Core Identity for user management. JWT tokens are used for authentication, ensuring secure access to the API endpoints.

Role-Based Access: Users with specific roles (e.g., Admin, User) have different permissions, controlling their access to various functionalities of the API.

API Endpoints
Products

GET /products: Retrieve a list of products.
POST /products: Create a new product.

Categories

GET /categories: Retrieve a list of categories.
POST /categories: Create a new category.


Orders

POST /orders: Create an empty order.
POST /orders/{orderId}/items: Add items to an order.
POST /orders/{orderId}/finalize: Finalize an order and mark it as complete.
