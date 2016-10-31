namespace MiniORMLive
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using CustomORM.Core;
    using MiniORMLive.Attributes;

    class EntityManager : IDbContext
    {
        private SqlConnection connection;
        private string connectionString;
        private bool isCodeFirst;

        public EntityManager(string connectionString, bool isCodeFirst)
        {
            this.connectionString = connectionString;
            this.isCodeFirst = isCodeFirst;
        }

        public bool Persist(object entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Cannot persist null entity");
            }

            if (isCodeFirst && !CheckIfTableExists(entity.GetType()))
            {
                this.CreateTable(entity.GetType());

            }

            Type entityType = entity.GetType();
            FieldInfo idInfo = GetId(entityType);
            int id = (int)idInfo.GetValue(entity);

            if (id <= 0)
            {
                return this.Insert(entityType, idInfo);
            }

            return this.Update(entityType, idInfo);

        }

        private bool Update(Type entityType, FieldInfo idInfo)
        {
            int numberOfAffectedRows = 0;
            string sqlCode = PrepareUpdateStatement(entityType, idInfo);

            using (this.connection = new SqlConnection(this.connectionString))
            {
                SqlCommand updateCommand = new SqlCommand(sqlCode, this.connection);
                this.connection.Open();
                numberOfAffectedRows = (int)updateCommand.ExecuteScalar();

                return numberOfAffectedRows > 0;
            }
        }

        private string PrepareUpdateStatement(Type entityType, FieldInfo idInfo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"UPDATE {GetTableName(entityType.GetType())} SET ");

            FieldInfo[] columns = entityType.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                    .Where(x => x.IsDefined(typeof(ColumnAttribute)))
                                    .ToArray();

            StringBuilder settings = new StringBuilder();

            foreach (var column in columns)
            {
                settings.Append($"{this.GetColumnName(column)} = '{column.GetValue(entityType)}', ");
            }

            settings.Remove(settings.Length - 2, 2);
            builder.Append(settings);

            builder.Append($"WHERE Id = {idInfo.GetValue(entityType)}");

            return builder.ToString();

        }

        private bool Insert(Type entityType, FieldInfo idInfo)
        {
            int numberOfAffectedRows = 0;
            string insertSQL = PrepareInsertStatement(entityType, idInfo);

            using (this.connection = new SqlConnection(this.connectionString))
            {
                SqlCommand insertCommand = new SqlCommand(insertSQL, this.connection);
                connection.Open();
                numberOfAffectedRows = insertCommand.ExecuteNonQuery();
            }

            string maxIdQuery = $"SELECT MAX(ID) FROM {this.GetTableName(entityType.GetType())}";
            SqlCommand lastIdCommand = new SqlCommand(maxIdQuery, this.connection);
            int currentId = (int)lastIdCommand.ExecuteScalar();
            idInfo.SetValue(entityType, currentId);

            return numberOfAffectedRows > 0;
        }

        private string PrepareInsertStatement(Type entityType, FieldInfo idInfo)
        {
            throw new NotImplementedException();
        }

        private bool CheckIfTableExists(Type type)
        {
            string query =
                $"SELECT COUNT(name) " +
                $"FROM sys.sysobjects " +
                $"WHERE [Name] = '{this.GetTableName(type)}' AND [xtype] = 'U'";

            int numberOfTables = 0;
            using (connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                SqlCommand command = new SqlCommand(query, this.connection);
                numberOfTables = (int)command.ExecuteScalar();
            }

            return numberOfTables > 0;
        }

        public T FindById<T>(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> FindAll<T>()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> FindAll<T>(string @where)
        {
            throw new System.NotImplementedException();
        }

        public T FindFirst<T>()
        {
            throw new System.NotImplementedException();
        }

        public T FindFirst<T>(string @where)
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(object entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById<T>(int id)
        {
            throw new System.NotImplementedException();
        }

        private void CreateTable(Type entity)
        {
            string creationStrign = PrepareTableCreationString(entity);

            using (connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                SqlCommand command = new SqlCommand(creationStrign, this.connection);
                command.ExecuteNonQuery();
            }

        }

        private string PrepareTableCreationString(Type entity)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"CREATE TABLE {GetTableName(entity)} ");
            builder.Append("ID INT PRIMARY KEY IDENTITY(1,1), ");

            FieldInfo[] columnsInfo = entity.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                    .Where(x => x.IsDefined(typeof(ColumnAttribute)))
                                    .ToArray();

            foreach (var column in columnsInfo)
            {
                builder.Append($"{GetColumnName(column)} {this.GetTypeToDB(column)}, ");
            }
            builder.Remove(builder.Length - 2, 2);
            builder.Append(")");

            return builder.ToString();

        }

        private string GetTypeToDB(FieldInfo field)
        {
            switch (field.FieldType.Name)
            {
                case "Int32":
                    return "int";
                case "String":
                    return "varchar(max)";
                case "DateTime":
                    return "datetime";
                case "Boolean":
                    return "bit";
                default:
                    Console.WriteLine(field.FieldType.Name);
                    throw new ArgumentException("No such present type - try extending the framework!");
            }
        }

        private FieldInfo GetId(Type entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Cannot get id for null type!");
            }

            FieldInfo id =
                entity.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .FirstOrDefault(x => x.IsDefined(typeof(IdAttribute)));

            if (id == null)
            {
                throw new ArgumentNullException("No id field was found the current class!");
            }

            return id;
        }

        private string GetTableName(Type entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Table null!");
            }

            if (!entity.IsDefined(typeof(EntityAttribute)))
            {
                throw new ArgumentException("Cannot get table name of entity!");
            }

            string tableName = entity.GetCustomAttribute<EntityAttribute>().TableName;

            if (tableName == null)
            {
                throw new ArgumentNullException("Table name cannot be null!");
            }

            return tableName;
        }

        private string GetColumnName(FieldInfo field)
        {
            if (field == null)
            {
                throw new ArgumentNullException("Field cannot be null");
            }

            if (!field.IsDefined(typeof(ColumnAttribute)))
            {
                return field.Name;
            }

            string columnName = field.GetCustomAttribute<ColumnAttribute>().ColumnName;
            if (columnName == null)
            {
                throw new ArgumentNullException("Column name cannot be null!");
            }

            return columnName;

        }
    }
}
