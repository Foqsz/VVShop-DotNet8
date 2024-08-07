using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VVShop.CartApi.DTOs;
using VVShop.CartApi.Repositories;

namespace VVShop.CartApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartRepository _repository;

    public CartController(ICartRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("getcart/{id}")]
    public async Task<ActionResult<CartDTO>> GetByUserId(string userId)
    {
        //aqui eu busco o id no repository, caso nao encontre, retorna null na if
        var cart = await _repository.GetCartByUserIdAsync(userId);

        if (cart == null)
        {
            return NotFound();
        }

        return Ok(cart);
    }

    [HttpPost("addcart")]
    public async Task<ActionResult<CartDTO>> AddCart(CartDTO cartDto)
    {
        var cart = await _repository.UpdateCartAsync(cartDto);

        if (cart == null)
        {
            return NotFound();
        }

        return Ok(cart);
    }

    [HttpPut("updatecart")]
    public async Task<ActionResult<CartDTO>> UpdateCart(CartDTO cartDto)
    {
        var cart = await _repository.UpdateCartAsync(cartDto);

        if (cart == null)
        {
            return NotFound();
        }

        return Ok(cart);
    }

    [HttpDelete("deletecart/{id}")]
    public async Task<ActionResult<bool>> DeleteCart(int id)
    {
        var status = await _repository.DeleteItemCartAsync(id);

        if (!status)
        {
            return BadRequest();
        }
        return Ok(status);
    }
}
