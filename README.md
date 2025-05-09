# KPZ - Lab 1
Variant 1

### Author 
Oleksandr Hiruk, ZIPZ-23-1

---

## Implemented Principles

### 1. **SRP – Single Responsibility Principle**
Each class has one responsibility:
- `Money.cs`: stores and manipulates monetary values.
- `Product.cs`: represents product with price and category.
- `Warehouse.cs`: manages storage and quantity.
- `Reporting.cs`: handles reporting and operations logging.

Example: [`Money.cs`](./ConsoleApp/Money.cs), [`Product.cs`](./ConsoleApp/Product.cs), [`Warehouse.cs`](./ConsoleApp/Warehouse.cs)

---

### 2. **OCP – Open/Closed Principle**
The system is open for extension (e.g. adding categories), but closed for modification.

Example: Adding `Category.cs` without changing existing logic: [`Category.cs`](./ConsoleApp/Category.cs)

---

### 3. **LSP – Liskov Substitution Principle**
Not directly demonstrated (no inheritance used), but all objects behave as expected when passed as their type (e.g., `Product`, `Money`).

---

### 4. **ISP – Interface Segregation Principle**
Not applicable in this small project (no interfaces yet).

---

### 5. **DIP – Dependency Inversion Principle**
`Reporting` depends on abstraction (concept of `Warehouse`), not direct internal implementation.

[`Reporting.cs`](./ConsoleApp/Reporting.cs), constructor injection of `Warehouse`

---

### 6. **DRY – Don’t Repeat Yourself**
Logic like price formatting, stock handling is not duplicated.

Price formatting: [`Money.cs`](./ConsoleApp/Money.cs), method `Display()`

---

### 7. **KISS – Keep It Simple, Stupid**
All classes are small, with clear naming and straightforward logic.

Example: [`Warehouse.cs`](./ConsoleApp/Warehouse.cs), method `ShipProduct`

---

### 8. **YAGNI – You Aren’t Gonna Need It**
Only required functionality is implemented — e.g., no full database, no unused methods.

---

### 9. **Composition Over Inheritance**
Instead of inheritance, `Product` contains a `Category`, `Warehouse` contains `Product`.

[`Product.cs`](./ConsoleApp/Product.cs), property `Category`

---

### 10. **Program to Interfaces**
Not implemented directly (for simplicity), but could be added by defining `IProduct`, `IWarehouse`, etc.

---

## Testing
See [`Program.cs`](./ConsoleApp/Program.cs) for full usage and testing of the classes.
