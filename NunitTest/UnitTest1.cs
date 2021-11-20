using NUnit.Framework;
using ProductModule.Controllers;
using ProductModule.Controllers.Handler;
using ProductModule.Models;
using Moq;
using System.Collections.Generic; 
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace NunitTest;

public class Tests
{
    private readonly ProductController _controller;
    // private readonly Mock<ProductContext> _context;
    private readonly Mock<IHandler> _handler;

    public Tests()
    {
        // _context = new Mock<ProductContext>();
        _handler = new Mock<IHandler>();
        _controller = new ProductController(_handler.Object);
    }

    [Test]
    public async Task Test_Get()
    {
        var list = GetList();
        _handler.Setup(m=> m.GetProducts()).Returns(list);
        var response = await _controller.Get() as OkObjectResult;
        Assert.AreEqual(200,response?.StatusCode);
    }

    [Test]
    public async Task Test_Post()
    {
        var product = new Product(){Id=1,Name="Shoes",Description="Footwear",Price=5000};
        _handler.Setup(m=> m.PostProduct(product));
        var response = await _controller.post(product) as StatusCodeResult;
        Assert.AreEqual(200,response?.StatusCode);
    }

    [Test]
    public async Task Test_Put_Success()
    {
        var product = new Product(){Id=1,Name="Shoes",Description="Footwear",Price=5000};
        int id = 1;
        _handler.Setup(m=> m.EditProduct(id,product));
        var response = await _controller.update(id,product) as StatusCodeResult;
        Assert.AreEqual(200,response?.StatusCode);
    }

    [Test]
    public async Task Test_Put_Failed()
    {
        var product = new Product(){Id=1,Name="Shoes",Description="Footwear",Price=5000};
        int id = 2;
        var ex = new Exception("Product not found");
        _handler.Setup(m=> m.EditProduct(id,product)).Throws(ex);
        var response = await _controller.update(id,product) as StatusCodeResult;
        Assert.AreEqual(400,response?.StatusCode);
    }

    [Test]
    public async Task Test_Delete_Success()
    {
        int id = 1;
        _handler.Setup(m=> m.DeleteProduct(id));
        var response = await _controller.Delete(id) as StatusCodeResult;
        Assert.AreEqual(200,response?.StatusCode);
    }

    [Test]
    public async Task Test_Delete_Failed()
    {
        int id = 2;
        var ex = new Exception("Product not found");
        _handler.Setup(m=> m.DeleteProduct(id)).Throws(ex);
        var response = await _controller.Delete(id) as StatusCodeResult;
        Assert.AreEqual(400,response?.StatusCode);
    }

    public async Task<List<Product>> GetList(){
        List<Product> productList = new List<Product>() 
        {
            new Product(){Id=1,Name="Shoes",Description="Footwear",Price=5000}
        };
        return await Task.FromResult(new List<Product> 
        {
            new Product(){Id=1,Name="Shoes",Description="Footwear",Price=5000}
        });
    }
}