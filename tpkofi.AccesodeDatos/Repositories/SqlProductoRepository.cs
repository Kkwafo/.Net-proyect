//using Microsoft.Data.SqlClient;
//using TpFinalKofi.Dominio.Interfaces;
//using TpFinalKofi.Dominio.Models;

//public class SqlProductoRepository : IProductoRepository
//{
//    private string connectionString = "Data Source=DESKTOP-0RJ52H8;Initial Catalog=TpKofi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

//    public SqlProductoRepository()
//    {
//    }

//    public void AgregarProducto(Producto producto)
//    {
//        using var connection = new SqlConnection(connectionString);
//        connection.Open();

//        var command = new SqlCommand("INSERT INTO Productos (Id, Name, Description, Price) VALUES (@Id, @Name, @Description, @Price)", connection);
//        command.Parameters.AddWithValue("@Id", producto.Id);
//        command.Parameters.AddWithValue("@Name", producto.Name);
//        command.Parameters.AddWithValue("@Description", producto.Description);
//        command.Parameters.AddWithValue("@Price", producto.Price);

//        command.ExecuteNonQuery();
//    }

//    public void ActualizarProducto(string id, Producto producto)
//    {
//        using var connection = new SqlConnection(connectionString);
//        connection.Open();

//        var command = new SqlCommand("UPDATE Productos SET Name = @Name, Description = @Description, Price = @Price WHERE Id = @Id", connection);
//        command.Parameters.AddWithValue("@Id", id);
//        command.Parameters.AddWithValue("@Name", producto.Name);
//        command.Parameters.AddWithValue("@Description", producto.Description);
//        command.Parameters.AddWithValue("@Price", producto.Price);

//        command.ExecuteNonQuery();
//    }

//    public void EliminarProducto(string id)
//    {
//        using var connection = new SqlConnection(connectionString);
//        connection.Open();

//        var command = new SqlCommand("DELETE FROM Productos WHERE Id = @Id", connection);
//        command.Parameters.AddWithValue("@Id", id);

//        command.ExecuteNonQuery();
//    }

//    public Producto ObtenerProductoPorId(string id)
//    {
//        using var connection = new SqlConnection(connectionString);
//        connection.Open();

//        var command = new SqlCommand("SELECT Id, Name, Description, Price FROM Productos WHERE Id = @Id", connection);
//        command.Parameters.AddWithValue("@Id", id);

//        using var reader = command.ExecuteReader();

//        if (!reader.Read())
//        {
//            return null;
//        }

//        var producto = new Producto
//        {
//            Id = reader.GetString(0),
//            Name = reader.IsDBNull(1) ? null : reader.GetString(1),
//            Description = reader.IsDBNull(2) ? null : reader.GetString(2),
//            Price = reader.IsDBNull(3) ? null : reader.GetString(3)
//        };

//        return producto;
//    }

//    public IEnumerable<Producto> ObtenerTodosLosProductos()
//    {
//        var productos = new List<Producto>();

//        using var connection = new SqlConnection(connectionString);
//        connection.Open();

//        var command = new SqlCommand("SELECT Id, Name, Description, Price FROM Productos", connection);

//        using var reader = command.ExecuteReader();

//        while (reader.Read())
//        {
//            var producto = new Producto
//            {
//                Id = reader.GetString(0),
//                Name = reader.IsDBNull(1) ? null : reader.GetString(1),
//                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
//                Price = reader.IsDBNull(3) ? null : reader.GetString(3)
//            };

//            productos.Add(producto);
//        }

//        return productos;
//    }
//}