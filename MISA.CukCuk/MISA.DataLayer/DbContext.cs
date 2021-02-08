using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using MISA.Common.Models;
using MySqlConnector;

namespace MISA.DataLayer
{
    /// <summary>
    /// Kết nối và thao tác database
    /// </summary>
    /// CreatedBy: DMCUONG (05/02/2021)
    public class DbContext
    {
        #region DECLARE

        private const string _connectionString =
            "Host = 103.124.92.43;" +
            "Port = 3306;" +
            "Database = DMCuong_MF740_CukCuk;" +
            "UserId = nvmanh;" +
            "password = 12345678;";

        private readonly IDbConnection _dbConnection;

        #endregion DECLARE

        #region CONSTRUCTOR

        public DbContext()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }

        #endregion CONSTRUCTOR

        #region METHOD

        /// <summary>
        /// Lấy toàn bộ dữ liệu từ 1 bảng
        /// </summary>
        /// <typeparam name="TEntity">Tên bảng</typeparam>
        /// <returns>Toàn bộ dữ liệu</returns>
        public IEnumerable<TEntity> GetData<TEntity>()
        {
            // Thực thi truy vấn lấy dữ liệu
            var entity = _dbConnection.Query<TEntity>($"SELECT * FROM {typeof(TEntity).Name}",
                commandType: CommandType.Text);
            return entity;
        }

        public IEnumerable<TEntity> GetData<TEntity>(string sqlCommand, CommandType commandType = CommandType.Text)
        {
            // Thực thi truy vấn lấy dữ liệu
            var entity = _dbConnection.Query<TEntity>(sqlCommand,
                commandType: commandType);
            return entity;
        }

        /// <summary>
        /// Thực hiện thêm mới object vào database
        /// </summary>
        /// <param name="entity">object cần thêm mới</param>
        /// <returns>Số lượng bản ghi thêm được vào database</returns>
        /// CreatedBy: DMCUONG (05/02/2021)
        public int InsertObject(object entity)
        {
            var response = _dbConnection.Execute("Proc_InsertCustomer", entity, commandType: CommandType.StoredProcedure);
            return response;
        }

        /// <summary>
        /// Kiểm tra mã khách hàng đã tồn tại chưa
        /// </summary>
        /// <param name="customerCode">Mã khách hàng cần kiểm tra</param>
        /// <returns>Mã khách hàng tìm được hoặc null</returns>
        /// CreatedBy: DMCUONG (06/02/2021)
        public string CheckCustomerCodeExist(string customerCode)
        {
            var sql = $"SELECT CustomerCode FROM Customer AS C WHERE C.CustomerCode = '{customerCode}'";
            var customerCodeInDb = _dbConnection.Query<string>(sql).FirstOrDefault();
            return customerCodeInDb;
        }

        /// <summary>
        /// Kiểm tra số điện thoại khách hàng đã tồn tại chưa
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại cần kiểm tra</param>
        /// <returns>Số điện thoại tìm được hoặc null</returns>
        /// CreatedBy: DMCUONG (06/02/2021)
        public string CheckPhoneNumberExist(string phoneNumber)
        {
            var sql = $"SELECT PhoneNumber FROM Customer AS C WHERE C.PhoneNumber = '{phoneNumber}'";
            var customerCodeInDb = _dbConnection.Query<string>(sql).FirstOrDefault();
            return customerCodeInDb;
        }

        #endregion METHOD
    }
}