using System;
using Applications.PetStore.Swagger.Api;
using Applications.PetStore.Swagger.Model;
using NUnit.Framework;
using static PetStoreTests.TestHelper;

namespace PetStoreTests;

public class OrderTests
{
    readonly StoreApi _storeApi = new StoreApi(TestHelper.BasePath);

    [Test]
    [QaVerification.Grading]
    public void AddOrder()
    {
        Order order = new Order(id: 21);
        
        _storeApi.PlaceOrder(order);
        
        Assert.That(order, Is.EqualTo(_storeApi.GetOrderById(21)));
        
        _storeApi.DeleteOrder(21);
    }
}
