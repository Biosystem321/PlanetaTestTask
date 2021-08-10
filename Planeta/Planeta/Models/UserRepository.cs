using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Planeta.Models
{
    public interface IUserRepository
    {
        void Create(User user);
        void Delete(int id);
        User Get(int id);
        List<User> GetUsers();
        void Update(User user);
    }
    public class UserRepository : IUserRepository
    {
        string connectionString = null;

        public UserRepository(string conn)
        {
            connectionString = conn;
        }
        public List<User> GetUsers()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                // Get all information about user

                return db.Query<User>("SELECT * FROM users").ToList();
            }
        }

        public User Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                // Get all information include address about user
                // Чтобы взять информацию из двух таблиц, используется INNER JOIN
                return db.Query<User>("SELECT * FROM users INNER JOIN addresses ON users.id = addresses.id WHERE users.id = @Id", new { id }).FirstOrDefault();
            }
        }

        public void Create(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                // Сначала вставляется информация в родительскую таблицу, затем в дочернюю
                var sqlQuery = "INSERT INTO users (fio, age, sex) VALUES(@Fio, @Age, @Sex)" +
                    "INSERT INTO addresses (address) VALUES (@Address);";
                db.Execute(sqlQuery, user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                // Сначала удаляется информация в дочерней таблице, затем в родительской
                var sqlQuery = "DELETE FROM addresses WHERE id = @Id;" +
                    "DELETE FROM users WHERE id = @Id;";
                db.Execute(sqlQuery, new { id });
            }
        }

        public void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                // Сначала обновляется информация в дочерней таблице, затем в родительской
                var sqlQuery = "UPDATE users SET fio = @Fio, age = @Age, sex = @Sex WHERE id = @Id;" +
                    "UPDATE addresses SET address = @Address WHERE id = @Id";
                db.Execute(sqlQuery, user);
            }
        }
    }
}
