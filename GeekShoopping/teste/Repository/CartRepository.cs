using AutoMapper;
using GeekShopping.CartAPI.Model;
using GeekShopping.CartAPI.Model.Context;
using GeekShopping.teste.Data.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.teste.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;

        public CartRepository(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeader = await _context.CartHeader
                        .FirstOrDefaultAsync(c => c.UserId == userId);
            if (cartHeader != null)
            {
                _context.CartDetail
                    .RemoveRange(
                    _context.CartDetail.Where(c => c.CartHeaderId == cartHeader.Id));
                _context.CartHeader.Remove(cartHeader);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CartVO> FindCartByUserId(string userId)
        {
            Cart cart = new()
            {
                CartHeader = await _context.CartHeader
                    .FirstOrDefaultAsync(c => c.UserId == userId),
            };
            cart.CartDetail = _context.CartDetail
                .Where(c => c.CartHeaderId == cart.CartHeader.Id)
                    .Include(c => c.Product);
            return _mapper.Map<CartVO>(cart);
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(long cartDetailsId)
        {
            try
            {
                CartDetail cartDetail = await _context.CartDetail
                    .FirstOrDefaultAsync(c => c.Id == cartDetailsId);

                int total = _context.CartDetail
                    .Where(c => c.CartHeaderId == cartDetail.CartHeaderId).Count();

                _context.CartDetail.Remove(cartDetail);
                
                if (total == 1)
                {
                    var cartHeaderToRemove = await _context.CartHeader
                        .FirstOrDefaultAsync(c => c.Id == cartDetail.CartHeaderId);
                    _context.CartHeader.Remove(cartHeaderToRemove);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CartVO> SaveOrUpdateCart(CartVO vo)
        {
            Cart cart = _mapper.Map<Cart>(vo);
            //Checks if the product is already saved in the database if it does not exist then save
            var product = await _context.Products.FirstOrDefaultAsync(
                p => p.Id == vo.CartDetail.FirstOrDefault().ProductId);
            
            if (product == null)
            {
                _context.Products.Add(cart.CartDetail.FirstOrDefault().Product);
                await _context.SaveChangesAsync();
            }

            //Check if CartHeader is null

            var cartHeader = await _context.CartHeader.AsNoTracking().FirstOrDefaultAsync(
                c => c.UserId == cart.CartHeader.UserId);

            if (cartHeader == null)
            {
                //Create CartHeader and CartDetails
                _context.CartHeader.Add(cart.CartHeader);
                await _context.SaveChangesAsync();
                cart.CartDetail.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                cart.CartDetail.FirstOrDefault().Product = null;
                _context.CartDetail.Add(cart.CartDetail.FirstOrDefault());
                await _context.SaveChangesAsync();
            }
            else
            {
                //If CartHeader is not null
                //Check if CartDetails has same product
                var cartDetail = await _context.CartDetail.AsNoTracking().FirstOrDefaultAsync(
                    p => p.ProductId == cart.CartDetail.FirstOrDefault().ProductId &&
                    p.CartHeaderId == cartHeader.Id);

                if (cartDetail == null)
                {
                    //Create CartDetails
                    cart.CartDetail.FirstOrDefault().CartHeaderId = cartHeader.Id;
                    cart.CartDetail.FirstOrDefault().Product = null;
                    _context.CartDetail.Add(cart.CartDetail.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
                else
                {
                    //Update product count and CartDetails
                    cart.CartDetail.FirstOrDefault().Product = null;
                    cart.CartDetail.FirstOrDefault().Count += cartDetail.Count;
                    cart.CartDetail.FirstOrDefault().Id = cartDetail.Id;
                    cart.CartDetail.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;
                    _context.CartDetail.Update(cart.CartDetail.FirstOrDefault());
                    await _context.SaveChangesAsync();
                } 
            }
            return _mapper.Map<CartVO>(cart);
        }
    }
}
