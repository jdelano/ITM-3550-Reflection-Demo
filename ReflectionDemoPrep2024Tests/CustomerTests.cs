namespace ReflectionDemoPrep2024Tests;

[TestClass]
public class CustomerTests
{
    private object? customer;

    [TestInitialize]
    public void TestInitialize()
    {
        customer = ReflectionTest.GetInstance("ReflectionDemoPrep2024", "Customer");
        Assert.IsNotNull(customer);
    }

    [TestMethod]
    public void Customer_Id_Exists()
    {
        var id = ReflectionTest.GetProperty(customer!, "Id");
        id.SetValue(customer, 100);
        Assert.AreEqual(100, id.GetValue(customer));
    }

    [TestMethod]
    public void Customer_Balance_FullProperty()
    {
        var isFullProp = ReflectionTest.IsPropertyAutoImplemented(customer!, "Balance");
        Assert.IsFalse(isFullProp);
    }

    [TestMethod]
    public void Customer_PlaceOrder_Implemented()
    {
        var balanceProp = ReflectionTest.GetProperty(customer!, "Balance");
        balanceProp.SetValue(customer, 1000);
        var orderMethod = ReflectionTest.GetMethod(customer!, "PlaceOrder");
        orderMethod.Invoke(customer, null);
        Assert.AreEqual(900, balanceProp.GetValue(customer!));
    }

    [TestMethod]
    public void Customer_PlaceOrderFor_Implemented()
    {
        var balanceProp = ReflectionTest.GetProperty(customer!, "Balance");
        balanceProp.SetValue(customer, 1000);
        var orderMethod = ReflectionTest.GetMethod(customer!, "PlaceOrderFor");
        orderMethod.Invoke(customer, new object[] { 200 });
        Assert.AreEqual(800, balanceProp.GetValue(customer!));
    }

}
