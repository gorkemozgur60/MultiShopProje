namespace MultiShop.Discount.Dtos
{
    public class UpdateCoupon
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public int Rate { get; set; }
        public DateTime valiDate { get; set; }
    }
}
