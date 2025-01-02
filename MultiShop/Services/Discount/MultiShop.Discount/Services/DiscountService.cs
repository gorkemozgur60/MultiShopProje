using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCoupon createCoupon)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,valiDate) values (@code, @rate, @isActive, @validDate)";    
            var parameters = new DynamicParameters();
            parameters.Add("@code",createCoupon.Code);
            parameters.Add("@rate",createCoupon.Rate);
            parameters.Add("@isActive", createCoupon.IsActive);
            parameters.Add("@validDate", createCoupon.valiDate);
            using(var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId = @couponId ";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using(var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCoupon>> GetAllCouponsAsync()
        {
            string query = "Select * From Coupons";

            using(var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCoupon>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCoupon> GetByIdCouponAsync(int id)
        {
            var query = "Select * From Coupons where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using(var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdCoupon>(query,parameters);
                return value;
            }
        }

        public async Task<ResultCoupon> GetCodeDetailByCode(string code)
        {
            string query = "Select * From Coupons Where Code = @code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);

            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<ResultCoupon>(query, parameters);
                return value;
            }
        }

        public async Task<int> GetDiscountCouponCount()
        {
            string query = "Select Count(*) From Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public int GetDiscountCouponCountRate(string code)
        {
            string query = "Select Rate From Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public async Task UpdateCouponAsync(UpdateCoupon updateCoupon)
        {
            var query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,valiDate=@validDate where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCoupon.Code);
            parameters.Add("@rate", updateCoupon.Rate);
            parameters.Add("@isActive", updateCoupon.IsActive);
            parameters.Add("@validDate", updateCoupon.valiDate);
            parameters.Add("@couponId", updateCoupon.CouponId);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
