namespace OnlineStore.Ado.Configurations
{
    public class OnlineStoreContext
    {
        public const string ConnectionString = @"Server=localhost,1433;Database=DbOnlineStore;User ID = SA; Password=Welcome123;";

        public const string GET_PRODUCTS_SQL = "SELECT Id, Name, Stock, Category_Id FROM Products";
        public const string GET_PRODUCT_SQL = "SELECT Id, Name, Stock, Category_Id FROM Products WHERE Id = @Id";
        public const string UPDATE_PRODUCT_SQL = "UPDATE Products SET Name = @Name, Stock = @Stock, Category_Id = @CategoryId WHERE Id = @Id";
        public const string DELETE_PRODUCT_BY_ID_SQL = "DELETE FROM Products WHERE Id = @Id";
        public const string INSERT_PRODUCT_SQL = "INSERT INTO Products (Id, Name, Stock, Category_Id) VALUES (@Id, @Name, @Stock, @Category_Id)";

        public const string GET_CATEGORIES_SQL = "SELECT Id, Name FROM Categories";
        public const string GET_CATEGORY_BY_ID_SQL = "SELECT Id, Name FROM Categories WHERE Id = @Id";
        public const string INSERT_CATEGORY_SQL = "INSERT INTO Categories (Name) VALUES (@Name)";
        public const string UPDATE_CATEGORY_SQL = "UPDATE Categories SET Name = @Name WHERE Id = @Id";
        public const string DELETE_CATEGORY_BY_ID_SQL = "DELETE FROM Categories WHERE Id = @Id";


        public const string GET_ITEMS_SQL = "SELECT Id, Price, Quantity, Product_Id FROM Items";
        public const string INSERT_ITEM_SQL = "INSERT INTO Items (Id, Price, Quantity, Product_Id) VALUES (@Id, @Price, @Quantity, @Product_Id)";
        public const string UPDATE_ITEM_SQL = "UPDATE Items SET Price = @Price, Quantity = @Quantity, Product_Id = @Product_Id WHERE Id = @Id";
        public const string DELETE_ITEM_BY_ID_SQL = "DELETE FROM Items WHERE Id = @Id";
        public const string GET_ITEM_BY_ID_SQL = "SELECT Id, Quantity, Price, Product_Id FROM Items WHERE Id = @Id";


        public const string GET_ORDERS_SQL = "SELECT Id, Item_Id, Total_Price FROM Orders";
        public const string INSERT_ORDER_SQL = "INSERT INTO Orders (Id, Item_Id, Total_Price) VALUES (@Id, @Item_Id, @Total_Price)";
        public const string UPDATE_ORDER_SQL = "UPDATE Orders SET Item_Id = @Item_Id, Total_Price = @Total_Price WHERE Id = @Id";
        public const string DELETE_ORDER_BY_ID_SQL = "DELETE FROM Orders WHERE Id = @Id";
        public const string GET_ORDER_BY_SQL = "SELECT Id, Item_Id, Total_Price FROM Orders WHERE Id = @Id";

        public const string GET_SALES_SQL = "SELECT Id, Order_Id, Customer_Id, Date  FROM Sales";
        public const string INSERT_SALE_SQL = "INSERT INTO Sales (Id, Order_Id, Customer_Id, Date) VALUES (@Id, @Order_Id, @Customer_Id, @Date)";
        public const string UPDATE_SALE_SQL = "UPDATE Sales SET Order_Id = @Order_Id, Customer_Id = @Customer_Id, Date = @Date WHERE Id = @Id";
        public const string DELETE_SALE_BY_ID_SQL = "DELETE FROM Sales WHERE Id = @Id";
        public const string GET_SALE_BY_ID_SQL = "SELECT Id, Order_Id, Customer_Id, Date  FROM Sales WHERE Id = @Id";

        public const string GET_USERS_SQL = "SELECT Id, User_Name, Password, Email FROM Users";
        public const string GET_USER_BY_ID_SQL = "SELECT Id, User_Name, Password, Email FROM Users WHERE Id = @Id";
        public const string INSERT_USER_SQL = "INSERT INTO Users (Id, User_Name, Password, Email) VALUES (@Id, @User_Name, @Password, @Email)";
        public const string UPDATE_USER_SQL = "UPDATE Users SET User_Name = @User_Name, Password = @Password, Email = @Email WHERE Id = @Id";
        public const string DELETE_USER_BY_ID_SQL = "DELETE FROM Users WHERE Id = @Id";


        public const string GET_ROLES_SQL = "SELECT Id, Name FROM Roles";
        public const string GET_ROLE_BY_ID_SQL = "SELECT Id, Name FROM Roles WHERE Id = @Id";
        public const string INSERT_ROLE_SQL = "INSERT INTO Roles (Id, Name) VALUES (@Id, @Name)";
        public const string UPDATE_ROLE_SQL = "UPDATE Roles SET Name = @Name WHERE Id = @Id";
        public const string DELETE_ROLE_BY_ID_SQL = "DELETE FROM Roles WHERE Id = @Id";


        public const string GET_USER_ROLES_SQL = "SELECT Id, User_Id, Role_Id FROM User_Roles";
        public const string INSERT_USER_ROLE_SQL = "INSERT INTO User_Roles (Id, User_Id, Role_Id) VALUES (@Id, @User_Id, @Role_Id)";
        public const string UPDATE_USER_ROLE_SQL = "UPDATE User_Roles SET User_Id = @User_Id, Role_Id = @Role_Id WHERE Id = @Id";
        public const string DELETE_USER_ROLE_BY_ID_SQL = "DELETE FROM User_Roles WHERE Id = @Id";
        public const string GET_USER_ROLE_BY_ID_SQL = "SELECT Id, User_Id, Role_Id FROM User_Roles WHERE Id = @Id";

        public const string GET_CUSTOMERS_SQL = "SELECT Id, User_Id, First_Name, Last_Name, Address, Phone, Nit FROM Customers";
        public const string GET_CUSTOMER_BY_ID_SQL = "SELECT Id, User_Id, First_Name, Last_Name, Address, Phone, Nit FROM Customers WHERE Id = @Id";
        public const string INSERT_CUSTOMER_SQL = "INSERT INTO Customers (Id, User_Id, First_Name, Last_Name, Address, Phone, Nit) VALUES (@Id, @User_Id, @First_Name, @Last_Name, @Address, @Phone, @Nit)";
        public const string UPDATE_CUSTOMER_SQL = "UPDATE Customers SET User_Id = @User_Id, First_Name = @First_Name, Last_Name = @Last_Name, Address = @Address, Phone = @Phone, Nit = @Nit WHERE Id = @Id";
        public const string DELETE_CUSTOMER_BY_ID_SQL = "DELETE FROM Customers WHERE Id = @Id";
    }
}